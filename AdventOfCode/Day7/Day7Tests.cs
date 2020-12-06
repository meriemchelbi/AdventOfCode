using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.Day7
{
    public class Day7Tests
    {
        [Fact]
        public void InputParser_ReturnsList()
        {
            InputParser parser = new();

            var result = parser.Parse();

            Assert.IsType<List<string>>(result);
        }

        [Fact]
        public void Part1_Result()
        {
            Solver solver = new();

            var result = solver.Solve();

            Assert.Equal(6335, result);
        }

        [Fact]
        public void Part2_Result()
        {
            Solver solver = new();

            var result = solver.Solve2();

            Assert.Equal(3392, result);
        }
    }
}
