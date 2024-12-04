using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.Day5
{
    public class D5Tests
    {
        private readonly D5Parser _parser;
        private readonly D5Solver _solver;

        public D5Tests()
        {
            _parser = new D5Parser();
            _solver = new D5Solver();
        }

        [Fact]
        public void TestInput_Parses_AsListOfInt()
        {
            var expected = new List<int> { 0 };

            var path = "Day5\\D5TestInput.txt";
            var parsed = _parser.Parse(path);

            Assert.Equal(expected, parsed);
        }
        
        [Fact]
        public void Part1_Test()
        {
            var expected = 24000;

            var path = "Day5\\D5TestInput.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart1(data);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part1_Actual()
        {
            var expected = 69693;

            var path = "Day5\\D5Input.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart1(data);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2_Test()
        {
            var expected = 45000;

            var path = "Day5\\D5TestInput.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart2(data);

            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Part2_Actual()
        {
            var expected = 200945;

            var path = "Day5\\D5Input.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart2(data);

            Assert.Equal(expected, result);
        }
    }
}
