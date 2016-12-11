using System.Security.Cryptography;
using Xunit;

namespace AdventOfCode2016.Tests
{
    public class DayFiveTests
    {
        // Note that this test takes a while to run, so be patient or comment out
        /*
        [Fact]
        public void testDetermineSecurityDoorPassword()
        {
            string input = "abc";
            var sot = new DayFive();
            var result = sot.DetermineSecurityDoorPassword(input);

            Assert.Equal("18f47a30", result);
        }
        */

        // Note that this test takes a while to run, so be patient or comment out
        /*
        [Fact]
        public void testDetermineSecurityDoorPasswordPartTwo()
        {
            string input = "abc";
            var sot = new DayFive();
            var result = sot.DetermineSecurityDoorPasswordPartTwo(input);

            Assert.Equal("05ace8e3", result);
        }

        [Fact]
        public void testGetMd5Hash()
        {
            string input = "abc3231929";
            MD5 md5Hash = MD5.Create();
            var sot = new DayFive();
            var result = sot.GetMd5Hash(md5Hash, input);

            Assert.True(result.Substring(0, 5) == "00000");
        }

        [Theory]
        [InlineData("--------", "000001bcde", "-b------")]
        [InlineData("-b------", "000001zcde", "-b------")]
        [InlineData("-b------", "000000bcde", "bb------")]
        [InlineData("-b------", "00000fbcde", "-b------")]
        [InlineData("-b------", "000009bcde", "-b------")]
        public void testHandleResultUpdate(string currentPassword, string currentHash, string expected)
        {
            var sot = new DayFive();
            var result = sot.HandleResultUpdate(currentPassword, currentHash);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void testWithActualPartA()
        {
            var sot = new DayFive();
            var result = sot.DetermineSecurityDoorPassword(DayFive.PUZZLE_INPUT);

            Assert.Equal("d4cd2ee1", result);
        }

        [Fact]
        public void testWithActualPartB()
        {
            var sot = new DayFive();
            var result = sot.DetermineSecurityDoorPasswordPartTwo(DayFive.PUZZLE_INPUT);

            Assert.Equal("f2c730e5", result);
        }
        */
    }
}