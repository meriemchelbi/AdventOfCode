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
        public void TestInput_Parses_AsListOfInt()
        {
            var expected = new List<int> { 0 };

            var path = "Day4\\D4TestInput.txt";
            var parsed = _parser.Parse(path);

            Assert.Equal(expected, parsed);
        }
        
        [Fact]
        public void Part1_Test()
        {
            var expected = 24000;

            var path = "Day4\\D4TestInput.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart1(data);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part1_Actual()
        {
            var expected = 69693;

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
