using AdventOfCode2016.TwentyOne;
using Xunit;

namespace AdventOfCode2016.Tests
{
    public class DayTwentyOneTests
    {
        [Theory]
        [InlineData("swap position 4 with position 0", "abcde", "ebcda")]
        [InlineData("swap position 4 with position 0", "ebcda", "abcde")]
        [InlineData("swap position 4 with position 0", "ebcda", "abcde")]
        [InlineData("instruction does not match", "staysSame", "staysSame")]
        public void testHandleSwapPosition(string input, string password, string expected)
        {
            var sut = new DayTwentyOne();
            var result = sut.HandleSwapPosition(input, password);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("swap letter d with letter b", "ebcda", "edcba")]
        [InlineData("swap letter d with letter b", "edcba", "ebcda")]
        [InlineData("instruction does not match", "staysSame", "staysSame")]
        public void testHandleSwapLetter(string input, string password, string expected)
        {
            var sut = new DayTwentyOne();
            var result = sut.HandleSwapLetter(input, password);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("rotate left 1 steps", "abcde", "bcdea", false)]
        [InlineData("rotate right 3 steps", "abcde", "cdeab", false)]
        [InlineData("rotate right 3 steps", "cdeab", "abcde", true)]
        [InlineData("instruction does not match", "staysSame", "staysSame", false)]
        public void testHandleRotateSteps(string input, string password, string expected, bool reverse)
        {
            var sut = new DayTwentyOne();
            var result = sut.HandleRotateSteps(input, password, reverse);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("rotate based on position of letter b", "abdec", "ecabd", false)]
        [InlineData("rotate based on position of letter c", "abdec", "cabde", false)]  // Rotated 6 times, so back to starting point + 1
        [InlineData("rotate based on position of letter c", "cabde", "abdec", true)]
        [InlineData("instruction does not match", "staysSame", "staysSame", false)]
        public void testHandleRotatePositionLetter(string input, string password, string expected, bool reverse)
        {
            var sut = new DayTwentyOne();
            var result = sut.HandleRotatePositionLetter(input, password, reverse);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("reverse positions 0 through 4", "edcba", "abcde")]
        [InlineData("reverse positions 2 through 3", "abdec", "abedc")]
        [InlineData("reverse positions 2 through 3", "abedc", "abdec")]
        [InlineData("instruction does not match", "staysSame", "staysSame")]
        public void testHandleReverse(string input, string password, string expected)
        {
            var sut = new DayTwentyOne();
            var result = sut.HandleReverse(input, password);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("move position 1 to position 4", "bcdea", "bdeac", false)]
        [InlineData("move position 1 to position 4", "bdeac", "bcdea", true)]
        [InlineData("move position 3 to position 0", "bdeac", "abdec", false)]
        [InlineData("instruction does not match", "staysSame", "staysSame", false)]
        public void testHandleMovePosition(string input, string password, string expected, bool reverse)
        {
            var sut = new DayTwentyOne();
            var result = sut.HandleMovePosition(input, password, reverse);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void testWithActualPartA()
        {
            var sut = new DayTwentyOne();
            var result = sut.ProcessPasswordInstructions("abcdefgh");

            Assert.Equal("dbfgaehc", result);
        }

        // Commented out because we are brute forcing it, so takes 18 sec to run
        /*
        [Fact]
        public void testWithActualPartB()
        {
            var sut = new DayTwentyOne();
            var result = sut.ReversePasswordInstructions("fbgdceah");

            Assert.Equal("aghfcdeb", result);
        }
        */
    }
}