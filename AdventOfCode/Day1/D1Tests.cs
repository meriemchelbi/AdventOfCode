using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.Day1
{
    public class D1Tests
    {
        private readonly D1Parser _parser;
        private readonly D1Solver _solver;

        public D1Tests()
        {
            _parser = new D1Parser();
            _solver = new D1Solver();
        }

        [Fact]
        public void TestInput_Parses_AsLocations()
        {
            var expectedLeftList = new List<int> { 3, 4, 2, 1, 3, 3 };
            var expectedRightList = new List<int> { 4, 3, 5, 3, 9, 3 };
            var expectedLocations = new Locations
            {
                LeftList = expectedLeftList,
                RightList = expectedRightList
            };

            var path = "Day1\\D1TestInput.txt";
            var parsed = _parser.Parse(path);

            parsed.Should().BeEquivalentTo(expectedLocations);
        }

        [Fact]
        public void Part1_Test()
        {
            var expected = 11;

            var path = "Day1\\D1TestInput.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart1(data);

            Assert.Equal(result, expected);
        }

        [Fact]
        public void Part1_Actual()
        {
            var expected = 1646452;

            var path = "Day1\\D1Input.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart1(data);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2_Test()
        {
            var expected = 31;

            var path = "Day1\\D1TestInput.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart2(data);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2_Actual()
        {
            var expected = 23609874;

            var path = "Day1\\D1Input.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart2(data);

            Assert.Equal(expected, result);
        }
    }
}
