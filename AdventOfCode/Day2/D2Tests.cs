using FluentAssertions;
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
            var expected = new List<List<int>>
            {
                new(){ 7, 6, 4, 2, 1 },
                new(){ 1, 2, 7, 8, 9 },
                new(){ 9, 7, 6, 2, 1 },
                new(){ 1, 3, 2, 4, 5 },
                new(){ 8, 6, 4, 4, 1 },
                new(){ 1, 3, 6, 7, 9 },
            };

            var path = "Day2\\D2TestInput.txt";
            var parsed = _parser.Parse(path);

            parsed.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Part1_Test()
        {
            var expected = 2;

            var path = "Day2\\D2TestInput.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart1(data);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part1_Actual()
        {
            var expected = 516;

            var path = "Day2\\D2Input.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart1(data);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2_Test()
        {
            var expected = 4;

            var path = "Day2\\D2TestInput.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart2(data);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2_Actual()
        {
            var expected = 561;

            var path = "Day2\\D2Input.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart2(data);

            Assert.Equal(expected, result);
        }
    }
}
