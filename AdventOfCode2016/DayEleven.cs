using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2016
{
    public class DayEleven
    {
        private List<FloorState> _queue = new List<FloorState>();
        private List<FloorState> _previousStates = new List<FloorState>();

        public int NumberOfPossibleStepsToSafelyMoveObjects(List<List<string>> objectFloors)
        {
            FloorState floorState = new FloorState(0, objectFloors, 0);
            _queue.Add(floorState);

            do
            {
                FloorState firstFloorState = _queue[0];
                _queue.RemoveAt(0);

                // If answer, return it
                if (firstFloorState.IsComplete())
                    return firstFloorState.Step;

                // If valid, get its posibilities
                if (!firstFloorState.IsInvalidSituation())
                {
                    ProcessFloorStatePossibilities(firstFloorState);
                }
                Debug.WriteLine($"steps: {firstFloorState.Step} state: {firstFloorState} prevStates: {_previousStates.Count} queue: {_queue.Count}.");
            } while (_queue.Any());

            // Will never get there
            return 0;
        }

        public void ProcessFloorStatePossibilities(FloorState floorState)
        {
            List<int> possibleElevatorStops = floorState.ListOfPossibleFloors();
            foreach (int targetedFloor in possibleElevatorStops)
            {
                // Now need to handle all valid pairs
                List<string> objectFloorForPairs = floorState.CurrentObjectFloor().ToList();
                var combinations = CombinationUtility.GetAllPermutationPairsOrderDoesNotMatter(objectFloorForPairs);
                foreach (var combo in combinations)
                {
                    // If the two items are of different types, need to make sure valid
                    /*
                    string element = combo.Item1.Substring(0, 1);
                    if ((combo.Item1.Contains("M") && combo.Item2.Contains("M")) ||
                        (combo.Item1.Contains("G") && combo.Item2.Contains("G")) ||
                         combo.Item2.Contains(element))
                    {
                    */
                    List<List<string>> copyOfObjectFloors = floorState.DeepCloneObjectFloors();
                    copyOfObjectFloors[targetedFloor].Add(combo.Item1);
                    copyOfObjectFloors[targetedFloor].Add(combo.Item2);
                    copyOfObjectFloors[floorState.Elevator].Remove(combo.Item1);
                    copyOfObjectFloors[floorState.Elevator].Remove(combo.Item2);

                    // Make new FloorState and if valid, add to queue
                    FloorState newFloorState = new FloorState(floorState.Step + 1, copyOfObjectFloors, targetedFloor);
                    if (!newFloorState.IsInvalidSituation() && floorState.PreviousStates.Contains(newFloorState, new FloorStateEqualityComparer()) == false)
                    {
                        var prevStates = floorState.DeepClonePreviousStates();
                        prevStates.Add(floorState);
                        newFloorState.PreviousStates = prevStates;
                        _queue.Add(newFloorState);
                    }
                }

                // Can move one element, but only if there was not a valid pair movement
                List<string> objectFloor = floorState.CurrentObjectFloor().ToList();
                foreach (string obj in objectFloor)
                {
                    // Make a copy so we can modify original
                    List<List<string>> copyOfObjectFloors = floorState.DeepCloneObjectFloors();
                    copyOfObjectFloors[targetedFloor].Add(obj);
                    copyOfObjectFloors[floorState.Elevator].Remove(obj);

                    // Make new FloorState and if valid, add to queue
                    FloorState newFloorState = new FloorState(floorState.Step + 1, copyOfObjectFloors, targetedFloor);
                    if (!newFloorState.IsInvalidSituation() && floorState.PreviousStates.Contains(newFloorState, new FloorStateEqualityComparer()) == false)
                    {
                        var prevStates = floorState.DeepClonePreviousStates();
                        prevStates.Add(floorState);
                        newFloorState.PreviousStates = prevStates;
                        _queue.Add(newFloorState);
                    }
                }
            }
        }
    }

    public class FloorState
    {
        public int Step;

        public List<List<string>> ObjectFloors;

        public int Elevator;

        public List<FloorState> PreviousStates;

        public FloorState(int step, List<List<string>> objectFloors, int elevator)
        {
            Step = step;
            ObjectFloors = objectFloors;
            Elevator = elevator;
            PreviousStates = new List<FloorState>();
        }

        public override string ToString()
        {
            string concat = "";
            for (int i = 0; i < 4; i++)
            {
                for (int y = 0; y < ObjectFloors[i].Count; y++)
                {
                    concat = string.Concat(concat, ObjectFloors[i][y]);
                }
                concat = string.Concat(concat, "-");
            }
            return concat;
        }

        public bool IsInvalidSituation()
        {
            for (int i = 0; i < 4; i++)
            {
                List<string> rtgs = new List<string>();
                List<string> microChips = new List<string>();

                // Split the rtgs and chips up
                foreach (string obj in ObjectFloors[i])
                {
                    if (obj.Contains("M"))
                        microChips.Add(obj.Substring(0, 1));
                    else
                        rtgs.Add(obj.Substring(0, 1));
                }

                // If there are any rtgs, need to check that chips match
                if (rtgs.Any())
                {
                    foreach (string microChip in microChips)
                    {
                        if (!rtgs.Contains(microChip))
                            return true;
                    }
                }
            }

            return false;
        }

        public bool IsComplete()
        {
            if (ObjectFloors[0].Count > 0 || ObjectFloors[1].Count > 0 || ObjectFloors[2].Count > 0 || Elevator != 3)
                return false;

            return true;
        }

        public List<int> ListOfPossibleFloors()
        {
            List<int> results = new List<int>();
            // Don't go down if there is nothing to go down for
            /*
            bool anythingBelow = false;
            for (int i = 0; i < Elevator; i++)
            {
                if (ObjectFloors[i].Count > 0)
                    anythingBelow = true;
            }
            */
            if (Elevator > 0)// && anythingBelow)
                results.Add(Elevator - 1);

            if (Elevator < 3)
                results.Add(Elevator + 1);

            return results;
        }

        public List<string> CurrentObjectFloor()
        {
            return ObjectFloors[Elevator];
        }

        public List<List<string>> DeepCloneObjectFloors()
        {
            List<List<string>> clone = new List<List<string>>();
            foreach (List<string> floor in ObjectFloors)
            {
                List<string> floorClone = new List<string>();
                foreach (string obj in floor)
                {
                    floorClone.Add(obj);
                }
                clone.Add(floorClone);
            }

            return clone;
        }

        public List<FloorState> DeepClonePreviousStates()
        {
            List<FloorState> clone = new List<FloorState>();
            foreach (FloorState floorState in PreviousStates)
            {
                clone.Add(floorState);
            }
            return clone;
        }
    }

    public class FloorStateEqualityComparer : IEqualityComparer<FloorState>
    {
        public bool Equals(FloorState c1, FloorState c2)
        {
            if (c2 == null && c1 == null)
                return true;
            if (c1 == null | c2 == null)
                return false;

            // Create lists for comparison
            List<List<int>> c1Pairs = CreateListOfPairs(c1.ObjectFloors);
            List<List<int>> c2Pairs = CreateListOfPairs(c2.ObjectFloors);

            foreach (List<int> c1Pair in c1Pairs)
            {
                if (c2Pairs.Find(x => x[0] == c1Pair[0] && x[1] == c1Pair[1]) == null)
                    return false;
            }

            // Elevators also have to be equal for the same state to exist
            return c1.Elevator == c2.Elevator;
        }

        public int GetHashCode(FloorState f)
        {
            string concat = "";
            for (int i = 0; i < 4; i++)
            {
                foreach (string s in f.ObjectFloors[i])
                    concat = string.Concat(concat, s);
            }
            return concat.GetHashCode();
        }

        public List<List<int>> CreateListOfPairs(List<List<string>> floors)
        {
            Dictionary<string, List<int>> pairs = new Dictionary<string, List<int>>();
            for (int i = 0; i < 4; i++)
            {
                foreach (string obj in floors[i])
                {
                    string letter = obj.Substring(0, 1);
                    if (pairs.ContainsKey(letter))
                    {
                        if (obj.Contains("M"))
                            pairs[letter][0] = i;
                        else
                            pairs[letter][1] = i;
                    }
                    else
                    {
                        List<int> list = new List<int>();
                        if (obj.Contains("M"))
                        {
                            list.Add(i);
                            list.Add(-1);
                        }
                        else
                        {
                            list.Add(-1);
                            list.Add(i);
                        }
                        pairs.Add(letter, list);
                    }
                }
            }

            List<List<int>> results = new List<List<int>>();
            foreach (var entry in pairs)
            {
                results.Add(entry.Value);
            }

            return results;
        }
    }
}