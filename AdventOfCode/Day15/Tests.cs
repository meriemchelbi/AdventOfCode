using Xunit;

namespace AdventOfCode.Day15
{
    public class Tests
    {
        [Theory]
        [InlineData(436, 0, 3, 6)]
        [InlineData(1, 1, 3, 2)]
        [InlineData(10, 2, 1, 3)]
        [InlineData(27, 1, 2, 3)]
        [InlineData(78, 2, 3, 1)]
        [InlineData(438, 3, 2, 1)]
        [InlineData(1836, 3, 1, 2)]
        [InlineData(1259, 15, 5, 1, 4, 7, 0)]
        public void Part1_Result(int expected, params int[] input)
        {
            Solver solver = new();

            var result = solver.Solve(2020, input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(175594, 0, 3, 6)]
        [InlineData(2578, 1, 3, 2)]
        [InlineData(3544142, 2, 1, 3)]
        [InlineData(261214, 1, 2, 3)]
        [InlineData(6895259, 2, 3, 1)]
        [InlineData(18, 3, 2, 1)]
        [InlineData(362, 3, 1, 2)]
        [InlineData(689, 15, 5, 1, 4, 7, 0)]
        public void Part2_Result(int expected, params int[] input)
        {
            Solver solver = new();

            var result = solver.Solve(30000000, input);

            Assert.Equal(expected, result);
        }
    }
}
