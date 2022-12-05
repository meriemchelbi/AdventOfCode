using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode.Day_1
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
        public void TestInput_Parses_AsListOfInt()
        {
            var expected = new List<int> { 6000, 4000, 11000, 24000, 10000 };

            var path = "Day 1\\D1TestInput.txt";
            var parsed = _parser.Parse(path);

            Assert.Equal(expected, parsed);
        }
        
        [Fact]
        public void Part1_MostCalories_Test()
        {
            var expected = 24000;

            var path = "Day 1\\D1TestInput.txt";
            var data = _parser.Parse(path);
            var mostCalories = _solver.SolvePart1(data);

            Assert.Equal(expected, mostCalories);
        }

        [Fact]
        public void Part1_MostCalories_Actual()
        {
            var expected = 69693;

            var path = "Day 1\\D1Input.txt";
            var data = _parser.Parse(path);
            var mostCalories = _solver.SolvePart1(data);

            Assert.Equal(expected, mostCalories);
        }

        [Fact]
        public void Part2_Top3_Test()
        {
            var expected = 45000;

            var path = "Day 1\\D1TestInput.txt";
            var data = _parser.Parse(path);
            var mostCalories = _solver.SolvePart2(data);

            Assert.Equal(expected, mostCalories);
        }
        
        [Fact]
        public void Part2_Top3_Actual()
        {
            var expected = 200945;

            var path = "Day 1\\D1Input.txt";
            var data = _parser.Parse(path);
            var mostCalories = _solver.SolvePart2(data);

            Assert.Equal(expected, mostCalories);
        }
    }
}
