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
        [InlineData("10000", 11, "10000011110")]
        [InlineData("10000", 17, "10000011110010000")]
        [InlineData("10000", 18, "100000111100100001")]
        [InlineData("10000", 23, "10000011110010000111110")]
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

        // Takes a while to run, so only uncomment if needed
        /*
        [Fact]
        public void testWithActualPartB()
        {
            var sut = new DaySixteen();
            var result = sut.CalculateCheckSumToFillDisk("11011110011011101", 35651584);

            Assert.Equal("00011010100010010", result);
        }
        */
    }
}