using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    public class DayThirteen
    {
        public static int PUZZLE_INPUT = 1352;

        private List<MazeStep> _queue = new List<MazeStep>();

        public int MinimumNumberOfStepsToCoordinates(Coordinate startCoord, int favNumber, Coordinate targetCoord)
        {
            MazeStep start = new MazeStep(startCoord, 0, new List<Coordinate>());
            _queue.Add(start);

            // Keep iterating over queue until we get a result
            do
            {
                MazeStep mazeStep = _queue[0];
                _queue.RemoveAt(0);

                // If hits are target - return
                if (mazeStep.ReachedDesintation(targetCoord))
                    return mazeStep.Step;

                // Figure out other valid paths and add them to queue while iterating step
                EvaluateOpenSteps(mazeStep, favNumber);
            } while (_queue.Any());

            return 0;
        }

        public int MaximumLocationsInNumberOfSteps(Coordinate startCoord, int favNumber, int maxSteps)
        {
            MazeStep start = new MazeStep(startCoord, 0, new List<Coordinate>());
            _queue.Add(start);

            List<Coordinate> allPlacesVisited = new List<Coordinate>();

            // Keep iterating over queue until we get through all posibilities
            do
            {
                MazeStep mazeStep = _queue[0];
                _queue.RemoveAt(0);

                // Capture places visited
                allPlacesVisited.Add(mazeStep.Coord);

                // If exceed maxSteps do not go further
                if (mazeStep.Step < maxSteps)
                {
                    // Figure out other valid paths and add them to queue while iterating step
                    EvaluateOpenSteps(mazeStep, favNumber);
                }
            } while (_queue.Any());

            // Trim down the locations for uniqueness
            var uniqueList = new HashSet<Coordinate>(allPlacesVisited, new CoordinateEqualityComparer());
            return uniqueList.Count;
        }

        private void EvaluateOpenSteps(MazeStep mazeStep, int favNumber)
        {
            Coordinate north = new Coordinate(mazeStep.Coord.X, mazeStep.Coord.Y - 1);
            if (IsOpenSpace(north, favNumber) && mazeStep.HaveAlreadyBeenToCoordinate(north) == false)
            {
                List<Coordinate> previous = mazeStep.ClonePreviousCoords();
                previous.Add(mazeStep.Coord);
                MazeStep northStep = new MazeStep(north, mazeStep.Step + 1, previous);
                _queue.Add(northStep);
            }
            Coordinate east = new Coordinate(mazeStep.Coord.X + 1, mazeStep.Coord.Y);
            if (IsOpenSpace(east, favNumber) && mazeStep.HaveAlreadyBeenToCoordinate(east) == false)
            {
                List<Coordinate> previous = mazeStep.ClonePreviousCoords();
                previous.Add(mazeStep.Coord);
                MazeStep eastStep = new MazeStep(east, mazeStep.Step + 1, previous);
                _queue.Add(eastStep);
            }
            Coordinate south = new Coordinate(mazeStep.Coord.X, mazeStep.Coord.Y + 1);
            if (IsOpenSpace(south, favNumber) && mazeStep.HaveAlreadyBeenToCoordinate(south) == false)
            {
                List<Coordinate> previous = mazeStep.ClonePreviousCoords();
                previous.Add(mazeStep.Coord);
                MazeStep southStep = new MazeStep(south, mazeStep.Step + 1, previous);
                _queue.Add(southStep);
            }
            Coordinate west = new Coordinate(mazeStep.Coord.X - 1, mazeStep.Coord.Y);
            if (IsOpenSpace(west, favNumber) && mazeStep.HaveAlreadyBeenToCoordinate(west) == false)
            {
                List<Coordinate> previous = mazeStep.ClonePreviousCoords();
                previous.Add(mazeStep.Coord);
                MazeStep westStep = new MazeStep(west, mazeStep.Step + 1, previous);
                _queue.Add(westStep);
            }
        }

        public bool IsOpenSpace(Coordinate coord, int favNumber)
        {
            int x = coord.X;
            int y = coord.Y;

            // Cannot be negative
            if (x < 0 || y < 0)
                return false;

            int calc = ((x * x) + (3 * x) + (2 * x * y) + y + (y * y)) + favNumber;

            string byteRepresentation = Convert.ToString(calc, 2);
            List<char> chars = byteRepresentation.ToList<char>();

            int numOnes = 0;
            foreach (char c in chars)
            {
                if (c == '1')
                    numOnes++;
            }

            return (numOnes % 2 == 0);
        }
    }

    public class MazeStep
    {
        public Coordinate Coord;
        public int Step;
        public List<Coordinate> PreviousCoords;

        public MazeStep(Coordinate coord, int step, List<Coordinate> previousCoords)
        {
            Coord = coord;
            Step = step;
            PreviousCoords = previousCoords;
        }

        public bool ReachedDesintation(Coordinate targetCoord)
        {
            return (Coord.X == targetCoord.X && Coord.Y == targetCoord.Y);
        }

        public bool HaveAlreadyBeenToCoordinate(Coordinate coord)
        {
            Coordinate match = PreviousCoords.Find(p => p.X == coord.X && p.Y == coord.Y);
            return match != null;
        }

        public List<Coordinate> ClonePreviousCoords()
        {
            List<Coordinate> newList = new List<Coordinate>();
            foreach (Coordinate coord in PreviousCoords)
            {
                newList.Add(coord);
            }
            return newList;
        }
    }

    public class Coordinate
    {
        public int X;
        public int Y;

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class CoordinateEqualityComparer : IEqualityComparer<Coordinate>
    {
        public bool Equals(Coordinate c1, Coordinate c2)
        {
            if (c2 == null && c1 == null)
                return true;
            else if (c1 == null | c2 == null)
                return false;
            else if (c1.X == c2.X && c1.Y == c2.Y)
                return true;
            else
                return false;
        }

        public int GetHashCode(Coordinate c)
        {
            int hCode = c.X ^ c.Y;
            return hCode.GetHashCode();
        }
    }
}