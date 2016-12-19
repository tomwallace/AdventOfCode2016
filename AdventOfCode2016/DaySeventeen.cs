using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace AdventOfCode2016
{
    public class DaySeventeen
    {
        public static string PUZZLE_INPUT = "ioramepc";
        public static List<char> VALID_CHARS = new List<char>() { 'b', 'c', 'd', 'e', 'f' };

        public List<StepInGrid> _queue = new List<StepInGrid>();

        public string FindShortestPathThroughGrid(string seed, int rows, int cols)
        {
            MD5 md5Hash = MD5.Create();
            StepInGrid firstLocation = new StepInGrid(seed, 0, 0, 0);
            _queue.Add(firstLocation);

            do
            {
                // Pop off queue
                StepInGrid location = _queue[0];
                _queue.RemoveAt(0);

                if (location.X == rows && location.Y == cols)
                    return location.CurrentPasscode.Substring(seed.Length);

                ProcessOpenings(location, md5Hash, rows, cols);
            } while (1 == 1);

            return "";
        }

        public int FindLongestPathThroughGrid(string seed, int rows, int cols)
        {
            MD5 md5Hash = MD5.Create();
            StepInGrid firstLocation = new StepInGrid(seed, 0, 0, 0);
            _queue.Add(firstLocation);

            List<string> AllAnswers = new List<string>();

            do
            {
                // Pop off queue
                StepInGrid location = _queue[0];
                _queue.RemoveAt(0);

                if (location.X == rows && location.Y == cols)
                    AllAnswers.Add(location.CurrentPasscode.Substring(seed.Length));
                else
                {
                    ProcessOpenings(location, md5Hash, rows, cols);
                }
            } while (_queue.Any());

            var sortedDescending = AllAnswers.OrderByDescending(x => x.Length).ToList();
            return sortedDescending[0].Length;
        }

        // Creates a series of characters that follow compass - [0] = North, [1] = South, [2] = Left, [3] = East
        public List<char> OpenDoorsForRoom(string passcode, MD5 md5Hash)
        {
            List<char> result = new List<char>();

            string hash = Md5Utility.GetMd5Hash(md5Hash, passcode);
            List<char> dirs = hash.Substring(0, 4).ToList<char>();

            for (int i = 0; i < 4; i++)
            {
                char dir = dirs[i];
                if (VALID_CHARS.Contains(dir))
                    result.Add('O');
                else
                    result.Add('C');
            }

            return result;
        }

        private void ProcessOpenings(StepInGrid location, MD5 md5Hash, int rows, int cols)
        {
            List<char> openings = OpenDoorsForRoom(location.CurrentPasscode, md5Hash);
            if (openings[0] == 'O' && location.X >= 1)
            {
                StepInGrid north = new StepInGrid(location.CurrentPasscode + 'U', location.X - 1, location.Y, location.Step + 1);
                _queue.Add(north);
            }
            if (openings[3] == 'O' && location.Y < cols)
            {
                StepInGrid east = new StepInGrid(location.CurrentPasscode + 'R', location.X, location.Y + 1, location.Step + 1);
                _queue.Add(east);
            }
            if (openings[1] == 'O' && location.X < rows)
            {
                StepInGrid south = new StepInGrid(location.CurrentPasscode + 'D', location.X + 1, location.Y, location.Step + 1);
                _queue.Add(south);
            }
            if (openings[2] == 'O' && location.Y >= 1)
            {
                StepInGrid west = new StepInGrid(location.CurrentPasscode + 'L', location.X, location.Y - 1, location.Step + 1);
                _queue.Add(west);
            }
        }
    }

    public class StepInGrid
    {
        public string CurrentPasscode;
        public int X;
        public int Y;
        public int Step;

        public StepInGrid(string currentPasscode, int x, int y, int step)
        {
            CurrentPasscode = currentPasscode;
            X = x;
            Y = y;
            Step = step;
        }
    }
}