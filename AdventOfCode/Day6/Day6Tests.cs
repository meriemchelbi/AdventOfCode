using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.Day6
{
    public class Day6Tests
    {
        [Fact]
        public void InputParser_ReturnsList()
        {
            InputParser parser = new();

            var result = parser.ParseGroups();

            Assert.IsType<List<string>>(result);
        }
        
        [Fact]
        public void InputParser_Individuals_ReturnsList()
        {
            InputParser parser = new();

            var result = parser.ParseIndividuals();

            Assert.IsType<List<string[]>>(result);
        }

        [Theory]
        [InlineData("abcxabcyabcz","abcxyz")]
        [InlineData("aaaa","a")]
        public void DeduplicateGroupAnswers(string input, string expected)
        {
            Solver solver = new();

            var result = solver.DeduplicateGroupAnswers(input);

            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData("abcxyz", 6)]
        [InlineData("a", 1)]
        public void CalculateAnswerScore(string input, int expected)
        {
            Solver solver = new();

            var result = solver.CalculateAnswerScore(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("a", "b", "c", "")]
        [InlineData("abc", "abc", "abc", "abc")]
        [InlineData("ab", "abc", "bc", "b")]
        public void YesByAll(string group1, string group2, string group3, string expected)
        {
            Solver solver = new();

            var input = new string[] { group1, group2, group3 };

            var result = solver.YesByAll(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part1_Result()
        {
            Solver solver = new();

            var result = solver.Solve();

            Assert.Equal(6335, result);
        }

        [Fact]
        public void Part2_Result()
        {
            Solver solver = new();

            var result = solver.Solve2();

            Assert.Equal(3392, result);
        }
    }
}
