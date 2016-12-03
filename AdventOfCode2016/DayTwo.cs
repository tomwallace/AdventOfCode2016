using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2016
{
    public class DayTwo
    {
        public static string PUZZLE_INPUT = @"LUULRUULULLUDUDULDLUDDDLRURUDLRRDRDULRDDULLLRULLLURDDLRDLUUDDRURDDRDDDDRDULULLLLURDDLLRLUUDDDRLRRRDURLDDLRRLDUDRRRDLDLRRDLDLUURRLRULLULRUDRDLRUURLDRDLRLDULLLUDRDDRLURLUUDRLLLDRUUULLUULRUDDUDRDUURRRUDRLDDUURDUURUDRDDLULDDUDUDRRDDULUDULRDRULRLRLURURDULRUULLRDDDDRRUUDDDUUDRLLRUDRLRDLRRLULRLULRUDDULRLLLURLDDRLDDLRRLDRDDDRRLRUDRULUUDUURLDLRRULUDRDULDLLRRURRDDLRRRLULUDUUDDUDDLRDLRDRLRLDUDUDDUDLURRUURDRLRURLURRRLRLRRUDDUDDLUDRLUURUUDUUDDULRRLUUUDRLRLLUR
LDLLRRLDULDDRDDLULRRRDDUDUDRRLLRUUULRUDLLRRDDRRLDDURUUDLUDRRLDURDDRUDLUDUUDLDLLLDLLLDRLLDLRUULULLUUDULDUUULDDLRUDLLUDLUUULDRLUDRULUUDLDURDLDUULLRDUDRDLURULDLUUUDURLDDRLLDRLRDDDUDRUULLDLUDRRDDLDLUURUDDLDRURRLULUDDURLDRDRDUDDRRULRLDURULULRURDUURRUDRDDRDRLDRDUUDLRULRDDDULRURUDRUUULUUDDLRRDDDUDRLRUDRDLRRUDLUDRULDDUDLRLDDLDRLRDLULRDRULRLLRLUDUURULLLDDUULUUDDDUDRRULDDDULRUDRRLRLLLUDLULDUUULDDULDUUDLUULRDLDUDRUDLLDLDLLULDDDDLUDDUDRUDLRRRDDDDDLLRRDRUUDDDRRULRUDUUDRULLDLLLDDRDDUURLUUURUDRUDURLRUUUULUUURDRRRULDUULDLDDDRDDDDLLDRUDRDURLDDURDURULDDRLLRRLDUDRDURRLDRDLLULUUUD
LDDLRLRDDRLRUDDRDDUDRULUUULULDULRUULLRRDUULRDUUDDDRRULDDUDRLLLDULURDLDDRLLRURULULDLDULRDLDLRULUDLLDRUDLDURRDULDDRLRURDLLUDRDDDUDLUDULURULRDRLRULDLLRLDRRUDRDRUDRLDLRLUUURURRRLDDULLULLLRLRLULDLLRLDDRLDULURULRUURRUUURRUDRLRRURURDDDRULDULDLDLRRRLLDDRRURRULULULDRDULDRRULDUDRRLDULDRDURRDULLRRRLLLLRRLLRRRDRURDUULLURURURDDRRDRLLLULRRRDRLDRLDRDLLRUUDURRDRRDLLUDLDRLRLDLUDRDULRULRRLLRDLULDRLUDUUULLDRULDDLLRDUUUDRUUUUULUURDDLLDUURURRURLLURRDDUDUDRUUDDRDDRRLRLULRLRRRDRLLRRLLLDUULLUUDDLULLLDURRLLDRLDRDRLRRLRRULRRRRLRRRRRURUDULUULRDLLDRLRRDUURDRRUDRURRRDDRLDDLRLUDRDRDRRLDDDRDDRRRDUDULRURRDRDLLDRUD
UUUDLDDLRDLLLLRUUURDDLLURRUUURLUULLURUUDUDLDULULLRRRRLLLRDLLUDRUURDRURUDRURRLRLDRURLUDRLULRRURDDDURLLDULDLRRRDUUDDDRDLRUURRDRDRLRDLULRLDDRULRULDRDUDRUURLDLUDDULLLRURRLURLULDRRLUUURURLDLDDULLLRUUURDDDUURULULLUUUDUDRLLRRULUULDDDLLUDLURLLLRRULLURDRLUUDDLLDLLLUDULLRDRRRURDRUDUDUULUDURDLRUDLLRDDRURUDURLRULURDDURULLRDDRLRRDRLLULRDDDULRDLRULDDLRRDULDLUURRURUULRRDUURUDRRRRRLDULDLRURRULULDLRDDDRLLDURRULDUDUDRRRLUULRLUDURRRLRLDURRRRUULDRLUDDDUDURLURUDLLUDRDDDRLLURLRLDDURUUDDDUDUR
RURRRRURUDDRLURUDULRDUDDDUURULDRRRRURDLDRRLLDLUDLRRLRRUULLURULLRDLLRDDDDULLRLLDDLLRUDDULDUDLDURLRUULDDURURDURDLDRRULRURRRRRLRRLLUDURRURULRLRDLRLRRRLLURURDLLLDLDDULDLUDDLLLRUDDRDRLRUDRRLDDLRDLRLRLRLRRDUUURRUDRRLDLRRUULULLUDRRRUDLURDRUULDRDRRLUULULDDLURRLDULLURLDRLDULDRLLDLUUULLULRRDDRURRURLDLDRRLLLLLUDUURUULURLRDDDLRRRRLLLURUDLDDRDDRRUDURUULDRRULLLRRLRULLLRLDDLLRRLRURLRDRUDULLDDLDDDDDLDURURDLULRDDLRDLLRURLLRDLRUDDRDRRDURDURLUDRLDUDDDRRURRLUULURULLRLRDLRRLRURULLDDURLLRRRUDDRDLULURRRUUUULUULRRLLDLRUUURLLURLUURRLRL";

        public static string[,] KEY_PAD = new string[,] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };

        public static string[,] KEY_PAD_TWO = new string[,]
        {
            { "", "", "1", "", "" },
            { "", "2", "3", "4", "" },
            { "5", "6", "7", "8", "9" },
            { "", "A", "B", "C", "" },
            { "", "", "D", "", "" }
        };

        // Determines the appropriate bathroom code based on instructions moving over a keypad
        public string DetermineBathroomCode(string input, int horizontal, int vertical, string[,] keyPad)
        {
            string result = "";

            List<string> lineInputs = input.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            foreach (string lineInput in lineInputs)
            {
                List<char> steps = lineInput.ToList<char>();
                foreach (char step in steps)
                {
                    if (step == 'U')
                    {
                        vertical = HandleOutOfBoundsVertical(vertical, horizontal, -1, keyPad);
                    }
                    else if (step == 'L')
                    {
                        horizontal = HandleOutOfBoundsHorizontal(vertical, horizontal, -1, keyPad);
                    }
                    else if (step == 'R')
                    {
                        horizontal = HandleOutOfBoundsHorizontal(vertical, horizontal, 1, keyPad);
                    }
                    else if (step == 'D')
                    {
                        vertical = HandleOutOfBoundsVertical(vertical, horizontal, 1, keyPad);
                    }
                    else
                    {
                        throw new ArgumentException("Not recongized direction");
                    }
                }

                result += keyPad[vertical, horizontal];
            }

            return result;
        }

        // Handle out of bounds exceptions - VERTICAL
        private int HandleOutOfBoundsVertical(int vertical, int horizontal, int change, string[,] keyPad)
        {
            int newValue = vertical + change;
            if (newValue < 0 || newValue >= keyPad.GetLength(0))
                return vertical;

            // Check there is a value there
            string keyPadEntry = keyPad[newValue, horizontal];
            if (keyPadEntry == "")
                return vertical;

            return newValue;
        }

        // Handle out of bounds exceptions - HORIZONTAL
        private int HandleOutOfBoundsHorizontal(int vertical, int horizontal, int change, string[,] keyPad)
        {
            int newValue = horizontal + change;
            if (newValue < 0 || newValue >= keyPad.GetLength(0))
                return horizontal;

            // Check there is a value there
            string keyPadEntry = keyPad[vertical, newValue];
            if (keyPadEntry == "")
                return horizontal;

            return newValue;
        }
    }
}