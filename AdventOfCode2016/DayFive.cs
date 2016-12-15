using System;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode2016
{
    public class DayFive
    {
        public static string PUZZLE_INPUT = "ugkcyxxp";

        // Determine the security door password by iterating through MD5 hashs looking for hashes that begin with "00000"
        // Then use the next character to collect the password
        public string DetermineSecurityDoorPassword(string input)
        {
            string result = "";

            long counter = -1;

            MD5 md5Hash = MD5.Create();

            // Loop until we have our full password of 8 characters
            do
            {
                ++counter;

                string hashInput = input + counter;
                string resultHash = Md5Utility.GetMd5Hash(md5Hash, hashInput);

                // Check to see if the resultHash is valid - i.e. starts with 5 zeros
                if (resultHash.Substring(0, 5) == "00000")
                {
                    // Then add the sixth character to accumulating password
                    result += resultHash.Substring(5, 1);
                }
            } while (result.Length < 8);

            return result;
        }

        // Updates the password by iterating the MD5 hashes, like the previous problem.  But, now the 6th character tells you the
        // digit of the password to update with the 7th character.
        public string DetermineSecurityDoorPasswordPartTwo(string input)
        {
            string result = "--------";

            long counter = -1;

            MD5 md5Hash = MD5.Create();

            // Loop until we have our full password, i.e. one that no longer has -'s in it
            do
            {
                ++counter;

                string hashInput = input + counter;
                string resultHash = Md5Utility.GetMd5Hash(md5Hash, hashInput);

                // Check to see if the resultHash is valid - i.e. starts with 5 zeros
                if (resultHash.Substring(0, 5) == "00000")
                {
                    // Then add the sixth character to accumulating password
                    result = HandleResultUpdate(result, resultHash);
                }
            } while (result.IndexOf('-') != -1);

            return result;
        }

        // Handle updates to the currentPassword, if appropriate
        public string HandleResultUpdate(string currentPassword, string currentHash)
        {
            StringBuilder sb = new StringBuilder(currentPassword);
            string stringDigit = currentHash.Substring(5, 1);
            int digitToUpdate;

            if (Int32.TryParse(stringDigit, out digitToUpdate) == false)
                return sb.ToString();

            if (digitToUpdate < 0 || digitToUpdate > 7)
                return sb.ToString();

            // If digit has not already been updated, update it
            if (currentPassword.Substring(digitToUpdate, 1) == "-")
            {
                // If so, then update with the seventh character in string
                sb[digitToUpdate] = currentHash.Substring(6, 1)[0];
            }

            return sb.ToString();
        }
    }
}