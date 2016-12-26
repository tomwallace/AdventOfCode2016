using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2016
{
    public class DayTwentyFour
    {
        public static string PUZZLE_INPUT = @"#########################################################################################################################################################################################
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

        public Queue<MazeState> _queue = new Queue<MazeState>();

        public int CountOfMinimumStepsNeededForGoals(string input)
        {
            List<List<MazeCell>> maze = InitializeMaze(input);
            MazeCell currentCell = null;
            List<MazeCell> goalCells = new List<MazeCell>();
            foreach (List<MazeCell> row in maze)
            {
                foreach (MazeCell cell in row)
                {
                    //if (cell.TargetNumber == 0)
                    //    currentCell = cell;

                    if (cell.TargetNumber >= 0)
                        goalCells.Add(cell);
                }
            }
            /*
            int totalDistance = 0;

            while (goalCells.Count > 0)
            {
                int minDistance = 10000000;
                MazeCell minDistanceCell = null;
                foreach (MazeCell targetCell in goalCells)
                {
                    int distance = NumberOfStepsToTarget(currentCell, targetCell);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        minDistanceCell = targetCell;
                    }
                }

                totalDistance += minDistance;
                goalCells.Remove(minDistanceCell);
            }

            return totalDistance;
            */

            List<PairDistance> distances = new List<PairDistance>();

            var allPairs = CombinationUtility.GetAllPermutationPairsOrderDoesNotMatter(goalCells);
            foreach (var pair in allPairs)
            {
                PairDistance pairDistance = new PairDistance();
                MazeCell from = pair.Item1;
                MazeCell to = pair.Item2;
                int distance = NumberOfStepsToTarget(from, to);
                pairDistance.From = from.TargetNumber;
                pairDistance.To = to.TargetNumber;
                pairDistance.Steps = distance;
                distances.Add(pairDistance);
            }

            int smallestDistance = GetMinimumDistanceAsTravelingSalesmanProblem(distances, goalCells);

            return smallestDistance;

            //var allCombos
            /*
            var allPairs = CombinationUtility.GetAllPermutationsToLength(goalCells, 2);
            foreach (var pair in allPairs)
            {
                PairDistance pairDistance = new PairDistance();
                MazeCell from = pair.ToList()[0];
                MazeCell to = pair.ToList()[1];
                int distance = NumberOfStepsToTarget(from, to);
                pairDistance.From = from.TargetNumber;
                pairDistance.To = to.TargetNumber;
                pairDistance.Steps = distance;
                distances.Add(pairDistance);
            }
            */
            /*
            MazeState initialState = new MazeState(0, start, new List<MazeCell>(), goalCells);
            _queue.Enqueue(initialState);

            // Loop
            while (_queue.Count > 0)
            {
                MazeState currentState = _queue.Dequeue();

                // We did it!
                if (currentState.GoalsRemaining.Count == 0)
                    return currentState.Step;

                foreach (MazeCell newCell in currentState.Position.Connected)
                {
                    // Only proceed if we have not been there before
                    if (currentState.TraveledPositions.Contains(newCell))
                        continue;

                    if (currentState.GoalsRemaining.Contains(newCell))
                    {
                        // Remove the TargetNumber cell as we got it!
                        List<MazeCell> newRemaining = currentState.CloneAndSubtractGoalsRemaining(newCell);
                        // Reset the positions we have traveled, because we may have to backtrack
                        MazeState newState = new MazeState(currentState.Step + 1, newCell, new List<MazeCell>(),
                            newRemaining);
                        _queue.Enqueue(newState);
                    }
                    else
                    {
                        List<MazeCell> newList = currentState.CloneAndAddToTraveledPositions(currentState.Position);
                        MazeState newState = new MazeState(currentState.Step + 1, newCell, newList, currentState.GoalsRemaining);
                        _queue.Enqueue(newState);
                    }
                }
            }
            */

            //return 0;
        }

        public int GetMinimumDistanceAsTravelingSalesmanProblem(List<PairDistance> distances, List<MazeCell> goalCells)
        {
            List<int> totalDistances = new List<int>();
            Queue<DistanceState> queue = new Queue<DistanceState>();
            List<int> goalPoints = new List<int>();
            foreach (MazeCell cell in goalCells)
            {
                if (cell.TargetNumber != 0)
                    goalPoints.Add(cell.TargetNumber);
            }

            DistanceState initialState = new DistanceState() { CurrentPointer = 0, GoalCellsRemaining = goalPoints, TotalDistance = 0 };
            queue.Enqueue(initialState);
            while (queue.Count > 0)
            {
                DistanceState currentState = queue.Dequeue();

                if (currentState.GoalCellsRemaining.Count == 0)
                    totalDistances.Add(currentState.TotalDistance);
                else
                {
                    foreach (int goalCell in currentState.GoalCellsRemaining)
                    {
                        int matchingDistance = distances.Find(d => (d.To == goalCell && d.From == currentState.CurrentPointer) || (d.From == goalCell && d.To == currentState.CurrentPointer)).Steps;
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

        public int GetMinimumDistance(List<int> distances, int numberGoals)
        {
            List<int> totals = new List<int>();
            var allSets = CombinationUtility.GetAllPermutationsToLength(distances, numberGoals);
            foreach (var s in allSets)
            {
                int total = 0;
                foreach (int i in s)
                {
                    total += i;
                }
                totals.Add(total);
            }

            totals.Sort();
            return totals[0];
        }

        public int NumberOfStepsToTarget(MazeCell start, MazeCell target)
        {
            Queue<MazeState> queue = new Queue<MazeState>();
            MazeState initialState = new MazeState(0, start, new List<MazeCell>());
            queue.Enqueue(initialState);

            // Loop
            while (queue.Count > 0)
            {
                MazeState currentState = queue.Dequeue();

                foreach (MazeCell newCell in currentState.Position.Connected)
                {
                    // We did it!
                    if (newCell == target)
                        return currentState.Step + 1;

                    // Only proceed if we have not been there before
                    if (currentState.TraveledPositions.Contains(newCell))
                        continue;

                    List<MazeCell> newList = currentState.CloneAndAddToTraveledPositions(currentState.Position);
                    MazeState newState = new MazeState(currentState.Step + 1, newCell, newList);
                    queue.Enqueue(newState);
                }
            }

            return 0;
        }

        public List<List<MazeCell>> InitializeMaze(string input)
        {
            List<List<MazeCell>> maze = new List<List<MazeCell>>();

            int y = 0;
            List<string> lineInputs = input.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            foreach (string lineInput in lineInputs)
            {
                List<MazeCell> row = new List<MazeCell>();
                int x = 0;
                foreach (char c in lineInput.ToCharArray())
                {
                    MazeCell cell = new MazeCell(c, x, y);
                    row.Add(cell);
                    x++;
                }
                maze.Add(row);
                y++;
            }

            // Create linkages so we can iterate faster
            y = 0;
            foreach (List<MazeCell> row in maze)
            {
                int x = 0;
                foreach (MazeCell cell in row)
                {
                    if (cell.IsOpen)
                    {
                        // Check neighbors
                        // North
                        if (y > 0 && maze[y - 1][x].IsOpen)
                            cell.Connected.Add(maze[y - 1][x]);

                        // East
                        if (x < (row.Count - 1) && maze[y][x + 1].IsOpen)
                            cell.Connected.Add(maze[y][x + 1]);

                        // South
                        if (y < (maze.Count - 1) && maze[y + 1][x].IsOpen)
                            cell.Connected.Add(maze[y + 1][x]);

                        // West
                        if (x > 0 && maze[y][x - 1].IsOpen)
                            cell.Connected.Add(maze[y][x - 1]);
                    }
                    x++;
                }
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

    public class MazeState
    {
        public int Step;
        public MazeCell Position;
        public List<MazeCell> TraveledPositions;

        public MazeState(int step, MazeCell position, List<MazeCell> traveledPositions)
        {
            Step = step;
            Position = position;
            TraveledPositions = traveledPositions;
        }

        public List<MazeCell> CloneAndAddToTraveledPositions(MazeCell position)
        {
            // Have to clone the list
            List<MazeCell> list = new List<MazeCell>();
            foreach (MazeCell cell in TraveledPositions)
            {
                list.Add(cell);
            }
            list.Add(position);
            return list;
        }
    }

    public class MazeCell
    {
        public string Id;
        public bool IsOpen;
        public int TargetNumber;

        public List<MazeCell> Connected;

        public MazeCell(char input, int x, int y)
        {
            Id = $"{y}{x}";
            Connected = new List<MazeCell>();

            if (input == '#')
            {
                IsOpen = false;
                TargetNumber = -1;
            }
            if (input == '.')
            {
                IsOpen = true;
                TargetNumber = -1;
            }
            int attempt;
            if (Int32.TryParse(input.ToString(), out attempt))
            {
                IsOpen = true;
                TargetNumber = attempt;
            }
        }
    }
}