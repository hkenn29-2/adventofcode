using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Problems.ProblemTwo
{
    public class ProblemTwo : IProblem
    {
        public string Solve()
        {
            var inputStrings = File.ReadAllText("Problems\\ProblemTwo\\input").Split('\n');

            int validCount = 0;
            int invalidCount = 0;

            foreach (var inputString in inputStrings)
            {
                if (string.IsNullOrEmpty(inputString))
                {
                    continue;
                }

                this.ProcessString(inputString, out var lowerLimit, out var upperLimit, out var policyLetter, out var password);
                if (this.IsPasswordValid(lowerLimit, upperLimit, policyLetter, password))
                {
                    validCount++;
                }
                else
                {
                    invalidCount++;
                }

            }

            return $"There are {validCount} valid passwords, and {invalidCount} passwords!";
        }

        private bool IsPasswordValid(int lowerLimit, int upperLimit, string policyCharacter, string password)
        {
            var numberOfOccurences = password.Count(x => string.Equals(x.ToString(), policyCharacter));

            if (numberOfOccurences >= lowerLimit && numberOfOccurences <= upperLimit)
            {
                return true;
            }

            return false;
        }

        private void ProcessString(string inputString, out int lowerLimit, out int upperLimit, out string policyLetter, out string password)
        {
            var inputStringSplit = inputString.Split(" ");

            // First split contains upper and lower limit, seperated by a hyphen
            var limitSplit = inputStringSplit[0].Split("-");
            lowerLimit = int.Parse(limitSplit[0]);
            upperLimit = int.Parse(limitSplit[1]);

            // Second split is the character (need to remove colon however)
            policyLetter = inputStringSplit[1].Replace(":", string.Empty);

            // Last split is the password
            password = inputStringSplit[2];
        }
    }
}
