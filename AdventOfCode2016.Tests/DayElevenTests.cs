using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode2016.Tests
{
    public class DayElevenTests
    {
        [Fact]
        public void testIsComplete_Success()
        {
            var objs = new List<List<string>>();
            objs.Add(new List<string>());
            objs.Add(new List<string>());
            objs.Add(new List<string>());
            objs.Add(new List<string>() { "BM", "BG", "CM", "CG" });

            var floorState = new FloorState(0, objs, 3);
            var result = floorState.IsComplete();

            Assert.True(result);
        }

        [Fact]
        public void testIsComplete_Fail_Objs()
        {
            var objs = new List<List<string>>();
            objs.Add(new List<string>());
            objs.Add(new List<string>());
            objs.Add(new List<string>() { "BM" });
            objs.Add(new List<string>() { "BG", "CM", "CG" });

            var floorState = new FloorState(0, objs, 3);
            var result = floorState.IsComplete();

            Assert.False(result);
        }

        [Fact]
        public void testIsComplete_Fail_Elevator()
        {
            var objs = new List<List<string>>();
            objs.Add(new List<string>());
            objs.Add(new List<string>());
            objs.Add(new List<string>());
            objs.Add(new List<string>() { "BM", "BG", "CM", "CG" });

            var floorState = new FloorState(0, objs, 1);
            var result = floorState.IsComplete();

            Assert.False(result);
        }

        [Fact]
        public void testIsInvalidSituation_Valid_SameFloor()
        {
            var objs = new List<List<string>>();
            objs.Add(new List<string>());
            objs.Add(new List<string>());
            objs.Add(new List<string>() { "BM", "BG", });
            objs.Add(new List<string>() { "CM", "CG" });

            var floorState = new FloorState(0, objs, 0);
            var result = floorState.IsInvalidSituation();

            Assert.False(result);
        }

        [Fact]
        public void testIsInvalidSituation_Valid_DifferentFloors()
        {
            var objs = new List<List<string>>();
            objs.Add(new List<string>() { "BM" });
            objs.Add(new List<string>() { "BG" });
            objs.Add(new List<string>() { "CM" });
            objs.Add(new List<string>() { "CG" });

            var floorState = new FloorState(0, objs, 0);
            var result = floorState.IsInvalidSituation();

            Assert.False(result);
        }

        [Fact]
        public void testFloorStateEqualityComparer_ExactComparison()
        {
            var objs = new List<List<string>>();
            objs.Add(new List<string>() { "BM" });
            objs.Add(new List<string>() { "BG" });
            objs.Add(new List<string>() { "CM" });
            objs.Add(new List<string>() { "CG" });
            var floorStateOne = new FloorState(0, objs, 0);

            var objsOther = new List<List<string>>();
            objsOther.Add(new List<string>() { "BM", "CM" });
            objsOther.Add(new List<string>() { "BG" });
            objsOther.Add(new List<string>());
            objsOther.Add(new List<string>() { "CG" });
            var floorStateOther = new FloorState(0, objsOther, 0);

            var list = new List<FloorState>();
            list.Add(floorStateOne);
            list.Add(floorStateOther);

            var objsTwo = new List<List<string>>();
            objsTwo.Add(new List<string>() { "BM" });
            objsTwo.Add(new List<string>() { "BG" });
            objsTwo.Add(new List<string>() { "CM" });
            objsTwo.Add(new List<string>() { "CG" });

            var floorStateTwo = new FloorState(0, objsTwo, 0);

            var result = list.Contains(floorStateTwo, new FloorStateEqualityComparer());
            Assert.True(result);
        }

        [Fact]
        public void testFloorStateEqualityComparer_FlippedPairs()
        {
            var objs = new List<List<string>>();
            objs.Add(new List<string>() { "BM" });
            objs.Add(new List<string>() { "BG" });
            objs.Add(new List<string>() { "CM" });
            objs.Add(new List<string>() { "CG" });
            var floorStateOne = new FloorState(0, objs, 0);

            var objsOther = new List<List<string>>();
            objsOther.Add(new List<string>() { "BM", "CM" });
            objsOther.Add(new List<string>() { "BG" });
            objsOther.Add(new List<string>());
            objsOther.Add(new List<string>() { "CG" });
            var floorStateOther = new FloorState(0, objsOther, 0);

            var list = new List<FloorState>();
            list.Add(floorStateOne);
            list.Add(floorStateOther);

            var objsTwo = new List<List<string>>();
            objsTwo.Add(new List<string>() { "CM" });
            objsTwo.Add(new List<string>() { "CG" });
            objsTwo.Add(new List<string>() { "BM" });
            objsTwo.Add(new List<string>() { "BG" });

            var floorStateTwo = new FloorState(0, objsTwo, 0);

            var result = list.Contains(floorStateTwo, new FloorStateEqualityComparer());
            Assert.True(result);
        }

        [Fact]
        public void testFloorStateEqualityComparer_ReturnsFalse()
        {
            var objs = new List<List<string>>();
            objs.Add(new List<string>() { "BM" });
            objs.Add(new List<string>() { "BG" });
            objs.Add(new List<string>() { "CM" });
            objs.Add(new List<string>() { "CG" });
            var floorStateOne = new FloorState(0, objs, 0);

            var objsOther = new List<List<string>>();
            objsOther.Add(new List<string>() { "BM", "CM" });
            objsOther.Add(new List<string>() { "BG" });
            objsOther.Add(new List<string>());
            objsOther.Add(new List<string>() { "CG" });
            var floorStateOther = new FloorState(0, objsOther, 0);

            var list = new List<FloorState>();
            list.Add(floorStateOne);
            list.Add(floorStateOther);

            var objsTwo = new List<List<string>>();
            objsTwo.Add(new List<string>() { "CM", "CG" });
            objsTwo.Add(new List<string>());
            objsTwo.Add(new List<string>() { "BM" });
            objsTwo.Add(new List<string>() { "BG" });

            var floorStateTwo = new FloorState(0, objsTwo, 0);

            var result = list.Contains(floorStateTwo, new FloorStateEqualityComparer());
            Assert.False(result);
        }

        [Fact]
        public void testIsInvalidSituation_Invalid()
        {
            var objs = new List<List<string>>();
            objs.Add(new List<string>() { "BM", "CG" });
            objs.Add(new List<string>() { "BG" });
            objs.Add(new List<string>() { "CM" });
            objs.Add(new List<string>());

            var floorState = new FloorState(0, objs, 0);
            var result = floorState.IsInvalidSituation();

            Assert.True(result);
        }

        [Fact]
        public void testCombinationMethodology()
        {
            var list = new List<string> { "a1", "b2", "c3" };
            var result = from pair in list.Select((value, index) => new { value, index })
                         from second in list.Skip(pair.index + 1)
                         select Tuple.Create(pair.value, second);

            Assert.Equal(3, result.Count());
        }

        [Fact]
        public void testNumberOfPossibleStepsToSafelyMoveObjects()
        {
            var sut = new DayEleven();
            var objs = new List<List<string>>();
            objs.Add(new List<string>() { "HM", "LM" });
            objs.Add(new List<string>() { "HG" });
            objs.Add(new List<string>() { "LG" });
            objs.Add(new List<string>());

            var result = sut.NumberOfPossibleStepsToSafelyMoveObjects(objs);

            Assert.Equal(11, result);
        }

        // Test took 230 minutes to run last time, so only uncomment if needed.
        /*
        [Fact]
        public void testWithActualPartA()
        {
            // P=polonium, T=thulium, O=promethium, R=ruthenium, C=cobalt
            var sut = new DayEleven();
            var objs = new List<List<string>>();
            objs.Add(new List<string>() { "PG", "TG", "TM", "OG", "RG", "RM", "CG", "CM" });
            objs.Add(new List<string>() { "PM", "OM" });
            objs.Add(new List<string>());
            objs.Add(new List<string>());

            var result = sut.NumberOfPossibleStepsToSafelyMoveObjects(objs);

            Assert.Equal(47, result);
        }
        */

        /*  Takes a LONG time to run
        [Fact]
        public void testWithActualPartB()
        {
            // P=polonium, T=thulium, O=promethium, R=ruthenium, C=cobalt, E=elerium, D=dilithium
            var sut = new DayEleven();
            var objs = new List<List<string>>();
            objs.Add(new List<string>() { "PG", "TG", "TM", "OG", "RG", "RM", "CG", "CM", "EG", "EM", "DG", "DM" });
            objs.Add(new List<string>() { "PM", "OM" });
            objs.Add(new List<string>());
            objs.Add(new List<string>());

            var result = sut.NumberOfPossibleStepsToSafelyMoveObjects(objs);

            Assert.Equal(71, result);
        }
        */
    }
}