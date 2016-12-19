using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2016
{
    public class DayEighteen
    {
        public static string PUZZLE_INPUT = "^..^^.^^^..^^.^...^^^^^....^.^..^^^.^.^.^^...^.^.^.^.^^.....^.^^.^.^.^.^.^.^^..^^^^^...^.....^....^.";

        public List<List<char>> _tiles = new List<List<char>>();

        public static char TRAP = '^';
        public static char SAFE = '.';

        public int CountOfSafeTilesInRows(string input, int lastRow)
        {
            List<char> firstRow = input.ToList<char>();
            int countSafeTiles = firstRow.FindAll(c => c == SAFE).Count;

            List<char> prevRow = firstRow;

            for (int i = 1; i < lastRow; i++)
            {
                List<char> currentRow = new List<char>();
                for (int col = 0; col < firstRow.Count; col++)
                {
                    char tile = CreateTile(prevRow, col);
                    if (tile == SAFE)
                        countSafeTiles++;

                    currentRow.Add(tile);
                }
                prevRow = currentRow;
            }

            return countSafeTiles;
            ;
        }

        public char CreateTile(List<char> prevRow, int col)
        {
            char topLeft = col == 0 ? '0' : prevRow[col - 1];
            char topMid = prevRow[col];
            char topRight = col == prevRow.Count - 1 ? '0' : prevRow[col + 1];

            if (topLeft == TRAP && topMid == TRAP && topRight != TRAP)
                return TRAP;

            if (topMid == TRAP && topRight == TRAP && topLeft != TRAP)
                return TRAP;

            if (topLeft == TRAP && topMid == SAFE && topRight != TRAP)
                return TRAP;

            if (topRight == TRAP && topLeft != TRAP && topMid == SAFE)
                return TRAP;

            return SAFE;
        }
    }
}