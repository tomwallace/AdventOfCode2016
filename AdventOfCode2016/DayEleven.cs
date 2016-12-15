using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    public class DayEleven
    {
        private List<FloorState> _queue = new List<FloorState>();

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
            } while (_queue.Any());

            // Will never get there
            return 0;
        }

        // TODO: Hit out of memory - too many state changes - REVIEW the combinations bit (eliminate order duplicates)
        public void ProcessFloorStatePossibilities(FloorState floorState)
        {
            // Otherwise recurse over other possibilities
            // Collect list of possible elevator stops
            List<int> possibleElevatorStops = floorState.ListOfPossibleFloors();
            foreach (int targetedFloor in possibleElevatorStops)
            {
                List<string> objectFloor = floorState.CurrentObjectFloor().ToList();
                // Can always move one element
                foreach (string obj in objectFloor)
                {
                    // Make a copy so we can modify original
                    List<List<string>> copyOfObjectFloors = floorState.DeepCloneObjectFloors();
                    copyOfObjectFloors[targetedFloor].Add(obj);
                    copyOfObjectFloors[floorState.Elevator].Remove(obj);

                    // Make new FloorState and if valid, add to queue
                    FloorState newFloorState = new FloorState(floorState.Step + 1, copyOfObjectFloors, targetedFloor);
                    if (!newFloorState.IsInvalidSituation())
                        _queue.Add(newFloorState);
                }
                // Now need to handle all valid pairs
                List<string> objectFloorForPairs = floorState.CurrentObjectFloor().ToList();
                /*
                var combinations = from item1 in objectFloorForPairs
                                   from item2 in objectFloorForPairs
                                   where item1 != item2
                                   select Tuple.Create(item1, item2);
                */
                var combinations = from pair in objectFloorForPairs.Select((value, index) => new { value, index })
                                   from second in objectFloorForPairs.Skip(pair.index + 1)
                                   select Tuple.Create(pair.value, second);
                foreach (var combo in combinations)
                {
                    // If the two items are of different types, need to make sure valid
                    if ((combo.Item1.Contains("M") && !combo.Item2.Contains("M")) ||
                        (combo.Item2.Contains("M") && !combo.Item1.Contains("M")))
                    {
                        // Only if they are of the same element can we proceed
                        if (combo.Item1.Substring(0, 1) == combo.Item2.Substring(0, 1))
                        {
                            List<List<string>> copyOfObjectFloors = floorState.DeepCloneObjectFloors();
                            copyOfObjectFloors[targetedFloor].Add(combo.Item1);
                            copyOfObjectFloors[targetedFloor].Add(combo.Item2);
                            copyOfObjectFloors[floorState.Elevator].Remove(combo.Item1);
                            copyOfObjectFloors[floorState.Elevator].Remove(combo.Item2);

                            // Make new FloorState and if valid, add to queue
                            FloorState newFloorState = new FloorState(floorState.Step + 1, copyOfObjectFloors, targetedFloor);
                            if (!newFloorState.IsInvalidSituation())
                                _queue.Add(newFloorState);
                        }
                    }
                    else
                    {
                        List<List<string>> copyOfObjectFloors = floorState.DeepCloneObjectFloors();
                        copyOfObjectFloors[targetedFloor].Add(combo.Item1);
                        copyOfObjectFloors[targetedFloor].Add(combo.Item2);
                        copyOfObjectFloors[floorState.Elevator].Remove(combo.Item1);
                        copyOfObjectFloors[floorState.Elevator].Remove(combo.Item2);

                        // Make new FloorState and if valid, add to queue
                        FloorState newFloorState = new FloorState(floorState.Step + 1, copyOfObjectFloors, targetedFloor);
                        if (!newFloorState.IsInvalidSituation())
                            _queue.Add(newFloorState);
                    }
                }
            }
        }

        /*
        public List<int> RecurseOverSteps(List<List<string>> objectFloors, int elevator,
            int stepCounter, List<int> results)
        {
            // If success, then return step counter
            if (IsComplete(objectFloors, elevator))
            {
                results.Add(stepCounter);
                return results;
            }

            // If invalid conditions, then return invalid number
            if (IsInvalidSituation(objectFloors))
                return results;

            // Otherwise recurse over other possibilities
            // Collect list of possible elevator stops
            List<int> possibleElevatorStops = ListOfPossibleFloors(elevator);
            foreach (int targetedFloor in possibleElevatorStops)
            {
                List<string> objectFloor = objectFloors[elevator].ToList();
                // Can always move one element
                foreach (string obj in objectFloor)
                {
                    // Make a copy so we can modify original
                    List<List<string>> copyOfObjectFloors = objectFloors.ToList();
                    copyOfObjectFloors[targetedFloor].Add(obj);
                    copyOfObjectFloors[elevator].Remove(obj);
                    results.AddRange(RecurseOverSteps(copyOfObjectFloors, targetedFloor, stepCounter + 1, results));
                }
                // Now need to handle all valid pairs
                List<string> objectFloorForPairs = objectFloors[elevator].ToList();
                var combinations = from item1 in objectFloorForPairs
                                   from item2 in objectFloorForPairs
                                   where item1 != item2
                                   select Tuple.Create(item1, item2);
                foreach (var combo in combinations)
                {
                    // If the two items are of different types, need to make sure valid
                    if ((combo.Item1.Contains("M") && !combo.Item2.Contains("M")) ||
                        (combo.Item2.Contains("M") && !combo.Item1.Contains("M")))
                    {
                        // Only if they are of the same element can we proceed
                        if (combo.Item1.Substring(0, 1) == combo.Item2.Substring(0, 1))
                        {
                            List<List<string>> copyOfObjectFloors = objectFloors.ToList();
                            copyOfObjectFloors[targetedFloor].Add(combo.Item1);
                            copyOfObjectFloors[targetedFloor].Add(combo.Item2);
                            copyOfObjectFloors[elevator].Remove(combo.Item1);
                            copyOfObjectFloors[elevator].Remove(combo.Item2);
                            results.AddRange(RecurseOverSteps(copyOfObjectFloors, targetedFloor, stepCounter + 1, results));
                        }
                    }
                    else
                    {
                        List<List<string>> copyOfObjectFloors = objectFloors.ToList();
                        copyOfObjectFloors[targetedFloor].Add(combo.Item1);
                        copyOfObjectFloors[targetedFloor].Add(combo.Item2);
                        copyOfObjectFloors[elevator].Remove(combo.Item1);
                        copyOfObjectFloors[elevator].Remove(combo.Item2);
                        results.AddRange(RecurseOverSteps(copyOfObjectFloors, targetedFloor, stepCounter + 1, results));
                    }
                }
            }
            return results;
        }

        public bool IsComplete(List<List<string>> objectFloors, int elevator)
        {
            if (objectFloors[0].Count > 0 || objectFloors[1].Count > 0 || objectFloors[2].Count > 0 || elevator != 3)
                return false;

            return true;
        }

        public bool IsInvalidSituation(List<List<string>> objectFloors)
        {
            for (int i = 0; i < 4; i++)
            {
                List<string> rtgs = new List<string>();
                List<string> microChips = new List<string>();

                // Split the rtgs and chips up
                foreach (string obj in objectFloors[i])
                {
                    if (obj.Contains("M"))
                        microChips.Add(obj.Substring(0, 1));
                    else
                        rtgs.Add(obj.Substring(0, 1));
                }

                // If there are any rtgs, need to check that chips match
                if (rtgs.Count() > 0)
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

        public List<int> ListOfPossibleFloors(int elevator)
        {
            List<int> results = new List<int>();
            if (elevator > 0)
                results.Add(elevator - 1);

            if (elevator < 3)
                results.Add(elevator + 1);

            return results;
        }
        */
    }

    public class FloorState
    {
        public int Step;

        public List<List<string>> ObjectFloors;

        public int Elevator;

        public FloorState(int step, List<List<string>> objectFloors, int elevator)
        {
            Step = step;
            ObjectFloors = objectFloors;
            Elevator = elevator;
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
                if (rtgs.Count() > 0)
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
            if (Elevator > 0)
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
    }
}