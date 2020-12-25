using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode.Day11
{
    public class Day11Tests
    {
        [Fact]
        public void InputParser_ReturnsList()
        {
            InputParser parser = new();

            var result = parser.Parse("Input");

            Assert.Equal(90, result.Count);
        }

        [Theory]
        [InlineData(0, 0, '.', 'L', 'L')]
        [InlineData(2, 1, 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L')]
        [InlineData(9, 8, '.', 'L', '.', 'L', 'L')]
        [InlineData(1, 9, 'L', 'L', 'L', '.', '.')]
        public void CalculateAdjacentSeats(int rowIndex, int columnIndex, params char[] neighbours)
        {
            InputParser parser = new();
            Solver solver = new();
            solver._input = parser.Parse("TestInput");
            var expected = neighbours;

            var result = solver.CalculateAdjacentSeats(rowIndex, columnIndex);

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Part1_Result()
        {
            Solver solver = new();

            var result = solver.Solve("Input");

            Assert.Equal(2113, result);
        }

        [Theory]
        [InlineData(0, 0, '#', '#')]
        [InlineData(5, 3, '#', 'L', '#', '#')]
        [InlineData(4, 8, 'L')]
        public void CalculateVisibleSeats(int rowIndex, int columnIndex, params char[] visible)
        {
            InputParser parser = new();
            Solver solver = new();
            solver._input = parser.Parse("VisibleInput");
            var expected = visible;

            var result = solver.CalculateVisibleSeats(rowIndex, columnIndex);

            result.Should().BeEquivalentTo(expected);
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
