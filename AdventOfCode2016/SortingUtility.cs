using System.Collections.Generic;

namespace AdventOfCode2016
{
    public static class SortingUtility
    {
        // Used to sort a dictionary by the most common key first, with ties going to alphabetical sorting
        public static int CompareDictionary(KeyValuePair<char, int> pair1, KeyValuePair<char, int> pair2)
        {
            // If the same number of entries, sort alphabetically
            if (pair1.Value == pair2.Value)
                return pair1.Key.CompareTo(pair2.Key);

            // Otherwise sort in reverse count
            return pair2.Value.CompareTo(pair1.Value);
        }

        // Used to sort a dictionary by the least common key first, with ties going to alphabetical sorting
        public static int CompareDictionaryAscending(KeyValuePair<char, int> pair1, KeyValuePair<char, int> pair2)
        {
            // If the same number of entries, sort alphabetically
            if (pair1.Value == pair2.Value)
                return pair1.Key.CompareTo(pair2.Key);

            // Otherwise sort in ascending count
            return pair1.Value.CompareTo(pair2.Value);
        }
    }
}