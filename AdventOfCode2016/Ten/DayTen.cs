using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2016.Ten
{
    public class DayTen
    {
        private List<ZoomingBot> _zoomingBots = new List<ZoomingBot>();
        public Dictionary<int, int> outputs = new Dictionary<int, int>();
        private List<string> _instructions = new List<string>();

        public int GetNumberOfBotResponsible(List<int> microChipsItHas, List<string> instructions)
        {
            int result = 0;
            _instructions = instructions;
            do
            {
                List<string> copyInst = _instructions.ToList<string>();
                foreach (string instruction in copyInst)
                {
                    // If a bot has the requested microchips, that is the answer
                    foreach (ZoomingBot bot in _zoomingBots)
                    {
                        if (bot.HasMicroChips(microChipsItHas))
                            result = bot.GetId();
                    }

                    if (instruction.Contains("goes"))
                    {
                        ProcessSeedingLine(instruction);
                        _instructions.Remove(instruction);
                    }
                    else
                    {
                        // Remove the instruction after processing if return true
                        if (ProcessInstructionLineAndOkToDelete(instruction))
                        {
                            _instructions.Remove(instruction);
                        }
                    }
                }
            } while (_instructions.Count() > 0);

            return result;
        }

        public void ProcessSeedingLine(string line)
        {
            // Initial giving of microChip to bot
            List<string> splitOnGoes = line.Split(new string[] { "goes" }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            int microChip = GetIdAtEndOfString(splitOnGoes[0]);
            int botId = GetIdAtEndOfString(splitOnGoes[1]);

            ZoomingBot zoomingBot = CreateZoomingBotIfDoesNotExist(botId);

            // Add microchip
            zoomingBot.AddMicroChip(microChip);
        }

        public bool ProcessInstructionLineAndOkToDelete(string line)
        {
            // Bot gives microChips to something else
            List<string> splitOnGives = line.Split(new string[] { "gives" }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            int givingBotId = GetIdAtEndOfString(splitOnGives[0]);
            ZoomingBot givingBot = CreateZoomingBotIfDoesNotExist(givingBotId);
            // If the bot does not have two microChips, then leave on instruction list
            if (givingBot.CountMicroChips() != 2)
                return false;

            string secondSection = splitOnGives[1].Trim();
            List<string> splitOnAnd = secondSection.Split(new string[] { "and" }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();

            // First receiver
            string andFirstSection = splitOnAnd[0].Trim();
            bool firstIsHigh = andFirstSection.Contains("high");
            int firstMicroChip = givingBot.GiveMicroChip(firstIsHigh);
            // If there is a receiving bot, then give the microchip, otherwise goes to output which is ignored
            if (andFirstSection.Contains("bot"))
            {
                int receivingId = GetIdAtEndOfString(andFirstSection);
                ZoomingBot receivingBot = CreateZoomingBotIfDoesNotExist(receivingId);
                receivingBot.AddMicroChip(firstMicroChip);
            }
            else
            {
                int receivingId = GetIdAtEndOfString(andFirstSection);
                outputs.Add(receivingId, firstMicroChip);
            }

            // Second receiver
            string andSecondSection = splitOnAnd[1].Trim();
            bool secondIsHigh = andFirstSection.Contains("high");
            int secondMicroChip = givingBot.GiveMicroChip(secondIsHigh);
            // If there is a receiving bot, then give the microchip, otherwise goes to output which is ignored
            if (andSecondSection.Contains("bot"))
            {
                int receivingId = GetIdAtEndOfString(andSecondSection);
                ZoomingBot receivingBot = CreateZoomingBotIfDoesNotExist(receivingId);
                receivingBot.AddMicroChip(secondMicroChip);
            }
            else
            {
                int receivingId = GetIdAtEndOfString(andSecondSection);
                outputs.Add(receivingId, secondMicroChip);
            }

            return true;
        }

        private ZoomingBot GetZoomingBotFromCollection(int botId)
        {
            return _zoomingBots.Find(b => b.GetId() == botId);
        }

        private ZoomingBot CreateZoomingBotIfDoesNotExist(int botId)
        {
            ZoomingBot zoomingBot = GetZoomingBotFromCollection(botId);
            // If bot does not exist, create it
            if (zoomingBot == null)
            {
                zoomingBot = new ZoomingBot(botId, new List<int>());
                _zoomingBots.Add(zoomingBot);
            }
            return zoomingBot;
        }

        private int GetIdAtEndOfString(string input)
        {
            string trimmed = input.Trim();
            List<string> splitBySpaces = trimmed.Split(' ').ToList<string>();
            return Int32.Parse(splitBySpaces[splitBySpaces.Count() - 1]);
        }
    }

    public class ZoomingBot
    {
        private int Id;

        private List<int> MicroChips;

        public ZoomingBot(int id, List<int> microChips)
        {
            Id = id;
            MicroChips = microChips;
        }

        public int GetId()
        {
            return Id;
        }

        public int CountMicroChips()
        {
            return MicroChips.Count();
        }

        public void AddMicroChip(int microChip)
        {
            if (MicroChips.Count >= 2)
                throw new ArgumentOutOfRangeException($"Bot {Id} already has a full collection of microchips and cannot add another");

            // Need to maintain order of chips
            MicroChips.Add(microChip);
            MicroChips.Sort();
        }

        // Gives the high or low chip
        public int GiveMicroChip(bool giveHigh)
        {
            if (MicroChips.Count == 0)
                throw new ArgumentOutOfRangeException($"Bot {Id} has no microchips to give");

            int index = giveHigh ? MicroChips.Count() - 1 : 0;
            int chipToReturn = MicroChips[index];
            MicroChips.RemoveAt(index);
            return chipToReturn;
        }

        public bool HasMicroChips(List<int> microChipInputs)
        {
            bool result = true;
            foreach (int chip in microChipInputs)
            {
                if (!MicroChips.Contains(chip))
                    result = false;
            }

            return result;
        }
    }
}