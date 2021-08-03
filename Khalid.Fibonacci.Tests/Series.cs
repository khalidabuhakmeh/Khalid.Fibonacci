using System.Linq;
using Xunit;
using Xunit.Abstractions;
using static System.String;

namespace Khalid.Fibonacci.Tests
{
    public class Series
    {
        private readonly ITestOutputHelper _output;

        public Series(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Can_use_linq_with_series()
        {
            var result = Fibonacci.Series.Next().Take(10).ToList();
            _output.WriteLine(Join(",", result));
            Assert.Equal(10, result.Count);
        }
    }
}