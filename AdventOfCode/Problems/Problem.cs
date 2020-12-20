using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode.Problems
{
    public abstract class Problem : IProblem
    {
        public abstract string Solve();

        public string ReadInput(string fileName = "input") => File.ReadAllText($"Problems\\{this.GetType().Name}\\{fileName}");
    }
}
