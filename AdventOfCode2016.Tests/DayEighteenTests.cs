using System.Collections.Generic;
using Xunit;

namespace AdventOfCode2016.Tests
{
    public class DayEighteenTests
    {
        [Theory]
        [InlineData(0, '.')]
        [InlineData(1, '^')]
        [InlineData(2, '^')]
        [InlineData(3, '^')]
        [InlineData(4, '^')]
        public void testCreateTile(int col, char expected)
        {
            List<char> rowOne = new List<char>() { '.', '.', '^', '^', '.' };

            var sot = new DayEighteen();

            var result = sot.CreateTile(rowOne, col);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void testCountOfSafeTilesInRows()
        {
            string rowOne = ".^^.^.^^^^";

            var sot = new DayEighteen();

            var result = sot.CountOfSafeTilesInRows(rowOne, 10);
            Assert.Equal(38, result);
        }

        [Fact]
        public void testWithActualPartA()
        {
            var sot = new DayEighteen();

            var result = sot.CountOfSafeTilesInRows(DayEighteen.PUZZLE_INPUT, 40);
            Assert.Equal(2016, result);
        }

        [Fact]
        public void testWithActualPartB()
        {
            var sot = new DayEighteen();

            var result = sot.CountOfSafeTilesInRows(DayEighteen.PUZZLE_INPUT, 400000);
            Assert.Equal(19998750, result);
        }
    }
}