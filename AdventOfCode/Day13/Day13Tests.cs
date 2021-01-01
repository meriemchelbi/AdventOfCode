using FluentAssertions;
using Xunit;

namespace AdventOfCode.Day13
{
    public class Day13Tests
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

            Assert.Equal(1956, result);
        }

        [Fact]
        public void Part2_Result()
        {
            Solver solver = new();

            var result = solver.Solve2("Input");

            Assert.NotEqual(46639, result);
        }
    }
}
