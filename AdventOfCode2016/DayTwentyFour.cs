using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2016
{
    public class DayTwentyFour
    {
        public static string PUZZLE_INPUT =
            @"#########################################################################################################################################################################################
#.#.......#.#.#.....#.#.......#.................#.......#.#.....#.....#...#...#.......#...#...........#.#.....#.............#.........#.............#.........#.....#.#.............#...#
#.#####.#.#.#.#.#.#.#.#.#.###.#.#.###.#.#.###.###.#.#.#.#.#.#####.#.#.###.#.#.###.#.#.###.###.#.###.###.###.#.#.###.#.#.#.#.#.#.###.#.###.#.#.#.#.#.#.#.#.#.#.#.#.#.#.#.###.#####.#.###.#
#.....#.............#...#....6#.....#.....#.#...#.....#...#.........#.......#...#.#.....#.....#.#...#...#.....#.#.......#.........#...#...#.#.#.......#.........#.....#...#.#.#.#.....#.#
#####.#.###.###.#.#.#.#####.#.#####.#.#####.#.#######.#.#.#.#.#.#####.#####.#.#########.#.###.#.#.#.#.#.#.#.#######.#.#.#####.###.###.###.#.#.###.#.#.#.#.#.#.#.#.###########.#.#.#####.#
#.....#.......#.#.....#.......#.#...#.#.#.#...........#.....#.#.#...#.#...#.#.#.....#...#.....#.....#...............#.......#.#.........#.#...........#.....#...#.......#.#...#.#.....#.#
###.#.#.#.#####.#####.#.#.#.#.#.#.#.#.#.#.#########.#.#########.#.#.###.###.###.###.#.#.#.#.#.#.#.#######.#.#.###.#.###.#.#.#.#.#.#.#######.#.#.#.###.#.#.#.###.###.#.#.#.#.#.###.#.#####
#...#...#.#.....#.............#...#...#...#.#.......#.#.#...#...#.#.#...#.....#.#.#.....#.#...#.#.......#.#.#...#.......#.....#.....#.......#...#...#.#...#.....#.#.......#.#.#...#...#.#
#.#.#####.#.###.###.#.#########.#.#.#.###.#.#.#.#.#.#.#.#.#.#.#.#.#.###.#.#.#.###.#.#.#.#.#######.#.#.###.#.###.###.#.#.#.#####.#####.#####.#.#.#.#.#.###.#.#.###.#.#####.#.#####.#.###.#
#...#.#...#.....#.#.........#.#.....#...#.....#...#...#...#...#...#.........#.......#...#.#.....#...#.#...#.#.......#.........#...#.#...#...#2..#.#.#.#...#.......#...#.#...........#...#
#.###.#####.#####.#.#.###.###.#.###.#.#.#.#.###.#.#.###.#.#.#.###.#.#.#####.#.#####.#.###.#.#.#.#.###.#.#.#.###.#.#.#.#####.#.#.#.#.#.###.#####.#.#.#.#.#.#####.###.#.#.#.#.#.#.#####.#.#
#...#.#.#4#.#.........#.......#...........#.#...#...#...#.........#.......#.....#...#...#.#...#...#...#.#...#.........#.....#...#.....#.........#...#...............#.#.#...#.........#.#
#######.#.#.###.###.###.###.#.#####.#####.#.#.###.#.#.#########.#####.#.#####.#.#.#.###.#.#.###.#.#.#.#.#.#.#.#####.#.#####.#.#.#.#.#.#.#.#.#.###.#.#######.#####.#.#.#.#.#.#.###.#.#####
#.........#.#.....#.....#...................#.....#...#.........#.....#.#.....#.#...........#...#...#.........#...#...#.....#...#.#.#.#.....#.......#.#3....#.......#.....#.#.#.....#...#
#.#####.###.#.###.#####.#.###.###.###.#.#####.#.#.###.###.#.###.#.#.#.###.#.###.#.###.#.#####.#.###.###.#######.#.#.#.#.###.#.#.#.#########.#.###.###.###.#.#.###.#.#######.###.#.#.#.#.#
#...#...#.........#...#.......#...#...#...#.........#.....#.....#.....#...#.......#...#...#...#.#.#.#...#.................#.............................#...#.....#.....#.#.....#.....#.#
#.#.#.#.#####.###.#.#.#.#.###.###.###.#.###.#.#.#####.###.#.###.#.#.###.#.#.#####.###.#.#.###.#.#.#.###.#.#.###.#####.#.###.###.#.#.#.#.#.#.###.#.#.#.#.#.###.###.#.#.#.#.#####.#####.#.#
#...#.......#...#.....#...#.#.#.#.#...#.#...#.....#.#.#.....#.....#.......#.#.......#.........#.....#...#...#...#.#.........#.#.#.....#.#...#...#.....#...#.......#.........#.....#...#.#
###.#.#.#.#.#####.###.#####.#.#.#.#.###.#####.###.#.#.#.#####.#.#.#.#.#.#.###.#.#.###.#.#.###.#.#.###.#.#.###.###.#.#.#.#.#.#.#.#.#####.#.#.#.###.#.#.#.###.###.###.###.###.#.#.#####.#.#
#7#.......#...#...#...#...#.......#.#.........#.#.......#.....#...#.....#.#...#...#...#.#.#...#.#.......#.....#.#.#.....#...#...#...#.....#.....#.#.#.#.#...#...#...#.#.......#.....#...#
#.#.#.#.#.#.#######.#.#.#.#####.#.###.###.#.###.#.###.#.###.#.#######.###.#.#.#.#.#####.###.###.#####.#.#####.#.###.#####.#.#.#.###.#.#######.#.#.###.#.###.#####.#.#.#.#.###.###.###.#.#
#.......#...#.#.....#.#.....#.#...#.......#...#.......#.#.....#.........#.#.#.....#.........#.#.#...............#...#.....#...#.#...#.......#.#...........#...#.#.#.#.#.#.....#...#.....#
#.#.#.#######.#.###.#.#.###.#.#.#.#.#####.#.#.#.#.#.#.#.#.#.#.#.#######.#####.###.#.#####.###.#####.#.#.###.#.###.#.#.###.#.###.#.#.#.#.#.###.###.#.###.#.#.#.#.#.#.###.#.#.#.#.#.#.#.#.#
#.....#.#...#.#.....#...........#...#.#.....#.#.......#.....#.#...#...........#.....#.........#...#.#.#.#.#.#.....#...#.#.............#.....#.#.#.#.#.#.#.#.#.....#.#.#.#...........#...#
#####.#.###.#.#.#.#.#.###.#.#.#.###.#.#.#######.#####.###.#.#.#.#.#.#.#.#.#.###.#.#####.#.#######.#.#####.#.#.#########.#########.#.#.###.###.#.#####.#.###.###.#.#.#.#.#.#.#.#######.#.#
#.....#...#.#.......#...........#...#.#.....#.#.......#.#...#.#...#.......#...#.......#...#.........#...#.........................#...#...#...#.#.#...#.#.........#...#...#...#...#...#.#
#.#.#.#.#.#.#####.#.#.#########.#.#####.#.#.#.#.#.###.#.#.#.#.###.#.#.#.#.#.#.###.#.#######.###.#.#.#.#######.#.###.#####.###.#.#.#####.#.#.#####.#######.#.#.###.###.#.#.#.#.#.###.###.#
#.#...#...........#.#.......#...#.#.............#.......#...#.....#.#.....#...#.....#.......#...#.#.#...#...#.#...#.#.....#...#...#...#.....#.....#...#.....#.......#.....#.#.#.#0#.....#
###.#.#.#.#.#.#######.#.###.###.#.#.###.#.#######.#.###.#########.#.#.#.#.###.#.###.###########.#.###.###.#.#.###.#.#.###.#.#.###.###.#.###.#.###########.###.#.###.#####.#.#.#.#.#.#.#.#
#.#...#.#.#...#.........#...#.......#.#.................#.#...........#.....#.......#.....#.#.#.#.#...#.....#...#...#.#.........#.#.....#.#...#.....#.....#.#...#.#...#.......#.#.....#.#
#.###.#.#.#.#.#.#.#.#.#.#.#.#.###.#.#.#.#.#####.#.#####.#.###.#.#.###.#.###.###.###.#.#####.#.#.#######.#.#####.###.###.#######.###.#####.#.#.#.#.#.#.#.#.#.###.#.#.#.#.#.###.#.#.#.#.#.#
#.#...#.........#.#...#...........#.#.....#5........#...#.....#.......#.#...#.......#.........#.......#.........#.#.#.......#...#.#...#.#.#.....#...#.#.#.#.......#.#.....#...#.#.....#.#
###.###.#.#####.###.###.###.#.#.###.#.#.#####.###.#.#.#.#.###.#####.#.#.#.#.#.#.#.###.#.###.#.###.#.#.#.#.###.#.#.#.#######.#.###.#.#.#.#.###.###.#.#.#.#.#.#######.#.#.#.#####.###.#.#.#
#...#...........#...#...#.#.......#.....#.#.#.#...............#.....#.....#...#.#.#...#.#...#.#.....#...#.#...#...#.#.#.......#...#.#...#.......#...#.......#.......#.#...#.#.....#.....#
#.#.#.###.#.#.#######.###.#####.#.#######.#.###.#######.#.###.###.#.#.#####.#.###.#.#.#.#.###.###.#.#.#.###.#.#.###.#.###.#########.###.#.#.#####.#.#####.###.#.#.#.###.#.#.#####.#######
#...#.................#.....#.....#...#...#.#...#...#.....#.......#.#...#...#.....#.....#.........#...#.....#.........#...#.....#...#.......#1..#.#.#.#...#...#.#.......#.#...#.......#.#
#.#.#.#####.#.#.###.###.###.#####.#.#.#####.#.#.#.#####.#.###.###.#.###.#.#.#.###.#.#.#.#.#.#.#.#.#.#.#.###.#######.#.#.#####.###.#######.#.#.#.#.#.#.#.###.#.#.#.#####.#.#######.#.#.#.#
#.....#.....#.#...............#.#...#.....#.................#...#.#...#.#...#.....#.#...#.........#...........#.#.......#.....#.#.....#.....#.......#...........#...#.....#.#.......#.#.#
#.#.#.#.#.#.#.#######.###.###.#.#.#.#.#.#.###.###.#.#.###.#.#.#.#.#.#.#####.#.#.#.#.###.#.#.#######.#.#.#.###.#.#.#.#.###.#.#.#.#.#.#.#.#####.#.#.#.#.#####.#####.###.###.#.#.#.#.#.#.#.#
#...#.#...#.#.......#.......#.....#...#.......#...#...#...#.....#.#.....#...#.#...#.....#.#.........#.#.#.....#.....#...#.........#.#.#.......#.........#...#.....#.#...#.#...#.....#...#
#########################################################################################################################################################################################";

        public List<List<Coordinate>> _maze;

        public int CountOfMinimumStepsNeededForGoals(string input, bool includeStartingPoint)
        {
            _maze = InitializeMaze(input);
            List<Coordinate> goalCells = new List<Coordinate>();
            foreach (List<Coordinate> row in _maze)
            {
                foreach (Coordinate cell in row)
                {
                    if (cell.GoalNumber >= 0)
                        goalCells.Add(cell);
                }
            }

            List<PairDistance> distances = new List<PairDistance>();

            var allPairs = CombinationUtility.GetAllPermutationPairsOrderDoesNotMatter(goalCells);
            foreach (var pair in allPairs)
            {
                PairDistance pairDistance = new PairDistance();
                Coordinate from = pair.Item1;
                Coordinate to = pair.Item2;
                int distance = NumberOfStepsToTarget(from, to);

                pairDistance.From = from.GoalNumber;
                pairDistance.To = to.GoalNumber;
                pairDistance.Steps = distance;
                distances.Add(pairDistance);
            }

            int smallestDistance = GetMinimumDistanceAsTravelingSalesmanProblem(distances, goalCells, includeStartingPoint);

            return smallestDistance;
        }

        public int GetMinimumDistanceAsTravelingSalesmanProblem(List<PairDistance> distances, List<Coordinate> goalCells, bool includeStartingPoint)
        {
            List<int> totalDistances = new List<int>();
            Queue<DistanceState> queue = new Queue<DistanceState>();
            List<int> goalPoints = new List<int>();
            foreach (Coordinate cell in goalCells)
            {
                if (cell.GoalNumber != 0)
                    goalPoints.Add(cell.GoalNumber);
            }

            DistanceState initialState = new DistanceState()
            {
                CurrentPointer = 0,
                GoalCellsRemaining = goalPoints,
                TotalDistance = 0
            };
            queue.Enqueue(initialState);
            while (queue.Count > 0)
            {
                DistanceState currentState = queue.Dequeue();

                if (currentState.GoalCellsRemaining.Count == 0)
                {
                    int totalDistance = currentState.TotalDistance;
                    if (includeStartingPoint)
                    {
                        int distanceBackToStart =
                            distances.Find(
                                d =>
                                    (d.To == 0 && d.From == currentState.CurrentPointer) ||
                                    (d.From == 0 && d.To == currentState.CurrentPointer)).Steps;
                        totalDistance += distanceBackToStart;
                    }

                    totalDistances.Add(totalDistance);
                }
                else
                {
                    foreach (int goalCell in currentState.GoalCellsRemaining)
                    {
                        int matchingDistance =
                            distances.Find(
                                d =>
                                    (d.To == goalCell && d.From == currentState.CurrentPointer) ||
                                    (d.From == goalCell && d.To == currentState.CurrentPointer)).Steps;
                        List<int> newGoalCellsRemaining = currentState.CloneAndRemoveGoalCellsRemaining(goalCell);
                        DistanceState newState = new DistanceState()
                        {
                            CurrentPointer = goalCell,
                            GoalCellsRemaining = newGoalCellsRemaining,
                            TotalDistance = currentState.TotalDistance + matchingDistance
                        };
                        queue.Enqueue(newState);
                    }
                }
            }

            totalDistances.Sort();

            return totalDistances[0];
        }

        public int NumberOfStepsToTarget(Coordinate startCoord, Coordinate targetCoord)
        {
            Queue<MazeStep> queue = new Queue<MazeStep>();
            MazeStep start = new MazeStep(startCoord, 0, null);
            List<Coordinate> allPreviousCoordinates = new List<Coordinate>();
            queue.Enqueue(start);

            // Keep iterating over queue until we get a result
            do
            {
                MazeStep currentState = queue.Dequeue();

                // If hits are target - return
                if (currentState.ReachedDesintation(targetCoord))
                    return currentState.Step;

                // Figure out other valid paths and add them to queue while iterating step
                EvaluateOpenSteps(currentState, queue, allPreviousCoordinates);
                Debug.WriteLine($"prevCoord: {allPreviousCoordinates.Count} queue: {queue.Count}.");
            } while (queue.Any());

            return 0;
        }

        private void EvaluateOpenSteps(MazeStep mazeStep, Queue<MazeStep> queue, List<Coordinate> allPreviousCoordinates)
        {
            if (HaveNotAlreadyBeenToCoordinate(mazeStep.Coord, allPreviousCoordinates) == true)
            {
                allPreviousCoordinates.Add(mazeStep.Coord);
                Coordinate north = new Coordinate(mazeStep.Coord.X, mazeStep.Coord.Y - 1);
                if (IsOpenSpace(north) == true && HaveNotAlreadyBeenToCoordinate(north, allPreviousCoordinates) == true)
                {
                    MazeStep northStep = new MazeStep(north, mazeStep.Step + 1, null);
                    queue.Enqueue(northStep);
                }
                Coordinate east = new Coordinate(mazeStep.Coord.X + 1, mazeStep.Coord.Y);
                if (IsOpenSpace(east) == true && HaveNotAlreadyBeenToCoordinate(east, allPreviousCoordinates) == true)
                {
                    MazeStep eastStep = new MazeStep(east, mazeStep.Step + 1, null);
                    queue.Enqueue(eastStep);
                }
                Coordinate south = new Coordinate(mazeStep.Coord.X, mazeStep.Coord.Y + 1);
                if (IsOpenSpace(south) == true && HaveNotAlreadyBeenToCoordinate(south, allPreviousCoordinates) == true)
                {
                    MazeStep southStep = new MazeStep(south, mazeStep.Step + 1, null);
                    queue.Enqueue(southStep);
                }
                Coordinate west = new Coordinate(mazeStep.Coord.X - 1, mazeStep.Coord.Y);
                if (IsOpenSpace(west) == true && HaveNotAlreadyBeenToCoordinate(west, allPreviousCoordinates) == true)
                {
                    MazeStep westStep = new MazeStep(west, mazeStep.Step + 1, null);
                    queue.Enqueue(westStep);
                }
            }
        }

        public bool HaveNotAlreadyBeenToCoordinate(Coordinate coord, List<Coordinate> allPreviousCoordinates)
        {
            bool contains = allPreviousCoordinates.Contains(coord, new CoordinateEqualityComparer());
            return contains == false;
        }

        public bool IsOpenSpace(Coordinate targetCoord)
        {
            int x = targetCoord.X;
            int y = targetCoord.Y;

            // Cannot be negative or outside range of _maze
            if (x < 0 || y < 0 || x > _maze[0].Count || y > _maze.Count)
                return false;

            Coordinate coord = _maze[y][x];
            return coord.IsAvailable;
        }

        public List<List<Coordinate>> InitializeMaze(string input)
        {
            List<List<Coordinate>> maze = new List<List<Coordinate>>();

            int y = 0;
            List<string> lineInputs =
                input.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            foreach (string lineInput in lineInputs)
            {
                List<Coordinate> row = new List<Coordinate>();
                int x = 0;
                foreach (char c in lineInput)
                {
                    Coordinate coord = new Coordinate(c, x, y);
                    row.Add(coord);
                    x++;
                }
                maze.Add(row);
                y++;
            }

            return maze;
        }
    }

    public class DistanceState
    {
        public int TotalDistance;
        public List<int> GoalCellsRemaining;
        public int CurrentPointer;

        public List<int> CloneAndRemoveGoalCellsRemaining(int goalCell)
        {
            // Have to clone the list
            List<int> list = new List<int>();
            foreach (int cell in GoalCellsRemaining)
            {
                if (cell != goalCell)
                    list.Add(cell);
            }
            return list;
        }
    }

    public class PairDistance
    {
        public int From;
        public int To;
        public int Steps;
    }
}