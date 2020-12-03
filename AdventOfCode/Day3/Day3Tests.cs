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

        [Theory]
        [InlineData(30, 25, 28)]
        [InlineData(30, 28, 1)]
        [InlineData(30, 29, 2)]
        public void CalculatePosition(int rowLength, int currentPosition, int expectedPosition)
        {
            Solver solver = new();

            var result = solver.CalculatePosition(currentPosition, rowLength, 3);

            Assert.Equal(expectedPosition, result);
        }

        [Fact]
        public void Part1_Result()
        {
            Solver solver = new();

            var result = solver.Solve(3, 1);

            Assert.Equal(262, result);
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
