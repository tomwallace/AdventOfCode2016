using System.Security.Cryptography;
using Xunit;

namespace AdventOfCode2016.Tests
{
    public class DayFourteenTests
    {
        [Fact]
        public void testCreateMd5Hash()
        {
            var sut = new DayFourteen();
            MD5 md5Hash = MD5.Create();
            var result = sut.CreateMd5Hash(md5Hash, 13, "salt");
            Assert.True(result.Length > 0);
        }

        [Theory]
        [InlineData("abcdefg", 2, "")]
        [InlineData("adefaaadgrecf", 3, "a")]
        [InlineData("adefaaadgrecf", 4, "")]
        [InlineData("abbbbdefaaadgrecf", 3, "b")]
        public void testHashContainsLetterSequence(string input, int repeated, string expected)
        {
            var sut = new DayFourteen();
            var result = sut.LetterSequenceInHash(input, repeated);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("abcdefg", "a", 2, false)]
        [InlineData("adefaaadgrecf", "a", 3, true)]
        [InlineData("abbbbdefaaadgrecf", "z", 3, false)]
        public void testHashContainsSpecificLetterInSequence(string input, string letter, int repeated, bool expected)
        {
            var sut = new DayFourteen();
            var result = sut.HashContainsSpecificLetterInSequence(input, letter, repeated);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void testIndexOfLastCorrectKey()
        {
            var sut = new DayFourteen();
            var result = sut.IndexOfLastCorrectKey("abc", 64, false);

            Assert.Equal(22728, result);
        }

        [Fact]
        public void testCreateStretchedMd5Hash()
        {
            var sut = new DayFourteen();
            MD5 md5Hash = MD5.Create();
            var result = sut.CreateStretchedMd5Hash(md5Hash, 0, "abc");
            Assert.True(result.Contains("a107ff"));
        }

        // These tests take a while to run, so only uncomment if needed
        /*
        [Fact]
        public void testIndexOfLastCorrectKeyStretched()
        {
            var sut = new DayFourteen();
            var result = sut.IndexOfLastCorrectKey("abc", 64, true);

            Assert.Equal(22551, result);
        }
        */
        /*
        [Fact]
        public void testWithActualPartA()
        {
            var sut = new DayFourteen();
            var result = sut.IndexOfLastCorrectKey(DayFourteen.PUZZLE_INPUT, 64, false);

            Assert.Equal(15035, result);
        }
        */
        /*
        [Fact]
        public void testWithActualPartB()
        {
            var sut = new DayFourteen();
            var result = sut.IndexOfLastCorrectKey(DayFourteen.PUZZLE_INPUT, 64, true);

            Assert.Equal(19968, result);
        }
        */
    }
}