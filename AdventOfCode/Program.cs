using AdventOfCode.Problems.ProblemOne;
using AdventOfCode.Problems.ProblemThree;
using AdventOfCode.Problems.ProblemTwo;
using System;

namespace AdventOfCode
{
    public class Settings
    {
        public bool Debug { get; set; } = false;
    }

    public class Program
    {
        public static Settings GlobalSettings { get; set; } = new Settings();

        static void Main(string[] args)
        {
            Console.WriteLine("Problem One");
            Console.WriteLine(new ProblemOne().Solve());
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Problem Two");
            Console.WriteLine(new ProblemTwo().Solve());
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Problem Three");
            Console.WriteLine(new ProblemThree().Solve());

        }
    }
}
