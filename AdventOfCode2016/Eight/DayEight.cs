using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventOfCode2016.Eight
{
    public class DayEight
    {
        public readonly char LIT = '*';

        // 50 pixels wide and 5 tall
        public char[,] partAScreen = { { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                                       { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                                       { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                                       { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                                       { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', },
                                       { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', }};

        public long CountNumberOfLitPixels()
        {
            string line;
            StreamReader file = new StreamReader(@"Eight\DayEightInput.txt");

            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains("rect"))
                    Rect(line, partAScreen);

                if (line.Contains("row"))
                    RotateRow(line, partAScreen);

                if (line.Contains("column"))
                    RotateColumn(line, partAScreen);
            }
            file.Close();

            return CountLitPixelsOnScreen(partAScreen);
        }

        public void Rect(string input, char[,] screen)
        {
            // Parse key values - rect AxB
            List<string> sections = input.Split(' ').ToList<string>();
            List<string> numbers = sections[1].Split('x').ToList<string>();
            int width = Int32.Parse(numbers[0]);
            int height = Int32.Parse(numbers[1]);

            // Update the screen
            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < width; w++)
                {
                    screen[h, w] = LIT;
                }
            }
        }

        public void RotateRow(string input, char[,] screen)
        {
            // Parse key values - rect AxB
            List<string> sections = input.Split('=').ToList<string>();
            List<string> numbers = sections[1].Split(new string[] { " by " }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            int row = Int32.Parse(numbers[0]);
            int right = Int32.Parse(numbers[1]);

            // Update the screen
            for (int shift = 0; shift < right; shift++)
            {
                // Right most value to not double save it
                char rightMostValue = screen[row, screen.GetLength(1) - 1];
                for (int i = screen.GetLength(1) - 1; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        screen[row, i] = rightMostValue;
                    }
                    else
                    {
                        char leftPixelChar = screen[row, i - 1];
                        screen[row, i] = leftPixelChar;
                    }
                }
            }
        }

        public void RotateColumn(string input, char[,] screen)
        {
            // Parse key values - rect AxB
            List<string> sections = input.Split('=').ToList<string>();
            List<string> numbers = sections[1].Split(new string[] { " by " }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            int column = Int32.Parse(numbers[0]);
            int down = Int32.Parse(numbers[1]);

            // Update the screen
            for (int shift = 0; shift < down; shift++)
            {
                // Bottom most value to not double save it
                char bottomMostValue = screen[screen.GetLength(0) - 1, column];
                for (int i = screen.GetLength(0) - 1; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        screen[i, column] = bottomMostValue;
                    }
                    else
                    {
                        char upperPixelChar = screen[i - 1, column];
                        screen[i, column] = upperPixelChar;
                    }
                }
            }
        }

        public long CountLitPixelsOnScreen(char[,] screen)
        {
            long count = 0;

            // Iterate over the pixels
            for (int h = 0; h < screen.GetLength(0); h++)
            {
                for (int w = 0; w < screen.GetLength(1); w++)
                {
                    if (screen[h, w] == LIT)
                        count++;
                }
            }

            return count;
        }

        public void PrintScreen(char[,] screen)
        {
            for (int h = 0; h < screen.GetLength(0); h++)
            {
                string line = "";
                for (int w = 0; w < screen.GetLength(1); w++)
                {
                    line += screen[h, w];
                }
                Debug.WriteLine(line);
                string placeholder = "Gives a place for a breakpoint to stop and look at the output";
            }
        }
    }
}