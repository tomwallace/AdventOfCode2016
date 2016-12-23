using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2016.TwentyTwo
{
    public class DayTwentyTwo
    {
        public int _maxX;
        public int _maxY;
        public Node _target;

        public long CountViablePairsOfNodes()
        {
            List<Node> nodes = GetListOfNodes();

            // Get all combinations
            var combinations = CombinationUtility.GetAllPermutationPairsOrderDoesNotMatter(nodes).ToList();
            var matches = combinations.FindAll(t => (t.Item1.Used > 0 && t.Item2.Avail >= t.Item1.Used) || (t.Item2.Used > 0 && t.Item1.Avail >= t.Item2.Used));

            return matches.Count;
        }

        public List<Node> GetListOfNodes()
        {
            List<Node> nodes = new List<Node>();

            string line;
            StreamReader file = new StreamReader(@"TwentyTwo\DayTwentyTwoInput.txt");
            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains("/dev/grid"))
                    nodes.Add(new Node(line));
            }
            file.Close();

            return nodes;
        }

        public long RecurseForSteps(List<Node> currentNodes, Node keyDataLocation, Node empty, long steps)
        {
            // Exit conditions
            if (keyDataLocation.Id == _target.Id)
                return 1;

            // Get all combinations of remaining valid moves to open a sector
            var combinations = CombinationUtility.GetAllPermutationPairsOrderDoesNotMatter(currentNodes).ToList();
            var matches = combinations.FindAll(t => (t.Item1.CanMoveTo(t.Item2)) || (t.Item2.CanMoveTo(t.Item1)));
            foreach (var match in matches)
            {
                if (match.Item1.CanMoveTo(match.Item2))
                {
                    // Update values
                    match.Item2.Used += match.Item1.Used;
                    match.Item2.Avail -= match.Item1.Used;
                    match.Item1.Used = 0;
                    match.Item1.Avail = match.Item1.Size;
                    empty = match.Item1;

                    if (keyDataLocation.CanMoveTo(empty))
                    {
                        Node holder = keyDataLocation;
                        empty.Used += keyDataLocation.Used;
                        empty.Avail -= keyDataLocation.Used;
                        keyDataLocation.Used = 0;
                        keyDataLocation.Avail = keyDataLocation.Size;

                        keyDataLocation = empty;
                        empty = holder;
                        steps += 1;
                    }

                    steps += RecurseForSteps(currentNodes, keyDataLocation, empty, steps + 1);
                }

                if (match.Item2.CanMoveTo(match.Item1))
                {
                    // Update values
                    match.Item1.Used += match.Item2.Used;
                    match.Item1.Avail -= match.Item2.Used;
                    match.Item2.Used = 0;
                    match.Item2.Avail = match.Item2.Size;
                    empty = match.Item2;

                    if (keyDataLocation.CanMoveTo(empty))
                    {
                        Node holder = keyDataLocation;
                        empty.Used += keyDataLocation.Used;
                        empty.Avail -= keyDataLocation.Used;
                        keyDataLocation.Used = 0;
                        keyDataLocation.Avail = keyDataLocation.Size;

                        keyDataLocation = empty;
                        empty = holder;
                        steps += 1;
                    }

                    steps += RecurseForSteps(currentNodes, keyDataLocation, empty, steps + 1);
                }
            }

            return steps;
        }
    }

    public class Node
    {
        public string Id;
        public int X;
        public int Y;
        public int Size;
        public int Used;
        public int Avail;
        public int UsePercent;

        public Node()
        {
        }

        public Node(string input)
        {
            List<string> split = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            Id = split[0].Trim();
            Size = Int32.Parse(split[1].Substring(0, split[1].Length - 1));
            Used = Int32.Parse(split[2].Substring(0, split[2].Length - 1));
            Avail = Int32.Parse(split[3].Substring(0, split[3].Length - 1));
            UsePercent = Int32.Parse(split[4].Substring(0, split[4].Length - 1));

            X = Int32.Parse(Id.Split('x')[1].Split('-')[0]);
            Y = Int32.Parse(Id.Split('y')[1]);
        }

        public bool CanMoveTo(Node nodeMovingTo)
        {
            // Cannot go diagnal
            if (X != nodeMovingTo.X && Y != nodeMovingTo.Y)
                return false;

            // Make sure that we are only one away, not including diagonals
            if (Math.Abs(X - nodeMovingTo.X) <= 1 && Math.Abs(Y - nodeMovingTo.Y) <= 1)
            {
                // Finally, check to see if there is room
                return Used > 0 && Avail >= nodeMovingTo.Used;
            }

            return false;
        }
    }
}