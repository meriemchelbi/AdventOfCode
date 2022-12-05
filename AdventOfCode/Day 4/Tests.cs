using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode.Day_4
{
    public class Tests
    {
        private readonly Parser _parser;
        private readonly Solver _solver;

        private const int Day = 4;

        public Tests()
        {
            _parser = new Parser();
            _solver = new Solver();
        }

        [Fact]
        public void TestInput_Parses()
        {
            var expected = new List<string> { "vJrwpWtwJgWrhcsFMMfFFhFp", "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", "PmmdzqPrVvPwwTWBwg", "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", "ttgJtRGJQctTZtZT", "CrZsJsPPZsGzwwsLwLmpwMDw" };

            var path = $"Day {Day}\\TestInput.txt";
            var parsed = _parser.Parse(path);

            Assert.Equal(expected, parsed);
        }

        [Fact]
        public void Part1_Test()
        {
            var expected = 157;

            var path = $"Day {Day}\\TestInput.txt";
            var data = _parser.Parse(path);

            var result = _solver.SolvePart1(data);

            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Part1_Actual()
        {
            var expected = 8185;

            var path = $"Day {Day}\\Input.txt";
            var data = _parser.Parse(path);

            var result = _solver.SolvePart1(data);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2_Test()
        {
            var expected = 70;

            var path = $"Day {Day}\\TestInput.txt";
            var data = _parser.Parse(path);

            var result = _solver.SolvePart2(data);

            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Part2_Actual()
        {
            var expected = 2817;

            var path = $"Day {Day}\\Input.txt";
            var data = _parser.Parse(path);

            var result = _solver.SolvePart2(data);

            Assert.Equal(expected, result);
        }

    }
}
