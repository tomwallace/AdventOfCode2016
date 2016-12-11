using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2016.Nine
{
    public class DayNine
    {
        public long LengthOfDecompressedFile()
        {
            StreamReader file = new StreamReader(@"Nine\DayNineInput.txt");
            // Only one line in this input
            string line = file.ReadLine();
            file.Close();

            // Decompress the string
            string decompressed = DecompressInput(line);
            return LengthOfInput(decompressed);
        }

        public long LengthOfMaximumDecompressedFile()
        {
            StreamReader file = new StreamReader(@"Nine\DayNineInput.txt");
            // Only one line in this input
            string line = file.ReadLine();
            file.Close();

            // Decompress the string
            string decompressed = MaximumDecompressInput(line);
            return LengthOfInput(decompressed);
        }

        public string MaximumDecompressInput(string input)
        {
            // We need to keep cycling through decompression until the string has no more compression sequences
            string result = input;
            string finalResult = "";
            do
            {
                string decompressedValue = DecompressInput(result);
                // We can trim off anything up to the next '(' so we don't have to keep processing the whole string again
                if (decompressedValue.Contains('('))
                {
                    var index = decompressedValue.IndexOf('(');
                    finalResult += decompressedValue.Substring(0, index);
                    result = decompressedValue.Substring(index);
                }
                else
                {
                    result = decompressedValue;
                    finalResult += result;
                }
            } while (result.Contains('('));

            return finalResult;
        }

        public string DecompressInput(string input)
        {
            string result = "";

            List<char> chars = input.ToList<char>();
            for (int i = 0; i < input.Length; i++)
            {
                // Look for a ( which may indicate the start of a compression sequence
                if (chars[i] == '(')
                {
                    // Find the end of the compression sequence
                    string compSequence = "";
                    int c = i + 1;
                    char letter = chars[c];
                    do
                    {
                        compSequence += letter;
                        c++;
                        letter = chars[c];
                    } while (letter != ')');

                    // Split comp sequence
                    List<string> numbers = compSequence.Split('x').ToList<string>();
                    int numberCharaters = Int32.Parse(numbers[0]);
                    int repeat = Int32.Parse(numbers[1]);

                    // Determine the sequence for repeating and repeat it
                    string toBeRepeated = input.Substring(c + 1, numberCharaters);
                    for (int q = 0; q < repeat; q++)
                    {
                        result += toBeRepeated;
                    }

                    // Increment the overall counter i to start with character after the sequence
                    i = c + numberCharaters;
                }
                else
                {
                    result += chars[i];
                }
            }

            return result;
        }

        public long LengthOfInput(string input)
        {
            return input.Length;
        }
    }
}