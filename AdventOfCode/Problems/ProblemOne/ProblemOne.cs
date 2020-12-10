using AdventOfCode.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Problems.ProblemOne
{
    public class ProblemOne : IProblem
    {
        public string Solve()
        {
            // Read the input
            var inputNumbers = File.ReadAllText("Problems\\ProblemOne\\input").Split('\n').TrySelect(x => int.Parse(x)).ToArray();
            int numberToFind = 2020;

            int numberOne = -1;
            int numberTwo = -1;
            bool hasFound = false;

            // Find the two numbers which add up to 2020 
            for (int i = 0; i < inputNumbers.Length; i++)
            {
                // Only look forward so we don't unnessesarily count
                for (int j = (i + 1); j < inputNumbers.Length; j++)
                {
                    numberOne = inputNumbers[i];
                    numberTwo = inputNumbers[j];

                    if (numberOne + numberTwo == numberToFind)
                    {
                        hasFound = true;
                        break;
                    }
                }

                if (hasFound)
                {
                    break;
                }
            }

            if (!hasFound)
            {
                throw new Exception($"You've messed up! Numbers which add to {numberToFind} not found!");
            }

            return $"The two numbers which add to {numberToFind} are {numberOne} and {numberTwo}! They multiply to get {numberOne * numberTwo}!";
        }
    }
}
