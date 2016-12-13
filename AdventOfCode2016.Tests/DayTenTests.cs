using AdventOfCode2016.Ten;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace AdventOfCode2016.Tests
{
    public class DayTenTests
    {
        [Fact]
        public void testZoomingBotConstructor()
        {
            var zoomingBot = new ZoomingBot(23, new List<int>());
            Assert.Equal(23, zoomingBot.GetId());
        }

        [Fact]
        public void testZoomingBotAdd()
        {
            var zoomingBot = new ZoomingBot(23, new List<int>());
            zoomingBot.AddMicroChip(1);
            Assert.True(zoomingBot.HasMicroChips(new List<int>() { 1 }));
            zoomingBot.AddMicroChip(2);
            Assert.True(zoomingBot.HasMicroChips(new List<int>() { 1, 2 }));
        }

        [Fact]
        public void testZoomingBotAdd_ThrowsException()
        {
            var zoomingBot = new ZoomingBot(23, new List<int>());
            zoomingBot.AddMicroChip(1);
            zoomingBot.AddMicroChip(2);
            Assert.Throws<ArgumentOutOfRangeException>(() => zoomingBot.AddMicroChip(3));
        }

        [Fact]
        public void testZoomingBotGive()
        {
            var zoomingBot = new ZoomingBot(23, new List<int>());
            zoomingBot.AddMicroChip(1);
            zoomingBot.AddMicroChip(2);
            var low = zoomingBot.GiveMicroChip(false);
            Assert.Equal(1, low);
            zoomingBot.AddMicroChip(11);
            var high = zoomingBot.GiveMicroChip(true);
            Assert.Equal(11, high);
        }

        [Fact]
        public void testZoomingBotGive_ThrowsException()
        {
            var zoomingBot = new ZoomingBot(23, new List<int>());
            Assert.Throws<ArgumentOutOfRangeException>(() => zoomingBot.GiveMicroChip(true));
        }

        [Fact]
        public void testWithListedTestCase()
        {
            var sot = new DayTen();
            var microChipsItHas = new List<int>() { 5, 2 };

            var instructions = new List<string>
            {
                "value 5 goes to bot 2",
                "bot 2 gives low to bot 1 and high to bot 0",
                "value 3 goes to bot 1",
                "bot 1 gives low to output 1 and high to bot 0",
                "bot 0 gives low to output 2 and high to output 0",
                "value 2 goes to bot 2"
            };

            var result = sot.GetNumberOfBotResponsible(microChipsItHas, instructions);

            Assert.Equal(2, result);
            Assert.Equal(5, sot.outputs[0]);
            Assert.Equal(2, sot.outputs[1]);
            Assert.Equal(3, sot.outputs[2]);
        }

        [Fact]
        public void testWithActualPartA()
        {
            var sot = new DayTen();
            var microChipsItHas = new List<int>() { 17, 61 };

            var instructions = new List<string>();
            string line;
            StreamReader file = new StreamReader(@"Ten\DayTenInput.txt");

            // Iterate over each line in the input and gather them
            while ((line = file.ReadLine()) != null)
            {
                instructions.Add(line);
            }
            file.Close();

            var result = sot.GetNumberOfBotResponsible(microChipsItHas, instructions);

            Assert.Equal(161, result);
        }

        [Fact]
        public void testWithActualPartB()
        {
            var sot = new DayTen();
            var microChipsItHas = new List<int>() { 17, 61 };

            var instructions = new List<string>();
            string line;
            StreamReader file = new StreamReader(@"Ten\DayTenInput.txt");

            // Iterate over each line in the input and gather them
            while ((line = file.ReadLine()) != null)
            {
                instructions.Add(line);
            }
            file.Close();

            sot.GetNumberOfBotResponsible(microChipsItHas, instructions);

            long result = sot.outputs[0] * sot.outputs[1] * sot.outputs[2];

            Assert.Equal(133163, result);
        }
    }
}