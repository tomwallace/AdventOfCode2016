using AdventOfCode2016.Eight;
using Xunit;

namespace AdventOfCode2016.Tests
{
    public class DayEightTests
    {
        [Fact]
        public void testRect()
        {
            char[,] screen = { { '.', '.', '.', '.', '.', '.', '.' },
                               { '.', '.', '.', '.', '.', '.', '.' },
                               { '.', '.', '.', '.', '.', '.', '.' }};

            var input = "rect 3x2";
            var sot = new DayEight();
            sot.Rect(input, screen);

            var litPixels = sot.CountLitPixelsOnScreen(screen);

            Assert.Equal(6, litPixels);
        }

        [Fact]
        public void testRect_ExistingLit()
        {
            char[,] screen = { { '.', '.', '.', '.', '.', '*', '.' },
                               { '.', '.', '.', '.', '.', '*', '.' },
                               { '.', '.', '.', '.', '.', '*', '.' }};

            var input = "rect 3x2";
            var sot = new DayEight();
            sot.Rect(input, screen);

            var litPixels = sot.CountLitPixelsOnScreen(screen);

            Assert.Equal(9, litPixels);
        }

        [Fact]
        public void testRotateRow()
        {
            char[,] screen = { { '.', '.', '.', '.', '.', '.', '.' },
                               { '.', '.', '*', '.', '*', '*', '*' },
                               { '.', '.', '.', '.', '.', '.', '.' }};

            var input = "rotate row y=1 by 2";
            var sot = new DayEight();
            sot.RotateRow(input, screen);

            Assert.Equal('*', screen[1, 0]);
            Assert.Equal('*', screen[1, 1]);
            Assert.Equal('.', screen[1, 2]);
            Assert.Equal('.', screen[1, 3]);
            Assert.Equal('*', screen[1, 4]);
            Assert.Equal('.', screen[1, 5]);
            Assert.Equal('*', screen[1, 6]);

            var litPixels = sot.CountLitPixelsOnScreen(screen);
            Assert.Equal(4, litPixels);
        }

        [Fact]
        public void testRotateColumn()
        {
            char[,] screen = { { '.', '.', '.', '.', '.', '.', '.' },
                               { '.', '.', '*', '.', '.', '.', '.' },
                               { '.', '.', '*', '.', '.', '.', '.' }};

            var input = "rotate column x=2 by 1";
            var sot = new DayEight();
            sot.RotateColumn(input, screen);

            Assert.Equal('*', screen[0, 2]);
            Assert.Equal('.', screen[1, 2]);
            Assert.Equal('*', screen[2, 2]);

            var litPixels = sot.CountLitPixelsOnScreen(screen);
            Assert.Equal(2, litPixels);
        }

        [Fact]
        public void testWithActualPartA()
        {
            var sot = new DayEight();
            var result = sot.CountNumberOfLitPixels();

            Assert.Equal(116, result);

            sot.PrintScreen(sot.partAScreen);
            // Result of the print screen was = UPOJFLBCEZ
            // Had to copy into a text editor to zoom and see better
        }
    }
}