using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode.Day_2
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
        public void TestInput_Parses()
        {
            var expected = new List<(int, int)> { (1, 2), (2, 1), (3, 3) };

            var path = "Day 2\\D2TestInput.txt";
            var parsed = _parser.Parse(path);

            Assert.Equal(expected, parsed);
        }

        [Fact]
        public void Part1_Test()
        {
            var expected = 15;

            var path = "Day 2\\D2TestInput.txt";
            var data = _parser.Parse(path);

            var result = _solver.SolvePart1(data);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part1_Actual()
        {
            // too low
            var expected = 12940;

            var path = "Day 2\\D2Input.txt";
            var data = _parser.Parse(path);

            var result = _solver.SolvePart1(data);

            Assert.Equal(expected, result);
        }

        //[Fact]
        //public void Part1_MostCalories_Actual()
        //{
        //    var expected = 69693;

        //    var path = "Day 1\\D1Input.txt";
        //    var data = _parser.Parse(path);
        //    var mostCalories = _solver.SolvePart1(data);

        //    Assert.Equal(expected, mostCalories);
        //}

        //[Fact]
        //public void Part2_Top3_Test()
        //{
        //    var expected = 45000;

        //    var path = "Day 1\\D1TestInput.txt";
        //    var data = _parser.Parse(path);
        //    var mostCalories = _solver.SolvePart2(data);

        //    Assert.Equal(expected, mostCalories);
        //}

        //[Fact]
        //public void Part2_Top3_Actual()
        //{
        //    var expected = 200945;

        //    var path = "Day 1\\D1Input.txt";
        //    var data = _parser.Parse(path);
        //    var mostCalories = _solver.SolvePart2(data);

        //    Assert.Equal(expected, mostCalories);
        //}
    }
}
