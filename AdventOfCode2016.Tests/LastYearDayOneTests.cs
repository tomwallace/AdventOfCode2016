using Xunit;

namespace AdventOfCode2016.Tests
{
    public class LastYearDayOneTests
    {
        [Theory]
        [InlineData(1, "(")]
        [InlineData(-1, ")")]
        [InlineData(0, "()")]
        [InlineData(-3, ")())())")]
        public void testDetermineSantaFloor(int expected, string input)
        {
            var sot = new LastYearDayOne();
            var result = sot.determineSantaFloor(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, "(")]
        [InlineData(1, ")")]
        [InlineData(0, "()")]
        [InlineData(3, "())()")]
        public void testDetermineFirstBasement(int expected, string input)
        {
            var sot = new LastYearDayOne();
            var result = sot.determineFirstBasement(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void testWithActualPartA()
        {
            var sot = new LastYearDayOne();
            var result = sot.determineSantaFloor(LastYearDayOne.PUZZLE_INPUT);

            Assert.Equal(280, result);
        }

        [Fact]
        public void testWithActualPartB()
        {
            var sot = new LastYearDayOne();
            var result = sot.determineFirstBasement(LastYearDayOne.PUZZLE_INPUT);

            Assert.Equal(1797, result);
        }
    }
}