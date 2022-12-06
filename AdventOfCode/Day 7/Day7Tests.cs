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

        [Theory]
        [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
        public void Part1_Test(string input, int expected)
        {
            var result = _solver.SolvePart1(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part1_Actual()
        {
            var expected = 1892;

            var path = $"Day {Day}\\Input.txt";
            var data = _parser.Parse(path);

            var result = _solver.SolvePart1(data);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
        public void Part2_Test(string input, int expected)
        {
            var result = _solver.SolvePart2(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2_Actual()
        {
            var expected = 2313;

            var path = $"Day {Day}\\Input.txt";
            var data = _parser.Parse(path);

            var result = _solver.SolvePart2(data);

            Assert.Equal(expected, result);
        }
    }
}
