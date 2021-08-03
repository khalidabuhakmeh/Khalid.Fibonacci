using System.Linq;
using Xunit;
using Xunit.Abstractions;
using static System.String;

namespace Khalid.Fibonacci.Tests
{
    public class SeriesTests
    {
        private readonly ITestOutputHelper _output;

        public SeriesTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Can_use_linq_with_series()
        {
            var result = Series.Next().Take(10).ToList();
            _output.WriteLine(Join(",", result));
            Assert.Equal(10, result.Count);
        }

        [Fact]
        public void Can_skip_and_take_with_series()
        {
            var result = Series.Next()
                .Skip(2)
                .Take(2)
                .ToList();

            Assert.Equal(1, result[0]);
            Assert.Equal(2, result[1]);
        }
    }
}