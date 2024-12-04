using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.Day4
{
    public class D4Tests
    {
        private readonly D4Parser _parser;
        private readonly D4Solver _solver;

        public D4Tests()
        {
            _parser = new D4Parser();
            _solver = new D4Solver();
        }

        [Fact]
        public void TestInput_Parses_AsListOfString()
        {
            var expected = new List<string> 
            {
                "MMMSXXMASM",
                "MSAMXMSMSA",
                "AMXSXMAAMM",
                "MSAMASMSMX",
                "XMASAMXAMM",
                "XXAMMXXAMA",
                "SMSMSASXSS",
                "SAXAMASAAA",
                "MAMMMXMMMM",
                "MXMXAXMASX"
            };

            var path = "Day4\\D4TestInput.txt";
            var parsed = _parser.Parse(path);

            parsed.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void Part1_Test()
        {
            var expected = 18;

            var path = "Day4\\D4TestInput.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart1(data);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part1_Actual()
        {
            var expected = 2427; // 2427 too low

            var path = "Day4\\D4Input.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart1(data);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2_Test()
        {
            var expected = 45000;

            var path = "Day4\\D4TestInput.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart2(data);

            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Part2_Actual()
        {
            var expected = 200945;

            var path = "Day4\\D4Input.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart2(data);

            Assert.Equal(expected, result);
        }
    }
}
