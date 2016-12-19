using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Xunit;

namespace AdventOfCode2016.Tests
{
    public class DaySeventeenTests
    {
        [Fact]
        public void testOpenDoorsForRoom()
        {
            string input = "hijkl";

            var sot = new DaySeventeen();
            MD5 md5Hash = MD5.Create();

            var result = sot.OpenDoorsForRoom(input, md5Hash);

            string expected = "OOOC";
            List<char> list = expected.ToList<char>();
            Assert.Equal(list, result);
        }

        [Theory]
        [InlineData("ihgpwlah", "DDRRRD")]
        [InlineData("kglvqrro", "DDUDRLRRUDRD")]
        [InlineData("ulqzkmiv", "DRURDRUDDLLDLUURRDULRLDUUDDDRR")]
        public void testFindShortestPathThroughGrid(string input, string expected)
        {
            var sot = new DaySeventeen();
            var result = sot.FindShortestPathThroughGrid(input, 3, 3);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void testWithActualPartA()
        {
            var sot = new DaySeventeen();
            var result = sot.FindShortestPathThroughGrid(DaySeventeen.PUZZLE_INPUT, 3, 3);

            Assert.Equal("RDDRULDDRR", result);
        }

        [Fact]
        public void testWithActualPartB()
        {
            var sot = new DaySeventeen();
            var result = sot.FindLongestPathThroughGrid(DaySeventeen.PUZZLE_INPUT, 3, 3);

            Assert.Equal(766, result);
        }
    }
}