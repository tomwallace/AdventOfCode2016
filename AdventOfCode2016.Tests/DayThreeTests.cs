using Xunit;

namespace AdventOfCode2016.Tests
{
    public class DayThreeTests
    {
        [Theory]
        [InlineData(2, 3, 4, true)]
        [InlineData(30, 10, 20, false)]
        [InlineData(5, 10, 25, false)]
        public void testIsValidTriangle(int sideOne, int sideTwo, int sideThree, bool expected)
        {
            var sot = new DayThree();
            var result = sot.IsValidTriangle(sideOne, sideTwo, sideThree);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void testWithActualPartA()
        {
            var sot = new DayThree();
            var result = sot.CountValidTriangles(DayThree.PUZZLE_INPUT);

            Assert.Equal(917, result);
        }

        [Fact]
        public void testWithActualPartB()
        {
            var sot = new DayThree();
            var result = sot.CountValidTrianglesInColumns(DayThree.PUZZLE_INPUT);

            Assert.Equal(1649, result);
        }
    }
}