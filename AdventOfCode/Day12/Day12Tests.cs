using Xunit;

namespace AdventOfCode.Day12
{
    public class Day12Tests
    {
        [Fact]
        public void InputParser_ReturnsList()
        {
            InputParser parser = new();

            var result = parser.Parse("Input");

            Assert.Equal(769, result.Count);
        }

        [Fact]
        public void Part1_Result()
        {
            Solver solver = new();

            var result = solver.Solve("Input");

            Assert.Equal(2113, result);
        }

        [Fact]
        public void Part2_Result()
        {
            Solver solver = new();

            var result = solver.Solve2("Input");

            Assert.Equal(1865, result);
        }
    }
}
