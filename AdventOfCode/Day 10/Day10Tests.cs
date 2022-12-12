using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode.Day_10
{
    public class Day10Tests
    {
        private readonly Day10Parser _parser;
        private readonly Day10Solver _solver;

        private const int Day = 10;

        public Day10Tests()
        {
            _parser = new Day10Parser();
            _solver = new Day10Solver();
        }

        [Fact]
        public void TestInput_Parses()
        {
            var expected = new List<(string direction, int distance)>
            {
                ("noop", 0),
                ("addx", 3),
                ("addx", -5),
            };
            var path = $"Day {Day}\\TestInput2.txt";
            var parsed = _parser.Parse(path);

            parsed.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Part1_Test()
        {
            var expected = 13140;

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
