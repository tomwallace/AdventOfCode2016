using Xunit;

namespace AdventOfCode2016.Tests
{
    public class DayFourTests
    {
        [Fact]
        public void testEncryptedRoomConstructor()
        {
            string input = "aaaaa-bbb-z-y-x-123[abxyz]";
            EncryptedRoom room = new EncryptedRoom(input);

            Assert.Equal("abxyz", room.checksum);
            Assert.Equal(123, room.sectorId);
            Assert.Equal(5, room.letterCount['a']);
            Assert.Equal(3, room.letterCount['b']);
            Assert.Equal(1, room.letterCount['z']);
            Assert.Equal(1, room.letterCount['y']);
            Assert.Equal(1, room.letterCount['z']);
        }

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
    }
}