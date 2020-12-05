using AdventOfCode.Day4;
using System.Collections.Generic;
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

            Assert.IsType<List<Passport>>(result);
        }

        [Fact]
        public void Part1_Result()
        {
            Solver solver = new();

            var result = solver.Solve();

            Assert.Equal(245, result);
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
