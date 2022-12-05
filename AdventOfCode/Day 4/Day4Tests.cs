using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode.Day_4
{
    public class Day4Tests
    {
        private readonly Day4Parser _parser;
        private readonly Day4Solver _solver;

        private const int Day = 4;

        public Day4Tests()
        {
            _parser = new Day4Parser();
            _solver = new Day4Solver();
        }

        [Fact]
        public void TestInput_Parses()
        {
            var expected = new List<(int[], int[])> 
            {
                (new int[]{ 2, 3, 4 },new int[]{ 6, 7, 8 }),
                (new int[]{ 2, 3 },new int[]{ 4, 5 }),
                (new int[]{ 5, 6, 7 },new int[]{ 7, 8, 9 }),
                (new int[]{ 2, 3, 4, 5, 6, 7, 8 },new int[]{ 3, 4, 5, 6, 7 }),
                (new int[]{ 6 },new int[]{ 4, 5, 6 }),
                (new int[]{ 2, 3, 4, 5, 6 },new int[]{ 4, 5, 6, 7, 8 }),            };

            var path = $"Day {Day}\\TestInput.txt";
            var parsed = _parser.Parse(path);

            Assert.Equal(expected, parsed);
        }

        [Fact]
        public void Part1_Test()
        {
            var expected = 2;

            var path = $"Day {Day}\\TestInput.txt";
            var data = _parser.Parse(path);

            var result = _solver.SolvePart1(data);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part1_Actual()
        {
            var expected = 573;

            var path = $"Day {Day}\\Input.txt";
            var data = _parser.Parse(path);

            var result = _solver.SolvePart1(data);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2_Test()
        {
            var expected = 4;

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
