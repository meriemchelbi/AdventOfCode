using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.Day9
{
    public class Day9Tests
    {
        [Fact]
        public void InputParser_ReturnsList()
        {
            InputParser parser = new();

            var result = parser.Parse();

            Assert.Equal(1000, result.Count);
            Assert.Equal(38, result[0]);
            Assert.Equal(80479730439085, result[^1]);
        }

        [Theory]
        [InlineData(26, true)]
        [InlineData(49, true)]
        [InlineData(100, false)]
        [InlineData(50, false)]
        public void IsValidNumber_FirstPass(int number, bool expected)
        {
            Solver solver = new();
            var preamble = new List<long> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 };
            
            var result = solver.IsValidNumber(number, preamble);

            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData(26, true)]
        [InlineData(65, false)]
        [InlineData(64, true)]
        [InlineData(66, true)]
        public void IsValidNumber_SecondPass(int number, bool expected)
        {
            Solver solver = new();
            var preamble = new List<long> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 21, 22, 23, 24, 25, 45 };
            
            var result = solver.IsValidNumber(number, preamble);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part1_Result()
        {
            Solver solver = new();

            var result = solver.Solve();
            
            Assert.Equal(22406676, result);
        }

        [Fact]
        public void Part2_Result()
        {
            Solver solver = new();

            var result = solver.Solve2();

            Assert.Equal(1539, result);
        }
    }
}
