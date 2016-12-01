using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2016
{
    public class DayOne
    {
        public static string PUZZLE_INPUT = "L5, R1, R3, L4, R3, R1, L3, L2, R3, L5, L1, L2, R5, L1, R5, R1, L4, R1, R3, L4, L1, R2, R5, R3, R1, R1, L1, R1, L1, L2, L1, R2, L5, L188, L4, R1, R4, L3, R47, R1, L1, R77, R5, L2, R1, L2, R4, L5, L1, R3, R187, L4, L3, L3, R2, L3, L5, L4, L4, R1, R5, L4, L3, L3, L3, L2, L5, R1, L2, R5, L3, L4, R4, L5, R3, R4, L2, L1, L4, R1, L3, R1, R3, L2, R1, R4, R5, L3, R5, R3, L3, R4, L2, L5, L1, L1, R3, R1, L4, R3, R3, L2, R5, R4, R1, R3, L4, R3, R3, L2, L4, L5, R1, L4, L5, R4, L2, L1, L3, L3, L5, R3, L4, L3, R5, R4, R2, L4, R2, R3, L3, R4, L1, L3, R2, R1, R5, L4, L5, L5, R4, L5, L2, L4, R4, R4, R1, L3, L2, L4, R3";

        // Travels the city grid based on instructions and determines the distance traveled
        public int DetermineDistanceTraveled(string input)
        {
            Position origin = new Position();
            Position traveled = new Position();

            // Parse instructions from input
            List<string> instructions = input.Split(',').ToList<string>();

            // Follow the instructions
            foreach (string instruction in instructions)
            {
                // Parse instructions - come in as L# or R#
                string trimmedInstruction = instruction.Trim();
                string turn = trimmedInstruction.Substring(0, 1);
                int distance = Int32.Parse(trimmedInstruction.Substring(1));
                traveled.Move(turn, distance);
            }

            return traveled.CompareLocation(origin);
        }

        // Look for first duplicate location and return its distance.
        // This includes all of the incremental blocks visited.
        public int DetermineFirstRepeatLocation(string input)
        {
            Position origin = new Position();
            List<Position> positionsTraveled = new List<Position> { origin };

            // Parse instructions from input
            List<string> instructions = input.Split(',').ToList<string>();

            // Follow the instructions
            foreach (string instruction in instructions)
            {
                // Parse instructions - come in as L# or R#
                string trimmedInstruction = instruction.Trim();
                string turn = trimmedInstruction.Substring(0, 1);
                int distance = Int32.Parse(trimmedInstruction.Substring(1));

                // Cover each incremental step
                for (int i = 1; i <= distance; i++)
                {
                    // Only use the turn the first time
                    string turnToUse = i == 1 ? turn : "S";

                    Position lastPosition = positionsTraveled[positionsTraveled.Count - 1].Copy();

                    lastPosition.Move(turnToUse, 1);

                    // Determine if we have been there before
                    foreach (Position position in positionsTraveled)
                    {
                        if (lastPosition.vertical == position.vertical && lastPosition.horizontal == position.horizontal)
                        {
                            return lastPosition.CompareLocation(origin);
                        }
                    }

                    // Otherwise, add it to the list
                    positionsTraveled.Add(lastPosition);
                }
            }

            // If no duplicate positions, return 0
            return 0;
        }
    }

    public class Position
    {
        public int horizontal;
        public int vertical;

        // 1 = North, 2 = East, 3 = South, 4 = West
        public int heading;

        public Position()
        {
            horizontal = 0;
            vertical = 0;
            heading = 1;
        }

        // Moves the position object one instruction
        public void Move(string turn, int distance)
        {
            // Adjust heading
            if (turn == "L")
            {
                heading = HandleHeadingOverride(-1, heading);
            }
            else if (turn == "R")
            {
                heading = HandleHeadingOverride(1, heading);
            }
            else if (turn == "S")
            {
                // do nothing as go straight
            }
            else
            {
                throw new ArgumentException("The turn was neither L or R");
            }

            // Adjust actual position
            if (heading == 1)
            {
                vertical += distance;
            }
            if (heading == 2)
            {
                horizontal += distance;
            }
            if (heading == 3)
            {
                vertical -= distance;
            }
            if (heading == 4)
            {
                horizontal -= distance;
            }
        }

        // Returns a unit measure of the spatial difference between two positions
        public int CompareLocation(Position origin)
        {
            int vertDifference = vertical - origin.vertical;
            int horzDifference = horizontal - origin.horizontal;

            return Math.Abs(vertDifference) + Math.Abs(horzDifference);
        }

        // Returns a copy of the current Position object
        public Position Copy()
        {
            Position newPosition = new Position();
            newPosition.heading = heading;
            newPosition.vertical = vertical;
            newPosition.horizontal = horizontal;

            return newPosition;
        }

        // Handle the fact that there are only 4 directions
        private int HandleHeadingOverride(int change, int currentHeading)
        {
            int newHeading = currentHeading + change;
            if (newHeading > 4)
            {
                return 1;
            }
            if (newHeading <= 0)
            {
                return 4;
            }
            return newHeading;
        }
    }
}