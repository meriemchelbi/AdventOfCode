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
        [InlineData(30, 25, 3, 28)]
        [InlineData(30, 28, 3, 1)]
        [InlineData(30, 29, 3, 2)]
        [InlineData(31, 29, 1, 30)]
        [InlineData(31, 30, 1, 0)]
        [InlineData(31, 29, 5, 3)]
        [InlineData(31, 28, 7, 4)]
        public void CalculatePosition(int rowLength, int currentPosition, int rightSlope, int expectedPosition)
        {
            Solver solver = new();

            var result = solver.CalculatePosition(currentPosition, rowLength, rightSlope);

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

            Assert.Equal(2698900776, result);
        }
    }
}
