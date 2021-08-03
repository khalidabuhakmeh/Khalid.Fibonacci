using System.Collections.Generic;

namespace Khalid.Fibonacci
{
    public static class Series
    {
        /// <summary>
        /// Generate an Fibonacci iterator that can be used with LINQ statements.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<int> Next()
        {
            var previous = -1;
            var next = 1;
            while (true)
            {
                var result = previous + next;
                previous = next;
                next = result;
                yield return result;
            }
            // ReSharper disable once IteratorNeverReturns
        }
    }
}