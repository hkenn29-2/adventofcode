using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Extensions
{
    public static class LinqExtensions
    {
        /// <summary>
        /// Tries the select.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="selector">The selector.</param>
        /// <returns></returns>
        public static IEnumerable<TResult> TrySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach (TSource input in source)
            {
                TResult result = default(TResult);
                bool wasSuccesful = false;
                try
                {
                    result = selector(input);
                    wasSuccesful = true;

                }
                catch { }
                if (wasSuccesful)
                {
                    yield return result;
                }
            }
        }
    }
}
