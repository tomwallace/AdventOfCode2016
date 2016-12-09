using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016.Seven
{
    public class DaySeven
    {
        public long CountIpsSupportTls()
        {
            long numberGoodIps = 0;
            string line;
            StreamReader file = new StreamReader(@"Seven\DaySevenInput.txt");

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                if (IsTlsIp(line))
                    numberGoodIps++;
            }
            file.Close();

            return numberGoodIps;
        }

        public long CountIpsSupportSsl()
        {
            long numberGoodIps = 0;
            string line;
            StreamReader file = new StreamReader(@"Seven\DaySevenInput.txt");

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                if (IsSslIp(line))
                    numberGoodIps++;
            }
            file.Close();

            return numberGoodIps;
        }

        public bool IsTlsIp(string input)
        {
            bool goodAbba = false;
            bool badAbba = false;
            List<string> splitLine = SplitStringByBrackets(input);
            for (int i = 0; i < splitLine.Count; i++)
            {
                // Even i = outside of brackets.  Odd i = inside brackets
                if (DoesStringContainAbba(splitLine[i]))
                {
                    if (i % 2 != 0)
                        badAbba = true;
                    else
                        goodAbba = true;
                }
            }
            // If there is a goodAbba and no badAbba, then the IP supports TLS
            return (goodAbba == true && badAbba == false);
        }

        public bool IsSslIp(string input)
        {
            List<string> abas = new List<string>();
            List<string> babs = new List<string>();
            List<string> splitLine = SplitStringByBrackets(input);
            for (int i = 0; i < splitLine.Count; i++)
            {
                // Even i = outside of brackets.  Odd i = inside brackets
                List<string> matches = FindStringAbas(splitLine[i]);
                if (i % 2 != 0)
                    babs.AddRange(matches);
                else
                    abas.AddRange(matches);
            }

            // Now we need to determine if any abas are in the lists of babs, reversed of course
            foreach (string aba in abas)
            {
                List<char> abaChars = aba.ToList<char>();
                string reverse = $"{abaChars[1]}{abaChars[0]}{abaChars[1]}";
                if (babs.Contains(reverse))
                    return true;
            }

            return false;
        }

        public List<string> SplitStringByBrackets(string input)
        {
            List<string> split = input.Split(new string[] { "[", "]" }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            return split;
        }

        public bool DoesStringContainAbba(string input)
        {
            for (int i = 0; i < input.Count(); i++)
            {
                if (i >= 3)
                {
                    if (input[i] == input[i - 3] && input[i - 1] == input[i - 2] && input[i] != input[i - 1])
                        return true;
                }
            }

            return false;
        }

        public List<string> FindStringAbas(string input)
        {
            List<string> abas = new List<string>();
            for (int i = 0; i < input.Count(); i++)
            {
                if (i >= 2)
                {
                    if (input[i] == input[i - 2] && input[i] != input[i - 1])
                        abas.Add(input.Substring(i - 2, 3));
                }
            }

            return abas;
        }
    }
}