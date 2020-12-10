using Xunit;

namespace AdventOfCode.Day10
{
    public class Day10Tests
    {
        [Fact]
        public void InputParser_ReturnsList()
        {
            InputParser parser = new();

            var result = parser.Parse();

            Assert.Equal(107, result.Count);
            Assert.Equal(105, result[0]);
            Assert.Equal(53, result[^1]);
        }

        [Fact]
        public void Part1_Result()
        {
            Solver solver = new();

            var result = solver.Solve();

            Assert.Equal(2432, result);
        }

        [Fact]
        public void Part2_Result()
        {
            Solver solver = new();

            var result = solver.Solve2();

            Assert.Equal(1539, result);
        }
    }
}
