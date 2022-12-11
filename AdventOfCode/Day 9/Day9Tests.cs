using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode.Day_9
{
    public class Day9Tests
    {
        private readonly Day9Parser _parser;
        private readonly Day9Solver _solver;

        private const int Day = 9;

        public Day9Tests()
        {
            _parser = new Day9Parser();
            _solver = new Day9Solver();
        }

        [Fact]
        public void TestInput_Parses()
        {
            var expected = new List<(string direction, int distance)>
            {
                ("R", 4),
                ("U", 4),
                ("L", 3),
                ("D", 1),
                ("R", 4),
                ("D", 1),
                ("L", 5),
                ("R", 2)
            };
            var path = $"Day {Day}\\TestInput.txt";
            var parsed = _parser.Parse(path);

            parsed.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Part1_Test()
        {
            var expected = 13;

            var path = $"Day {Day}\\TestInput.txt";
            var data = _parser.Parse(path);

            var result = _solver.SolvePart1(data);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part1_Actual()
        {
            var expected = 0;

            var path = $"Day {Day}\\Input.txt";
            var data = _parser.Parse(path);

            var result = _solver.SolvePart1(data);

            Assert.Equal(expected, result);
        }

        //[Fact]
        //public void Part2_Test()
        //{
        //    var expected = 0;

        //    var path = $"Day {Day}\\TestInput.txt";
        //    var data = _parser.Parse(path);

        //    var result = _solver.SolvePart2(data);

        //    Assert.Equal(expected, result);
        //}

        //[Fact]
        //public void Part2_Actual()
        //{
        //    var expected = 0;

        //    var path = $"Day {Day}\\Input.txt";
        //    var data = _parser.Parse(path);

        //    var result = _solver.SolvePart2(data);

        //    Assert.Equal(expected, result);
        //}
    }
}
