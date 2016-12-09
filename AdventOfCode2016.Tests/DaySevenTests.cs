using AdventOfCode2016.Seven;
using Xunit;

namespace AdventOfCode2016.Tests
{
    public class DaySevenTests
    {
        [Theory]
        [InlineData("abbamnopqrst", true)]
        [InlineData("abcamnopcddc", true)]
        [InlineData("dfefmnoppppqrst", false)]
        public void testDoesStringContainAbba(string input, bool expected)
        {
            var sut = new DaySeven();
            var result = sut.DoesStringContainAbba(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("abba[mnop]qrst", 3)]
        [InlineData("abba[mnop]qrstabba[mnop]qrst", 5)]
        public void testSplitStringByBrackets(string input, int listSize)
        {
            var sut = new DaySeven();
            var result = sut.SplitStringByBrackets(input);

            Assert.Equal(listSize, result.Count);
        }

        [Theory]
        [InlineData("abba[mnop]qrst", true)]
        [InlineData("abcd[bddb]xyyx", false)]
        [InlineData("aaaa[qwer]tyui", false)]
        [InlineData("ioxxoj[asdfgh]zxcvbn", true)]
        public void testIsGoodIp(string input, bool expected)
        {
            var sut = new DaySeven();
            var result = sut.IsTlsIp(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("abaqbabxyz", 2)]
        [InlineData("aaaaaaaa", 0)]
        [InlineData("avcdeg", 0)]
        public void testFindStringAbas(string input, int listSize)
        {
            var sut = new DaySeven();
            var result = sut.FindStringAbas(input);

            Assert.Equal(listSize, result.Count);
        }

        [Theory]
        [InlineData("aba[bab]xyz", true)]
        [InlineData("xyx[xyx]xyx", false)]
        [InlineData("aaa[kek]eke", true)]
        [InlineData("zazbz[bzb]cdb", true)]
        public void testIsSslIp(string input, bool expected)
        {
            var sut = new DaySeven();
            var result = sut.IsSslIp(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void testWithActualPartA()
        {
            var sot = new DaySeven();
            var result = sot.CountIpsSupportTls();

            Assert.Equal(118, result);
        }

        [Fact]
        public void testWithActualPartB()
        {
            var sot = new DaySeven();
            var result = sot.CountIpsSupportSsl();

            Assert.Equal(260, result);
        }
    }
}