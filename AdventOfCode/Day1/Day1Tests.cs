using Xunit;

namespace AdventOfCode.Day1
{
    public class Day1Tests
    {
        [Fact]
        public void InputParser_ReturnsList()
        {
            InputParser parser = new();

            var result = parser.Parse();

            Assert.Equal(200, result.Count);
        }

        [Fact]
        public void Part1_Result()
        {
            Solver solver = new();

            var result = solver.Solve();

            Assert.Equal(1015476, result);
        }
    }
}
