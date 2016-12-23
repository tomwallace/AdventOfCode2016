using AdventOfCode2016.Nine;
using Xunit;

namespace AdventOfCode2016.Tests
{
    public class DayNineTests
    {
        [Theory]
        [InlineData("ADVENT", "ADVENT", 6)]
        [InlineData("A(1x5)BC", "ABBBBBC", 7)]
        [InlineData("(3x3)XYZ", "XYZXYZXYZ", 9)]
        [InlineData("A(2x2)BCD(2x2)EFG", "ABCBCDEFEFG", 11)]
        [InlineData("(6x1)(1x3)A", "(1x3)A", 6)]
        [InlineData("X(8x2)(3x3)ABCY", "X(3x3)ABC(3x3)ABCY", 18)]
        public void testDecompressInput(string input, string expected, int len)
        {
            var sut = new DayNine();
            var result = sut.DecompressInput(input);

            Assert.Equal(expected, result);
            Assert.Equal(len, sut.LengthOfInput(result));
        }

        [Theory]
        [InlineData("ADVENT", "ADVENT", 6)]
        [InlineData("A(1x5)BC", "ABBBBBC", 7)]
        [InlineData("(3x3)XYZ", "XYZXYZXYZ", 9)]
        [InlineData("X(8x2)(3x3)ABCY", "XABCABCABCABCABCABCY", 20)]
        public void testMaximumDecompressInput(string input, string expected, int len)
        {
            var sut = new DayNine();
            var result = sut.MaximumDecompressInput(input);

            Assert.Equal(expected, result);
            Assert.Equal(len, sut.LengthOfInput(result));
        }

        // These tests take a while to run, so only uncomment them if needed
        /*
        [Theory]
        [InlineData("(27x12)(20x12)(13x14)(7x10)(1x12)A", 241920)]
        [InlineData("(25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN", 445)]
        public void testMaximumDecompressInput_OnlyCountExamples(string input, int len)
        {
            var sut = new DayNine();
            var result = sut.MaximumDecompressInput(input);

            Assert.Equal(len, sut.LengthOfInput(result));
        }
        */

        [Fact]
        public void testWithActualPartA()
        {
            var sot = new DayNine();
            var result = sot.LengthOfDecompressedFile();

            Assert.Equal(183269, result);
        }

        [Fact]
        public void testWithActualPartB()
        {
            var sot = new DayNine();
            var result = sot.LengthOfMaximumDecompressedFile();

            Assert.Equal(11317278863, result);
        }
    }
}