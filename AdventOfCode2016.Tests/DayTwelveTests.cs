using System.Collections.Generic;
using Xunit;

namespace AdventOfCode2016.Tests
{
    public class DayTwelveTests
    {
        [Fact]
        public void testProcessInstructionsAndReturnResult()
        {
            var input = @"cpy 41 a
inc a
inc a
dec a
jnz a 2
dec a";
            var registers = new Dictionary<string, int>()
            {
                { "a", 0 },
                { "b", 0 },
                { "c", 0 },
                { "d", 0 }
            };

            var sot = new DayTwelve();
            var result = sot.ProcessInstructionsAndReturnResult(input, "a", registers);

            Assert.Equal(42, result);
        }

        // These tests take a while to run, so only uncomment if necessary
        /*
        [Fact]
        public void testWithActualPartA()
        {
            var sot = new DayTwelve();
            var registers = new Dictionary<string, int>()
            {
                { "a", 0 },
                { "b", 0 },
                { "c", 0 },
                { "d", 0 }
            };
            var result = sot.ProcessInstructionsAndReturnResult(DayTwelve.PUZZLE_INPUT, "a", registers);

            Assert.Equal(318077, result);
        }

        [Fact]
        public void testWithActualPartB()
        {
            var sot = new DayTwelve();
            var registers = new Dictionary<string, int>()
            {
                { "a", 0 },
                { "b", 0 },
                { "c", 1 },
                { "d", 0 }
            };
            var result = sot.ProcessInstructionsAndReturnResult(DayTwelve.PUZZLE_INPUT, "a", registers);

            Assert.Equal(9227731, result);
        }
        */
    }
}