using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2016
{
    public class DayTwentyThree
    {
        public static string PUZZLE_INPUT = @"cpy a b
dec b
cpy a d
cpy 0 a
cpy b c
inc a
dec c
jnz c -2
dec d
jnz d -5
dec b
cpy b c
cpy c d
dec d
inc c
jnz d -2
tgl c
cpy -16 c
jnz 1 c
cpy 87 c
jnz 74 d
inc a
inc d
jnz d -2
inc c
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
                // Crazy multiplicative loop that starts at i == 4, so handle seperately
                if (i == 4)
                {
                    _registers["a"] = _registers["b"] * _registers["d"];
                    _registers["c"] = 0;
                    _registers["d"] = 0;
                    i = 9;
                }
                else
                {
                    string instruction = lineInputs[i];
                    Debug.WriteLine($"line: {instruction}. i={i}");

                    // Handle the toggle command
                    if (instruction.Contains("tgl"))
                    {
                        string register = instruction.Split(' ')[1];
                        int numInstructionModify = _registers[register];
                        if (numInstructionModify != 0 && (i + numInstructionModify >= 0) && (i + numInstructionModify < lineInputs.Count))
                        {
                            string modifiedInstruction = ToggleConvertInstruction(lineInputs[i + numInstructionModify]);
                            lineInputs[i + numInstructionModify] = modifiedInstruction;
                        }
                    }
                    else
                    {
                        int offset = ProcessInstruction(instruction);
                        if (offset != 0)
                            i = (i + offset) - 1;
                    }
                }
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

                // Only if valid condition, continue
                int potentialValue;
                if (!int.TryParse(receivingRegister, out potentialValue))
                {
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
                int potentialValueTwo;
                // Can copy from an existing register or give a int
                if (int.TryParse(splitSpace[1], out potentialValue))
                {
                    if (potentialValue != 0)
                    {
                        if (int.TryParse(splitSpace[2], out potentialValueTwo))
                        {
                            returnValue = potentialValueTwo;
                        }
                        else
                        {
                            returnValue = _registers[splitSpace[2]];
                        }
                    }
                }
                else
                {
                    string testingRegister = splitSpace[1];
                    if (_registers[testingRegister] != 0)
                    {
                        if (int.TryParse(splitSpace[2], out potentialValueTwo))
                        {
                            returnValue = potentialValueTwo;
                        }
                        else
                        {
                            returnValue = _registers[splitSpace[2]];
                        }
                    }
                }
            }

            return returnValue;
        }

        public string ToggleConvertInstruction(string input)
        {
            string cmd = input.Substring(0, 3);
            string alteredCmd = "";
            if (cmd == "inc")
                alteredCmd = "dec";

            if (cmd == "dec")
                alteredCmd = "inc";

            if (cmd == "tgl")
                alteredCmd = "inc";

            if (cmd == "cpy")
                alteredCmd = "jnz";

            if (cmd == "jnz")
                alteredCmd = "cpy";

            return $"{alteredCmd}{input.Substring(3)}";
        }
    }
}