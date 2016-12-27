using System;

namespace AdventOfCode2016
{
    public class Coordinate
    {
        public int X;
        public int Y;
        public bool IsAvailable;
        public int GoalNumber;

        public Coordinate(char input, int x, int y)
        {
            X = x;
            Y = y;
            GoalNumber = -1;

            if (input == '#')
            {
                IsAvailable = false;
            }
            if (input == '.')
            {
                IsAvailable = true;
            }
            int attempt;
            if (Int32.TryParse(input.ToString(), out attempt))
            {
                IsAvailable = true;
                GoalNumber = attempt;
            }
        }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
            IsAvailable = true;
            GoalNumber = -1;
        }
    }
}