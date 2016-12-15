using System.Collections.Generic;
using Xunit;

namespace AdventOfCode2016.Tests
{
    public class DayThirteenTests
    {
        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(1, 0, false)]
        [InlineData(0, 1, true)]
        [InlineData(1, 3, false)]
        [InlineData(3, 4, true)]
        [InlineData(7, 5, true)]
        [InlineData(-7, 5, false)]
        [InlineData(7, -5, false)]
        public void testIsOpenSpace(int x, int y, bool expected)
        {
            var sot = new DayThirteen();
            var coord = new Coordinate(x, y);
            var result = sot.IsOpenSpace(coord, 10);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void testReachedDesintation()
        {
            var x = 1;
            var y = 2;
            var coord = new Coordinate(x, y);
            var mazeStep = new MazeStep(coord, 1, new List<Coordinate>());

            var destinationCoord = new Coordinate(x, y);
            Assert.True(mazeStep.ReachedDesintation(destinationCoord));
        }

        [Fact]
        public void testWithProvidedScenario()
        {
            var sot = new DayThirteen();
            var startCoord = new Coordinate(1, 1);
            var targetCoord = new Coordinate(7, 4);

            var result = sot.MinimumNumberOfStepsToCoordinates(startCoord, 10, targetCoord);

            Assert.Equal(11, result);
        }

        [Fact]
        public void testCoordinateComparer()
        {
            var coordOne = new Coordinate(1, 2);
            var coordTwo = new Coordinate(2, 1);
            var coordThree = new Coordinate(3, 4);
            var coordDup = new Coordinate(1, 2);
            var list = new List<Coordinate>() { coordOne, coordTwo, coordThree, coordDup };
            Assert.Equal(4, list.Count);

            var uniqueList = new HashSet<Coordinate>(list, new CoordinateEqualityComparer());
            Assert.Equal(3, uniqueList.Count);
        }

        [Fact]
        public void testWithActualPartA()
        {
            var sot = new DayThirteen();
            var startCoord = new Coordinate(1, 1);
            var targetCoord = new Coordinate(31, 39);

            var result = sot.MinimumNumberOfStepsToCoordinates(startCoord, DayThirteen.PUZZLE_INPUT, targetCoord);

            Assert.Equal(90, result);
        }

        // 1101 too high, 50 too low.  Not 110.  Not 112.  Not 119.  Not 106.  Answer should be 135
        [Fact]
        public void testWithActualPartB()
        {
            var sot = new DayThirteen();
            var startCoord = new Coordinate(1, 1);

            var result = sot.MaximumLocationsInNumberOfSteps(startCoord, DayThirteen.PUZZLE_INPUT, 50);

            Assert.Equal(135, result);
        }
    }
}