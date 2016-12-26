using System.Collections.Generic;
using Xunit;

namespace AdventOfCode2016.Tests
{
    public class DayTwentyFiveTests
    {
        // These tests take a while to run, so only uncomment if necessary
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

        /*
        [Fact]
        public void testWithActualPartB()
        {
            var sot = new DayTwentyFive();
            var registers = new Dictionary<string, int>()
            {
                { "a", 12 },
                { "b", 0 },
                { "c", 0 },
                { "d", 0 }
            };
            var result = sot.ProcessInstructionsAndReturnResult(DayTwentyFive.PUZZLE_INPUT, "a", registers);

            Assert.Equal(479008038, result);
        }
        */
    }
}