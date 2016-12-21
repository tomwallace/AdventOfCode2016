using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2016.Twenty
{
    public class DayTwenty
    {
        public List<long> GetListValidIps()
        {
            List<string> blacklist = new List<string>();
            string line;
            StreamReader file = new StreamReader(@"Twenty\DayTwentyInput.txt");

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                blacklist.Add(line);
            }
            file.Close();

            List<long> result = GetSortedListOfValidIp(blacklist, 4294967295);
            return result;
        }

        public List<long> GetSortedListOfValidIp(List<string> blacklist, long maxVal)
        {
            List<IpRange> ipRanges = new List<IpRange>();
            List<long> validNumbers = new List<long>();

            foreach (string range in blacklist)
            {
                long low = Int64.Parse(range.Trim().Split('-')[0]);
                long high = Int64.Parse(range.Trim().Split('-')[1]);
                ipRanges.Add(new IpRange { High = high, Low = low });
            }

            long ipCounter = 0;

            while (ipCounter < maxVal)
            {
                bool valid = true;
                foreach (IpRange range in ipRanges)
                {
                    // Is valid, so keep checking
                    if (ipCounter < range.Low || ipCounter > range.High)
                        continue;

                    valid = false;
                    // Short circuit
                    ipCounter = range.High + 1;
                }

                if (!valid)
                    continue;

                validNumbers.Add(ipCounter);
                ipCounter++;
            }

            validNumbers.Sort();
            return validNumbers;
        }

        public class IpRange
        {
            public long Low;
            public long High;
        }
    }
}