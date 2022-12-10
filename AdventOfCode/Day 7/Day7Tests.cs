using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode.Day_7
{
    public class Day7Tests
    {
        private readonly Day7Parser _parser;
        private readonly Day7Solver _solver;

        private const int Day = 7;

        public Day7Tests()
        {
            _parser = new Day7Parser();
            _solver = new Day7Solver();
        }

        [Fact]
        public void TestInput_Parses()
        {
            var path = $"Day {Day}\\TestInput.txt";
            var parsed = _parser.Parse(path);

            // for debugging
            Assert.True(true); ;
        }

        [Fact]
        public void Part1_Test()
        {
            var expected = 95437;

            var path = $"Day {Day}\\TestInput.txt";
            var input = _parser.Parse(path);

            var result = _solver.SolvePart1(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part1_Actual()
        {
            var expected = 1743217;

            var path = $"Day {Day}\\Input.txt";
            var data = _parser.Parse(path);

            var result = _solver.SolvePart1(data);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2_Test()
        {
            var expected = 24933642;

            var path = $"Day {Day}\\TestInput.txt";
            var input = _parser.Parse(path);

            var result = _solver.SolvePart2(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2_Actual()
        {
            var expected = 8319096;

            var path = $"Day {Day}\\Input.txt";
            var data = _parser.Parse(path);

            var result = _solver.SolvePart2(data);

            Assert.Equal(expected, result);
        }
    }
}
