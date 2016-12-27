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

            Assert.True(cell.IsAvailable);
            Assert.Equal(4, cell.GoalNumber);
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

            var result = sut.CountOfMinimumStepsNeededForGoals(input, false);

            Assert.Equal(14, result);
        }

        // Takes about 30 sec to run, so only uncomment if necessary
        /*
        [Fact]
        public void testWithActualPartA()
        {
            var sut = new DayTwentyFour();

            var result = sut.CountOfMinimumStepsNeededForGoals(DayTwentyFour.PUZZLE_INPUT, false);

            Assert.Equal(500, result);
        }

        [Fact]
        public void testWithActualPartB()
        {
            var sut = new DayTwentyFour();

            var result = sut.CountOfMinimumStepsNeededForGoals(DayTwentyFour.PUZZLE_INPUT, true);

            Assert.Equal(748, result);
        }
        */
    }
}