using System.Collections.Generic;
using Xunit;

namespace AdventOfCode2016.Tests
{
    public class DayTwentyThreeTests
    {
        [Theory]
        [InlineData("inc a", "dec a")]
        [InlineData("dec b", "inc b")]
        [InlineData("tgl b", "inc b")]
        [InlineData("cpy 2 a", "jnz 2 a")]
        [InlineData("jnz a 2", "cpy a 2")]
        public void testToggleConvertInstruction(string input, string expected)
        {
            var sot = new DayTwentyThree();
            var result = sot.ToggleConvertInstruction(input);

            Assert.Equal(expected, result);
        }

        // These tests take a while to run, so only uncomment if necessary

        [Fact]
        public void testWithActualPartA()
        {
            var sot = new DayTwentyThree();
            var registers = new Dictionary<string, int>()
            {
                { "a", 7 },
                { "b", 0 },
                { "c", 0 },
                { "d", 0 }
            };
            var result = sot.ProcessInstructionsAndReturnResult(DayTwentyThree.PUZZLE_INPUT, "a", registers);

            Assert.Equal(11478, result);
        }

        [Fact]
        public void testWithActualPartB()
        {
            var sot = new DayTwentyThree();
            var registers = new Dictionary<string, int>()
            {
                { "a", 12 },
                { "b", 0 },
                { "c", 0 },
                { "d", 0 }
            };
            var result = sot.ProcessInstructionsAndReturnResult(DayTwentyThree.PUZZLE_INPUT, "a", registers);

            Assert.Equal(479008038, result);
        }
    }
}