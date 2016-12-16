using System.Collections.Generic;
using System.Security.Cryptography;
using Xunit;

namespace AdventOfCode2016.Tests
{
    public class DayFifteenTests
    {
        [Theory]
        [InlineData(5, 0, 20, true)]
        [InlineData(5, 1, 20, false)]
        [InlineData(3, 2, 7, true)]
        [InlineData(5, 4, 1, true)]
        [InlineData(2, 1, 2, false)]
        public void testSlotAvailableAtTime(long positions, long startPosition, long time, bool expected)
        {
            var disc = new KineticDisc(positions, startPosition);
            var result = disc.SlotAvailableAtTime(time);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void testMinimumTimeToGetThroughAllDiscs()
        {
            var sut = new DayFifteen();
            var discs = new List<KineticDisc>()
            {
                new KineticDisc(5, 4),
                new KineticDisc(2, 1)
            };
            var result = sut.MinimumTimeToGetThroughAllDiscs(discs);

            Assert.Equal(5, result);
        }

        [Fact]
        public void testWithActualPartA()
        {
            var sut = new DayFifteen();
            var discs = new List<KineticDisc>()
            {
                new KineticDisc(17, 1),
                new KineticDisc(7, 0),
                new KineticDisc(19, 2),
                new KineticDisc(5, 0),
                new KineticDisc(3, 0),
                new KineticDisc(13, 5)
            };
            var result = sut.MinimumTimeToGetThroughAllDiscs(discs);

            Assert.Equal(317371, result);
        }

        [Fact]
        public void testWithActualPartB()
        {
            var sut = new DayFifteen();
            var discs = new List<KineticDisc>()
            {
                new KineticDisc(17, 1),
                new KineticDisc(7, 0),
                new KineticDisc(19, 2),
                new KineticDisc(5, 0),
                new KineticDisc(3, 0),
                new KineticDisc(13, 5),
                new KineticDisc(11, 0)
            };
            var result = sut.MinimumTimeToGetThroughAllDiscs(discs);

            Assert.Equal(2080951, result);
        }
    }
}