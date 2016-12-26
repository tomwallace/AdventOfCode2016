using System.Collections.Generic;
using Xunit;

namespace AdventOfCode2016.Tests
{
    public class DayTwentyFourTests
    {
        [Fact]
        public void testInitializeMaze()
        {
            string input = @"###########
#0.1.....2#
#.#######.#
#4.......3#
###########";
            var sut = new DayTwentyFour();

            var maze = sut.InitializeMaze(input);

            Assert.Equal(5, maze.Count);
            Assert.Equal(11, maze[0].Count);

            var cell = maze[3][1];

            Assert.Equal("31", cell.Id);
            Assert.True(cell.IsOpen);
            Assert.Equal(4, cell.TargetNumber);
            Assert.Equal(2, cell.Connected.Count);
        }

        [Fact]
        public void testCountOfMinimumStepsNeededForGoals()
        {
            string input = @"###########
#0.1.....2#
#.#######.#
#4.......3#
###########";
            var sut = new DayTwentyFour();

            var result = sut.CountOfMinimumStepsNeededForGoals(input);

            Assert.Equal(14, result);
        }

        /*
        [Fact]
        public void testWithActualPartA()
        {
            var sut = new DayTwentyFour();

            var result = sut.CountOfMinimumStepsNeededForGoals(DayTwentyFour.PUZZLE_INPUT);

            Assert.Equal(11, result);
        }
        */
        /*
        [Theory]
        [InlineData("aaaaa-bbb-z-y-x-123[abxyz]", true)]
        [InlineData("z-x-bbbb-aaaaa-y-123[abxyz]", true)]
        [InlineData("a-b-c-d-e-f-g-h-987[abcde]", true)]
        [InlineData("not-a-real-room-404[oarel]", true)]
        [InlineData("totally-real-room-200[decoy]", false)]
        public void testIsReal(string input, bool expected)
        {
            EncryptedRoom room = new EncryptedRoom(input);

            Assert.Equal(expected, room.IsReal());
        }

        [Theory]
        [InlineData("qzmt-zixmtkozy-ivhz-343[abxyz]", "very encrypted name")]
        public void testDecryptedName(string input, string expected)
        {
            EncryptedRoom room = new EncryptedRoom(input);

            Assert.Equal(expected, room.decryptedName);
        }

        [Fact]
        public void testWithActualPartA()
        {
            var sot = new DayFour();
            var result = sot.GetSumOfRealRoomSectorIds(DayFour.PUZZLE_INPUT);

            Assert.Equal(361724, result);
        }

        [Fact]
        public void testWithActualPartB()
        {
            var sot = new DayFour();
            var result = sot.ListRealRooms(DayFour.PUZZLE_INPUT);
            var filteredList = result.FindAll(r => r.decryptedName.Contains("north"));

            Assert.Equal(1, filteredList.Count);
            Assert.Equal(482, filteredList[0].sectorId);
        }
        */
    }
}