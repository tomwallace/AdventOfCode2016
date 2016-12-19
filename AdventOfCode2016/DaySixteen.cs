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
        }

        public string CreateCheckSum(string input)
        {
            string inputForMod = input;
            string checkSum = "";

            do
            {
                checkSum = "";
                for (int i = 0; i < inputForMod.Length; i++)
                {
                    if (inputForMod[i] == inputForMod[i + 1])
                        checkSum += "1";
                    else
                        checkSum += "0";

                    i++;
                }
                inputForMod = checkSum;
            } while (inputForMod.Length % 2 == 0);

            return checkSum;
        }
    }
}