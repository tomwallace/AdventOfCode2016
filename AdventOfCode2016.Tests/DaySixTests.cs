using Xunit;

namespace AdventOfCode2016.Tests
{
    public class DaySixTests
    {
        [Fact]
        public void testGetErrorCorrectedMessageA()
        {
            var input = @"eedadn
drvtee
eandsr
raavrd
atevrs
tsrnev
sdttsa
rasrtv
nssdts
ntnada
svetve
tesnvt
vntsnd
vrdear
dvrsen
enarar";
            var sot = new DaySix();
            var resultDesc = sot.GetErrorCorrectedMessage(input, false);
            Assert.Equal("easter", resultDesc);

            var resultAsc = sot.GetErrorCorrectedMessage(input, true);
            Assert.Equal("advent", resultAsc);
        }

        [Fact]
        public void testWithActualPartA()
        {
            var sot = new DaySix();
            var result = sot.GetErrorCorrectedMessage(DaySix.PUZZLE_INPUT, false);

            Assert.Equal("asvcbhvg", result);
        }

        [Fact]
        public void testWithActualPartB()
        {
            var sot = new DaySix();
            var result = sot.GetErrorCorrectedMessage(DaySix.PUZZLE_INPUT, true);

            Assert.Equal("odqnikqv", result);
        }
    }
}