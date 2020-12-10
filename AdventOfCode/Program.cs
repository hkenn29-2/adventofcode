using AdventOfCode.Problems.ProblemOne;
using AdventOfCode.Problems.ProblemTwo;
using System;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Problem One");
            Console.WriteLine(new ProblemOne().Solve());
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Problem Two");
            Console.WriteLine(new ProblemTwo().Solve());


        }
    }
}
