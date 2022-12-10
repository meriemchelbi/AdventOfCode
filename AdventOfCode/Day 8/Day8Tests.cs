using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode.Day_8
{
    public class Day8Tests
    {
        private readonly Day8Parser _parser;
        private readonly Day8Solver _solver;

        private const int Day = 6;

        public Day8Tests()
        {
            _parser = new Day8Parser();
            _solver = new Day8Solver();
        }

        [Fact]
        public void Part1_Test()
        {
            var input = new List<string>
            {
                "30373",
                "25512",
                "65332",
                "33549",
                "35390"
            };

            var result = _solver.SolvePart1(input);

            Assert.Equal(21, result);
        }

        [Fact]
        public void Part1_Actual()
        {
            var path = $"Day {Day}\\Input.txt";
            var data = _parser.Parse(path);

            var result = _solver.SolvePart1(data);

            Assert.Equal(0, result);
        }

        //[Fact]
        //public void Part2_Test()
        //{
        //    var input = new List<string>
        //    {
        //        "30373",
        //        "25512",
        //        "65332",
        //        "33549",
        //        "35390"
        //    };

        //    var result = _solver.SolvePart2(input);

        //    Assert.Equal(0, result);
        //}

        //[Fact]
        //public void Part2_Actual()
        //{
        //    var path = $"Day {Day}\\Input.txt";
        //    var data = _parser.Parse(path);

        //    var result = _solver.SolvePart2(data);

        //    Assert.Equal(0, result);
        //}
    }
}
