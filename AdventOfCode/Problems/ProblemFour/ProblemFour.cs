using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode.Problems.ProblemFour
{
    public class ProblemFour : Problem
    {
        private Dictionary<string, Func<string, bool>> RequiredFields { get; } = new Dictionary<string, Func<string, bool>>()
        {
            { "byr", (input) => int.TryParse(input, out int birthYearInt) && birthYearInt >= 1920 && birthYearInt <= 2002 },
            { "iyr", (input) => int.TryParse(input, out int issueYear) && issueYear >= 2010 && issueYear <= 2020 },
            { "eyr", (input) => int.TryParse(input, out int expiryYear) && expiryYear >= 2020 && expiryYear <= 2030 },
            { "hgt", (input) =>
            {
                // Must have cm or in
                if (input.Length <=2)
                {
                    return false;
                }
                
                // Check the last two digits
                var units = input.Substring(input.Length - 2, 2);
                double.TryParse(input.Substring(0, input.Length - 2), out var height);

                if ((string.Equals(units, "cm") && height >= 150 && height <= 193)
                    || (string.Equals(units, "in") && height >= 59 && height <= 76))
                {
                    return true;
                }

                return false;
            }},
            { "hcl", (input) => string.Equals(input.Substring(0, 1), "#")
                                && input.Length == 7
                                && int.TryParse(input.Substring(1, input.Length - 1), System.Globalization.NumberStyles.HexNumber, null, out var hex)
            },
            { "ecl", (input) => string.Equals("amb", input) || string.Equals("blu", input) || string.Equals("brn", input) || string.Equals("gry", input)
                                || string.Equals("grn", input) || string.Equals("hzl", input) || string.Equals("oth", input) },
            { "pid", (input) => input.Length == 9 && double.TryParse(input, out var pid) }
        };

        public override string Solve()
        {
            var passports = this.ReadInput().Split("\n\n");
            var validCount = 0;

            foreach (var passportString in passports)
            {
                // Replace all new lines with spaces for parsing
                var passport = this.ParsePassport(passportString.Replace("\n", " "));

                if (this.IsPassportValid(passport))
                {
                    validCount++;
                }
            }

            return $"There are {validCount} valid passports!";

        }

        private bool IsPassportValid(Dictionary<string, string> passport)
        {
            foreach (var fieldPair in this.RequiredFields)
            {
                if (!(passport.TryGetValue(fieldPair.Key, out var passportValue) && fieldPair.Value(passportValue)))
                {
                    return false;
                }
            }

            return true;
        }

        private Dictionary<string, string> ParsePassport(string passportString)
        {
            var passport = new Dictionary<string, string>();
            var passportSplit = passportString.Split(" ");
            foreach (var passportEntry in passportSplit)
            {
                var entrySplit = passportEntry.Split(":");
                passport[entrySplit[0]] = entrySplit[1];
            }

            return passport;
        }
    }
}
