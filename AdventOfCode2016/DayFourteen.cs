using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace AdventOfCode2016
{
    public class DayFourteen
    {
        public static string PUZZLE_INPUT = "ihaygndm";

        public long IndexOfLastCorrectKey(string salt, int keysNeeded, bool useStretchedHash)
        {
            long index = -1;
            MD5 md5Hash = MD5.Create();

            List<long> indexs = new List<long>();

            int numberOfKeys = 0;
            Dictionary<long, string> stringsLookingFor = new Dictionary<long, string>();
            do
            {
                index++;
                string hash = useStretchedHash ? CreateStretchedMd5Hash(md5Hash, index, salt) : CreateMd5Hash(md5Hash, index, salt);

                // Now look to see if the hash validated another hash
                List<long> keysToRemove = new List<long>();
                foreach (KeyValuePair<long, string> entry in stringsLookingFor)
                {
                    // do something with entry.Value or entry.Key
                    if (index <= (entry.Key + 1000))
                    {
                        if (HashContainsSpecificLetterInSequence(hash, entry.Value, 5))
                        {
                            // We found a key
                            numberOfKeys++;
                            keysToRemove.Add(entry.Key);

                            indexs.Add(entry.Key);
                        }
                    }
                    else
                    {
                        keysToRemove.Add(entry.Key);
                    }
                }

                // Now trim our dictionary of unneeded keys
                foreach (long key in keysToRemove)
                {
                    stringsLookingFor.Remove(key);
                }

                // If there is a repeating character, then we put it in the dictionary
                string repeatingChar = LetterSequenceInHash(hash, 3);
                if (repeatingChar != "")
                {
                    stringsLookingFor.Add(index, repeatingChar);
                }
            } while (numberOfKeys < keysNeeded);

            indexs.Sort();
            return indexs[keysNeeded - 1];
        }

        public string LetterSequenceInHash(string hash, int numberTimesRepeated)
        {
            var match = Regex.Match(hash, "(.)\\1{" + (numberTimesRepeated - 1) + "}");

            if (match.Length > 0)
                return match.Value.Substring(0, 1);

            return "";
        }

        public bool HashContainsSpecificLetterInSequence(string hash, string letter, int numberTimesRepeated)
        {
            return Regex.IsMatch(hash, "([" + letter + "])\\1{" + (numberTimesRepeated - 1) + "}");
        }

        public string CreateMd5Hash(MD5 md5Hash, long counter, string salt)
        {
            string combined = $"{salt}{counter}";
            string hash = Md5Utility.GetMd5Hash(md5Hash, combined);
            return hash;
        }

        public string CreateStretchedMd5Hash(MD5 md5Hash, long counter, string salt)
        {
            string iterativeHash = $"{salt}{counter}";
            for (int i = 0; i < 2017; i++)
            {
                string hash = Md5Utility.GetMd5Hash(md5Hash, iterativeHash);
                iterativeHash = hash;
            }
            return iterativeHash;
        }
    }
}