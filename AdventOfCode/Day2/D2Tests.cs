using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.Day2
{
    public class D2Tests
    {
        private readonly D2Parser _parser;
        private readonly D2Solver _solver;

        public D2Tests()
        {
            _parser = new D2Parser();
            _solver = new D2Solver();
        }

        [Fact]
        public void TestInput_Parses_AsListOfInt()
        {
            var expected = new List<int> { 0 };

            var path = "DayX\\DXTestInput.txt";
            var parsed = _parser.Parse(path);

            Assert.Equal(expected, parsed);
        }

        [Fact]
        public void Part1_Test()
        {
            var expected = 24000;

            var path = "DayX\\DXTestInput.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart1(data);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part1_Actual()
        {
            var expected = 69693;

            var path = "DayX\\DXInput.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart1(data);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2_Test()
        {
            var expected = 45000;

            var path = "DayX\\DXTestInput.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart2(data);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2_Actual()
        {
            var expected = 200945;

            var path = "DayX\\DXInput.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart2(data);

            Assert.Equal(expected, result);
        }
    }
}
