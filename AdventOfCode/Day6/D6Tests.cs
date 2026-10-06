using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.Day6
{
    public class D6Tests
    {
        private readonly D6Parser _parser;
        private readonly D6Solver _solver;

        public D6Tests()
        {
            _parser = new D6Parser();
            _solver = new D6Solver();
        }

        [Fact]
        public void TestInput_Parses()
        {
            var expected = new List<string> 
            {
                "....#.....",
                ".........#",
                "..........",
                "..#.......",
                ".......#..",
                "..........",
                ".#..^.....",
                "........#.",
                "#.........",
                "......#..."
            };

            var path = "Day6\\D6TestInput.txt";
            var parsed = _parser.Parse(path);

            parsed.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Part1_Test()
        {
            var expected = 41;

            var path = "Day6\\D6TestInput.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart1(data);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part1_Actual()
        {
            var expected = 4663;

            var path = "Day6\\D6Input.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart1(data);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2_Test()
        {
            var expected = 6;

            var path = "Day6\\D6TestInput.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart2(data);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2_Actual()
        {
            var expected = 200945; // 1278 too low, 1505 too low

            var path = "Day6\\D6Input.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart2(data);

            Assert.Equal(expected, result);
        }
    }
}
