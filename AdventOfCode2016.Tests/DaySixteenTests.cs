using System.Security.Cryptography;
using Xunit;

namespace AdventOfCode2016.Tests
{
    public class DaySixteenTests
    {
        [Theory]
        [InlineData("1", 3, "100")]
        [InlineData("0", 2, "00")]
        [InlineData("11111", 11, "11111000000")]
        [InlineData("111100001010", 25, "1111000010100101011110000")]
        public void testCreateDragonCurveOfWidth(string input, int width, string expected)
        {
            var sut = new DaySixteen();
            var result = sut.CreateDragonCurveOfWidth(width, input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void testCreateChecksum()
        {
            var sut = new DaySixteen();
            var result = sut.CreateCheckSum("110010110100");

            Assert.Equal("100", result);
        }

        [Fact]
        public void testCalculateCheckSumToFillDisk()
        {
            var sut = new DaySixteen();
            var result = sut.CalculateCheckSumToFillDisk("10000", 20);

            Assert.Equal("01100", result);
        }

        [Fact]
        public void testWithActualPartA()
        {
            var sut = new DaySixteen();
            var result = sut.CalculateCheckSumToFillDisk("11011110011011101", 272);

            Assert.Equal("00000100100001100", result);
        }

        /*
        // TODO: Need to get this to work more effieciently
        // Need to run this overnight
        [Fact]
        public void testWithActualPartB()
        {
            var sut = new DaySixteen();
            var result = sut.CalculateCheckSumToFillDisk("11011110011011101", 35651584);

            Assert.Equal("1", result);
        }
        */
    }
}