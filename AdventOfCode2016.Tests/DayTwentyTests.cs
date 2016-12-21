using AdventOfCode2016.Twenty;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode2016.Tests
{
    public class DayTwentyTests
    {
        [Fact]
        public void testLowestClearIp()
        {
            var input = new List<string>
            {
                "5-8",
                "0-2",
                "4-7"
            };
            var sot = new DayTwenty();
            var result = sot.GetSortedListOfValidIp(input, 9);
            Assert.Equal(3, result[0]);
        }

        [Fact]
        public void testWithActualPartA()
        {
            var sot = new DayTwenty();
            var result = sot.GetListValidIps();

            Assert.Equal(14975795, result[0]);
        }

        [Fact]
        public void testWithActualPartB()
        {
            var sot = new DayTwenty();
            var result = sot.GetListValidIps();

            Assert.Equal(101, result.Count);
        }
    }
}