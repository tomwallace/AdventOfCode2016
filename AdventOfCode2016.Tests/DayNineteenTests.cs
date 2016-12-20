using Xunit;

namespace AdventOfCode2016.Tests
{
    public class DayNineteenTests
    {
        [Fact]
        public void testGetPositionWithAllTheGifts()
        {
            var sot = new DayNineteen();
            var result = sot.GetPositionWithAllTheGifts(5);

            Assert.Equal(3, result);
        }

        [Fact]
        public void testAcrossGetPositionWithAllTheGifts()
        {
            var sot = new DayNineteen();
            var result = sot.AcrossGetPositionWithAllTheGifts(5);

            Assert.Equal(2, result);
        }

        [Theory]
        [InlineData(4, 1, 3)]
        [InlineData(4, 2, 4)]
        [InlineData(4, 3, 1)]
        [InlineData(4, 4, 2)]
        [InlineData(5, 1, 3)]
        [InlineData(5, 2, 4)]
        [InlineData(5, 3, 5)]
        [InlineData(5, 4, 1)]
        [InlineData(5, 5, 2)]
        public void testPositionAcrossCircle(int numberInCircle, int currentPosition, int halfWay)
        {
            var sot = new DayNineteen();
            var result = sot.PositionAcrossCircle(numberInCircle, currentPosition);

            Assert.Equal(halfWay, result);
        }

        [Fact]
        public void testWithActualPartA()
        {
            var sot = new DayNineteen();
            var result = sot.GetPositionWithAllTheGifts(DayNineteen.PUZZLE_INPUT);

            Assert.Equal(1830117, result);
        }

        // TODO: This is wrong - need to approach it without a list I think
        // Not 1, 31682 is too low
        // This test took 374 minutes to run, so only uncomment when ready
        [Fact]
        public void testWithActualPartB()
        {
            var sot = new DayNineteen();
            var result = sot.AcrossGetPositionWithAllTheGifts(DayNineteen.PUZZLE_INPUT);

            Assert.Equal(1417887, result);
        }
    }
}