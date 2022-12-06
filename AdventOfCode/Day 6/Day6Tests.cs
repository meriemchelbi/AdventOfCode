using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode.Day_6
{
    public class Day6Tests
    {
        private readonly Day6Parser _parser;
        private readonly Day6Solver _solver;

        private const int Day = 6;

        public Day6Tests()
        {
            _parser = new Day6Parser();
            _solver = new Day6Solver();
        }

        [Theory]
        [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
        [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
        [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
        [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
        [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
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
        [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
        [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23)]
        [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
        [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
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
