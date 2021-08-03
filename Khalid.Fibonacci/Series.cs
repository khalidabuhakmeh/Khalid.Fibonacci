using System.Collections.Generic;

namespace Khalid.Fibonacci
{
    public static class Series
    {
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