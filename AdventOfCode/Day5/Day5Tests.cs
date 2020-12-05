using Xunit;

namespace AdventOfCode.Day5
{
    public class Day5Tests
    {
        [Fact]
        public void InputParser_ReturnsList()
        {
            InputParser parser = new();

            var result = parser.Parse();

            Assert.Equal(869, result.Count);
        }

        [Fact]
        public void ComputeSeatRow()
        {
            Solver solver = new();

            var result = solver.ComputeSeatRow("FBFBBFF");

            Assert.Equal(44, result);
        }
        
        [Fact]
        public void ComputeSeatColumn()
        {
            Solver solver = new();

            var result = solver.ComputeSeatColumn("RLR");

            Assert.Equal(5, result);
        }

        [Theory]
        [InlineData(70, 7, 567)]
        [InlineData(14, 7, 119)]
        [InlineData(102, 4, 820)]
        public void ComputeSeatId(int row, int column, int expected)
        {
            var sut = new Solver();

            var result = sut.ComputeSeatId(row, column);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part1_Result()
        {
            Solver solver = new();

            var result = solver.Solve();

            Assert.Equal(915, result);
        }

        [Fact]
        public void Part2_Result()
        {
            Solver solver = new();

            var result = solver.Solve2();

            Assert.Equal(133, result);
        }
    }
}
