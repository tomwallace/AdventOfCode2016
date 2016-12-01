using Xunit;

namespace AdventOfCode2016.Tests
{
    public class DayOneTests
    {
        [Theory]
        [InlineData("L", 1, 0, -1)]
        [InlineData("R", 12, 0, 12)]
        public void testPositionMove(string turn, int distance, int expectedVertical, int expectHorizontal)
        {
            var position = new Position();
            position.Move(turn, distance);

            Assert.Equal(expectedVertical, position.vertical);
            Assert.Equal(expectHorizontal, position.horizontal);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(3, 2, 5)]
        [InlineData(-3, -2, 5)]
        [InlineData(10, -4, 14)]
        public void testCompareLocation(int newVertical, int newHorizontal, int expected)
        {
            var origin = new Position();
            var adjustedPosition = new Position();
            adjustedPosition.horizontal = newHorizontal;
            adjustedPosition.vertical = newVertical;

            var result = adjustedPosition.CompareLocation(origin);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(5, "R2, L3")]
        [InlineData(2, "R2, R2, R2")]
        [InlineData(12, "R5, L5, R5, R3")]
        public void testDetermineDistanceTraveled(int expected, string input)
        {
            var sot = new DayOne();
            var result = sot.DetermineDistanceTraveled(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void testDetermineFirstRepeatLocation()
        {
            var sot = new DayOne();
            var result = sot.DetermineFirstRepeatLocation("R8, R4, R4, R10");

            Assert.Equal(4, result);
        }

        [Fact]
        public void testWithActualPartA()
        {
            var sot = new DayOne();
            var result = sot.DetermineDistanceTraveled(DayOne.PUZZLE_INPUT);

            Assert.Equal(273, result);
        }

        [Fact]
        public void testWithActualPartB()
        {
            var sot = new DayOne();
            var result = sot.DetermineFirstRepeatLocation(DayOne.PUZZLE_INPUT);

            Assert.Equal(115, result);
        }
    }
}