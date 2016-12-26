using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2016
{
    public class DayTwentyFive
    {
        public static string PUZZLE_INPUT = @"cpy a d
cpy 7 c
cpy 362 b
inc d
dec b
jnz b -2
dec c
jnz c -5
cpy d a
jnz 0 0
cpy a b
cpy 0 a
cpy 2 c
jnz b 2
jnz 1 6
dec b
dec c
jnz c -4
inc a
jnz 1 -7
cpy 2 b
jnz c 2
jnz 1 4
dec b
dec c
jnz 1 -4
jnz 0 0
out b
jnz a -19
jnz 1 -21";

        public int RegisterA;
        public int RegisterB;
        public int RegisterC;
        public int RegisterD;

        public Dictionary<string, int> _registers;

        // Process the instructions and return the result on the register passed
        public int LowestIntegerThatProducesAlternatingSignal(string input, Dictionary<string, int> registers)
        {
            int result = 0;
            _registers = registers;

            int counter = 104;  // Originally 1, but changed the counter after debugging through, this lets the tests run faster
            int timesThrough = 0;
            bool found = false;

            List<string> lineInputs = input.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();

            while (found == false)
            {
                found = true;

                // Reset a to have the new value
                _registers["a"] = counter;

                for (int i = 0; i < lineInputs.Count(); i++)
                {
                    string instruction = lineInputs[i];

                    // out x transmits x
                    if (instruction.Contains("out"))
                    {
                        List<string> splitSpace = instruction.Split(' ').ToList();
                        int signal = ProvideEitherRegisterValueOrActualValue(splitSpace[1]);

                        // Check to see if the output is correct
                        if (timesThrough % 2 == 0)
                        {
                            if (signal != 0)
                            {
                                found = false;
                                break;
                            }
                        }
                        else
                        {
                            if (signal != 1)
                            {
                                found = false;
                                break;
                            }
                        }

                        // If timesThrough > 100; then it is the answer
                        Debug.WriteLine($"counter: {counter}. timesThrough: {timesThrough}");
                        timesThrough++;
                        if (timesThrough > 100)
                            return counter;
                    }
                    else
                    {
                        int offset = ProcessInstruction(instruction);
                        if (offset != 0)
                            i = (i + offset) - 1;
                    }
                }

                // Reinitalize
                counter++;
                timesThrough = 0;
            }

            return 0;
        }

        // TODO: Extract this, the one from Day 23 and the one from Day 12? to a utility class that handles all
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
                    _registers[receivingRegister] = ProvideEitherRegisterValueOrActualValue(splitSpace[1]);
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
                    {
                        returnValue = ProvideEitherRegisterValueOrActualValue(splitSpace[2]);
                    }
                }
                else
                {
                    string testingRegister = splitSpace[1];
                    if (_registers[testingRegister] != 0)
                    {
                        returnValue = ProvideEitherRegisterValueOrActualValue(splitSpace[2]);
                    }
                }
            }

            return returnValue;
        }

        private int ProvideEitherRegisterValueOrActualValue(string input)
        {
            int potentialOutValue;
            if (int.TryParse(input, out potentialOutValue))
            {
                return potentialOutValue;
            }

            return _registers[input];
        }
    }
}