using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2016
{
    public class DaySixteen
    {
        public string CalculateCheckSumToFillDisk(string initialState, int length)
        {
            string dragonCurve = CreateDragonCurveOfWidth(length, initialState);
            string checkSum = CreateCheckSum(dragonCurve);
            return checkSum;
        }

        public string CreateDragonCurveOfWidth(int width, string input)
        {
            while (input.Length < width)
            {
                input += "0" + new string(input.ToCharArray().Reverse().ToArray()).Replace('0', '2').Replace('1', '0').Replace('2', '1').ToString();
            }
            input = input.Substring(0, width);
            return input;
            /*
            string dragonCurve = input;

            do
            {
                string copy = dragonCurve;
                string reverse = "";
                foreach (char c in copy.Reverse())
                {
                    if (c == '1')
                        reverse += "0";
                    else
                        reverse += "1";
                }

                dragonCurve = dragonCurve + "0" + reverse;
            } while (dragonCurve.Length <= width);

            // Truncate down to width if extra
            string truncate = dragonCurve.Substring(0, width);
            return truncate;
            */
        }

        public string CreateCheckSum(string input)
        {
            string inputForMod = input;

            while (inputForMod.Length % 2 == 0)
            {
                List<string> listString = new List<string>();
                for (int i = 0; i < inputForMod.Length; i += 2)
                {
                    if (inputForMod.Substring(i, 1) == inputForMod.Substring(i + 1, 1))
                        listString.Add("1");
                    else
                        listString.Add("0");
                }
                inputForMod = String.Join("", listString);
            }

            return inputForMod;
        }
    }
}