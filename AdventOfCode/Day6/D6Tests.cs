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
        public void TestInput_Parses_AsListOfInt()
        {
            var expected = new List<int> { 0 };

            var path = "Day6\\D6TestInput.txt";
            var parsed = _parser.Parse(path);

            Assert.Equal(expected, parsed);
        }

        [Fact]
        public void Part1_Test()
        {
            var expected = 24000;

            var path = "Day6\\D6TestInput.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart1(data);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part1_Actual()
        {
            var expected = 69693;

            var path = "Day6\\DXInput.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart1(data);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2_Test()
        {
            var expected = 45000;

            var path = "Day6\\D6TestInput.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart2(data);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2_Actual()
        {
            var expected = 200945;

            var path = "Day6\\DXInput.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart2(data);

            Assert.Equal(expected, result);
        }
    }
}
