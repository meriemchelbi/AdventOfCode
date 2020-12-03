using Xunit;

namespace AdventOfCode.Day3
{
    public class Day3Tests
    {
        [Fact]
        public void InputParser_ReturnsList()
        {
            InputParser parser = new();

            var result = parser.Parse();

            Assert.Equal(323, result.Count);
        }

        [Fact]
        public void Part1_Result()
        {
            Solver solver = new();

            var result = solver.Solve();

            Assert.NotEqual(78, result);
            Assert.NotEqual(70, result);
        }

        [Fact]
        public void Part2_Result()
        {
            Solver solver = new();

            var result = solver.Solve2();

            Assert.True(result > 138);
            Assert.True(result < 725);
        }
    }
}
