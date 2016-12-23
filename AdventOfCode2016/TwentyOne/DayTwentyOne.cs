using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2016.TwentyOne
{
    public class DayTwentyOne
    {
        public string ProcessPasswordInstructions(string initialPassword)
        {
            string line;
            StreamReader file = new StreamReader(@"TwentyOne\DayTwentyOneInput.txt");
            string password = initialPassword;
            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                password = HandleSwapPosition(line, password);
                password = HandleSwapLetter(line, password);
                password = HandleRotateSteps(line, password, false);
                password = HandleRotatePositionLetter(line, password, false);
                password = HandleReverse(line, password);
                password = HandleMovePosition(line, password, false);
            }
            file.Close();

            return password;
        }

        public string ReversePasswordInstructions(string finalPassword)
        {
            // Brute force because my reverse logic was not working
            List<char> chars = finalPassword.ToList<char>();
            var allPermutations = CombinationUtility.GetAllPermutationsToLength(chars, chars.Count);
            foreach (var set in allPermutations)
            {
                string potentialFirstPassword = string.Concat(set);
                string result = ProcessPasswordInstructions(potentialFirstPassword);
                if (result == finalPassword)
                    return potentialFirstPassword;
            }

            return "";

            // Note that I ended up brute forcing the attempts as above.  I originally tried to reverse the logic
            // but must have been missing something because I never got the correct solution, even though my individual
            // tests on the reversal worked.  Leaving commented out for reference purposes.
            /*
            string line;
            List<string> instructions = new List<string>();
            StreamReader file = new StreamReader(@"TwentyOne\DayTwentyOneInput.txt");
            string password = initialPassword;
            // Iterate over each line in the input
            while ((line = file.ReadLine()) != null)
            {
                instructions.Add(line);
            }
            file.Close();

            for (int i = instructions.Count - 1; i >= 0; i--)
            {
                password = HandleMovePosition(instructions[i], password, true);
                password = HandleReverse(instructions[i], password);
                password = HandleRotatePositionLetter(instructions[i], password, true);
                password = HandleRotateSteps(instructions[i], password, true);
                password = HandleSwapLetter(instructions[i], password);
                password = HandleSwapPosition(instructions[i], password);
            }

            return password;
            */
        }

        public string HandleSwapPosition(string instruction, string password)
        {
            if (!instruction.Contains("swap position"))
                return password;

            int firstPosition =
                Int32.Parse(
                    instruction.Split(new string[] { "position" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim().Split(' ')[0]
                    );
            int secondPosition =
                Int32.Parse(
                    instruction.Split(new string[] { "position" }, StringSplitOptions.RemoveEmptyEntries)[2].Trim()
                    );

            char[] array = password.ToCharArray();
            char first = array[firstPosition];
            char second = array[secondPosition];

            array[firstPosition] = second;
            array[secondPosition] = first;
            return new string(array);
        }

        public string HandleSwapLetter(string instruction, string password)
        {
            if (!instruction.Contains("swap letter"))
                return password;

            string firstLetter =
                instruction.Split(new string[] { "letter" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim().Split(' ')[0];
            string secondLetter =
                instruction.Split(new string[] { "letter" }, StringSplitOptions.RemoveEmptyEntries)[2].Trim();

            int firstPosition = password.IndexOf(firstLetter);
            int secondPosition = password.IndexOf(secondLetter);

            char[] array = password.ToCharArray();
            char first = array[firstPosition];
            char second = array[secondPosition];

            array[firstPosition] = second;
            array[secondPosition] = first;
            return new string(array);
        }

        public string HandleRotateSteps(string instruction, string password, bool reverse)
        {
            if (!instruction.Contains("rotate left") && !instruction.Contains("rotate right"))
                return password;

            string direction = instruction.Split(' ')[1];
            int steps = Int32.Parse(instruction.Split(' ')[2]);

            if (reverse)
                direction = direction == "right" ? "left" : "right";

            int modify = direction == "right" ? steps : steps * -1;
            List<char> passwordList = password.ToList();
            char[] result = password.ToCharArray();
            for (int i = 0; i < password.Length; i++)
            {
                int index = i + modify;
                if (index >= password.Length)
                    index = index - password.Length;

                if (index < 0)
                    index = password.Length + index;

                result[index] = passwordList[i];
            }

            return new string(result);
        }

        public string HandleRotatePositionLetter(string instruction, string password, bool reverse)
        {
            if (!instruction.Contains("rotate based on"))
                return password;

            string letter =
                instruction.Split(new string[] { "letter" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
            int index = password.IndexOf(letter);
            int modify = index >= 4 ? index + 2 : index + 1;
            if (modify >= password.Length)
                modify = modify % password.Length;

            if (reverse)
            {
                modify = modify * -1;
            }

            List<char> passwordList = password.ToList();
            char[] result = password.ToCharArray();
            for (int i = 0; i < password.Length; i++)
            {
                index = i + modify;
                if (index >= password.Length)
                    index = index - password.Length;

                if (index < 0)
                    index = password.Length + index;

                result[index] = passwordList[i];
            }

            return new string(result);
        }

        public string HandleReverse(string instruction, string password)
        {
            if (!instruction.Contains("reverse positions"))
                return password;

            int firstPosition = Int32.Parse(instruction.Split(new string[] { "through" }, StringSplitOptions.RemoveEmptyEntries)[0].Trim().Split(' ')[2]);
            int secondPosition = Int32.Parse(instruction.Split(new string[] { "through" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim());

            char[] array = password.ToCharArray();
            int downward = secondPosition;
            char[] result = password.ToCharArray();
            for (int i = firstPosition; i <= secondPosition; i++)
            {
                result[i] = array[downward];
                downward--;
            }

            return new string(result);
        }

        public string HandleMovePosition(string instruction, string password, bool reverse)
        {
            if (!instruction.Contains("move position"))
                return password;

            int firstPosition = Int32.Parse(instruction.Split(new string[] { "position" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim().Split(' ')[0]);
            int secondPosition = Int32.Parse(instruction.Split(new string[] { "position" }, StringSplitOptions.RemoveEmptyEntries)[2].Trim());

            if (reverse)
            {
                int holder = firstPosition;
                firstPosition = secondPosition;
                secondPosition = holder;
            }
            List<char> list = password.ToList<char>();
            char letter = list[firstPosition];
            list.RemoveAt(firstPosition);
            list.Insert(secondPosition, letter);

            return string.Concat(list);
        }
    }
}