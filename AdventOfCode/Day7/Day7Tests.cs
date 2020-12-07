using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode.Day7
{
    public class Day7Tests
    {
        [Fact]
        public void ExtractRule_SomeBags()
        {
            InputParser parser = new();

            var result = parser.ExtractRule("light red bags contain 1 bright white bag, 2 muted yellow bags.");

            Assert.Equal("light red", result.Key);
            Assert.Equal("bright white", result.Value.First().Key);
            Assert.Equal(1, result.Value.First().Value);
            Assert.Equal("muted yellow", result.Value.Last().Key);
            Assert.Equal(2, result.Value.Last().Value);
        }
        
        [Fact]
        public void ExtractRule_NoBags()
        {
            InputParser parser = new();

            var result = parser.ExtractRule("faded blue bags contain no other bags.");

            Assert.Equal("faded blue", result.Key);
            Assert.Null(result.Value);
        }
        
        [Fact]
        public void InputParser_ReturnsList()
        {
            InputParser parser = new();

            var result = parser.Parse();

            Assert.Equal(594, result.Count);
        }

        [Fact]
        public void Part1_Result()
        {
            Solver solver = new();

            var result = solver.Solve();

            Assert.Equal(378, result);
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
