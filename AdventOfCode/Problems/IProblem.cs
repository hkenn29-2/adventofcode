using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Problems
{
    public interface IProblem
    {
        /// <summary>
        /// Solves this instance.
        /// </summary>
        /// <returns>The answer, as a string</returns>
        string Solve();
    }
}
