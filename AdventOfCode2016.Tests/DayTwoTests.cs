using Xunit;

namespace AdventOfCode2016.Tests
{
    public class DayTwoTests
    {
        [Theory]
        [InlineData("2", "U")]
        [InlineData("1", "ULLL")]
        public void testDetermineBathroomCodeSimple(string expected, string input)
        {
            var sot = new DayTwo();
            var result = sot.DetermineBathroomCode(input, 1, 1, DayTwo.KEY_PAD);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void testDetermineBathroomCode()
        {
            string input = @"ULL
RRDDD
LURDL
UUUUD";
            var sot = new DayTwo();
            var result = sot.DetermineBathroomCode(input, 1, 1, DayTwo.KEY_PAD);

            Assert.Equal("1985", result);
        }

        [Fact]
        public void testWithActualPartA()
        {
            var sot = new DayTwo();
            var result = sot.DetermineBathroomCode(DayTwo.PUZZLE_INPUT, 1, 1, DayTwo.KEY_PAD);

            Assert.Equal("24862", result);
        }

        [Fact]
        public void testWithActualPartB()
        {
            var sot = new DayTwo();
            var result = sot.DetermineBathroomCode(DayTwo.PUZZLE_INPUT, 1, 1, DayTwo.KEY_PAD_TWO);

            Assert.Equal("46C91", result);
        }
    }
}