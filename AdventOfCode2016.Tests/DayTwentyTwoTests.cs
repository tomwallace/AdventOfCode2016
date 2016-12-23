using AdventOfCode2016.TwentyTwo;
using Xunit;

namespace AdventOfCode2016.Tests
{
    public class DayTwentyTwoTests
    {
        [Fact]
        public void testNodeConstructor()
        {
            var input = "/dev/grid/node-x0-y20     89T   65T    24T   73%";
            var node = new Node(input);
            Assert.Equal("/dev/grid/node-x0-y20", node.Id);
            Assert.Equal(0, node.X);
            Assert.Equal(20, node.Y);
            Assert.Equal(89, node.Size);
            Assert.Equal(65, node.Used);
            Assert.Equal(24, node.Avail);
            Assert.Equal(73, node.UsePercent);
        }

        [Theory]
        [InlineData(0, 19, 24, true)]
        [InlineData(0, 19, 25, false)]
        [InlineData(1, 20, 1, true)]
        [InlineData(2, 20, 1, false)] // to far
        [InlineData(0, 18, 1, false)]  // to far
        [InlineData(1, 19, 1, false)]  // diagnal
        public void testCanMoveTo(int moveX, int moveY, int used, bool expected)
        {
            var input = "/dev/grid/node-x0-y20     89T   65T    24T   73%";
            var node = new Node(input);

            var nodeMovingTo = new Node() { Used = used, X = moveX, Y = moveY };

            Assert.Equal(expected, node.CanMoveTo(nodeMovingTo));
        }

        [Fact]
        public void testWithActualPartA()
        {
            var sot = new DayTwentyTwo();
            var result = sot.CountViablePairsOfNodes();

            Assert.Equal(987, result);
        }

        // testWithActualPartB = 220 is the answer.  Figured it out using Excel spreadsheet, as way more complex to do via code
    }
}