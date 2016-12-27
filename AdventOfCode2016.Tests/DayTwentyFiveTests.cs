using System.Collections.Generic;
using Xunit;

namespace AdventOfCode2016.Tests
{
    public class DayTwentyFiveTests
    {
        [Fact]
        public void testWithActualPartA()
        {
            var sot = new DayTwentyFive();
            var registers = new Dictionary<string, int>()
            {
                { "a", 0 },
                { "b", 0 },
                { "c", 0 },
                { "d", 0 }
            };
            var result = sot.LowestIntegerThatProducesAlternatingSignal(DayTwentyFive.PUZZLE_INPUT, registers);

            Assert.Equal(196, result);
        }

        // There is no puzzle Part B for Day 25 - you just need to finish all of the other stars
    }
}