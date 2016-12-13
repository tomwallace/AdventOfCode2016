using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    public class DayTwelve
    {
        public static string PUZZLE_INPUT = @"cpy 1 a
cpy 1 b
cpy 26 d
jnz c 2
jnz 1 5
cpy 7 c
inc d
dec c
jnz c -2
cpy a c
inc a
dec b
jnz b -2
cpy c b
dec d
jnz d -6
cpy 19 c
cpy 14 d
inc a
dec d
jnz d -2
dec c
jnz c -5";

        public int RegisterA;
        public int RegisterB;
        public int RegisterC;
        public int RegisterD;

        public Dictionary<string, int> _registers;

        // Process the instructions and return the result on the register passed
        public int ProcessInstructionsAndReturnResult(string input, string registerName, Dictionary<string, int> registers)
        {
            int result = 0;
            _registers = registers;

            List<string> lineInputs = input.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();

            for (int i = 0; i < lineInputs.Count(); i++)
            {
                string instruction = lineInputs[i];
                Debug.WriteLine($"line: {instruction}. i={i}");
                int offset = ProcessInstruction(instruction);
                if (offset != 0)
                    i = (i + offset) - 1;
            }

            return _registers[registerName];
        }

        // Process the instructions.  If the int is not 0 then jump that many relative instructions away.
        public int ProcessInstruction(string instruction)
        {
            int returnValue = 0;
            // cpy x y copies x (either an integer or the value of a register) into register y
            if (instruction.Contains("cpy"))
            {
                List<string> splitSpace = instruction.Split(' ').ToList();
                string receivingRegister = splitSpace[2];
                int potentialValue;
                // Can copy from an existing register or give a int
                if (int.TryParse(splitSpace[1], out potentialValue))
                {
                    _registers[receivingRegister] = potentialValue;
                }
                else
                {
                    _registers[receivingRegister] = _registers[splitSpace[1]];
                }
            }

            // inc x increases the value of register x by one.
            if (instruction.Contains("inc"))
            {
                List<string> splitSpace = instruction.Split(' ').ToList();
                string incrementingRegister = splitSpace[1];
                _registers[incrementingRegister] += 1;
            }

            // dec x decreases the value of register x by one.
            if (instruction.Contains("dec"))
            {
                List<string> splitSpace = instruction.Split(' ').ToList();
                string incrementingRegister = splitSpace[1];
                _registers[incrementingRegister] -= 1;
            }

            // jnz x y jumps to an instruction y away (positive means forward; negative means backward), but only if x is not zero.
            if (instruction.Contains(("jnz")))
            {
                List<string> splitSpace = instruction.Split(' ').ToList();
                int potentialValue;
                // Can copy from an existing register or give a int
                if (int.TryParse(splitSpace[1], out potentialValue))
                {
                    if (potentialValue != 0)
                        returnValue = Int32.Parse(splitSpace[2]);
                }
                else
                {
                    string testingRegister = splitSpace[1];
                    if (_registers[testingRegister] != 0)
                    {
                        returnValue = Int32.Parse(splitSpace[2]);
                    }
                }
            }

            return returnValue;
        }
    }
}