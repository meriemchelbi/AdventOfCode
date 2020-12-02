using Xunit;

namespace AdventOfCode.Day2
{
    public class Day2Tests
    {
        [Fact]
        public void InputParser_ReturnsList()
        {
            InputParser parser = new();

            var result = parser.Parse();

            Assert.Equal(1000, result.Count);
        }

        [Fact]
        public void Part1_Result()
        {
            Solver solver = new();

            var result = solver.Solve();

            Assert.Equal(546, result);
        }

        [Theory]
        [InlineData("abcde", 'a', 1, 3, true)]
        [InlineData("cdefg", 'b', 1, 3, false)]
        [InlineData("ccccccccc", 'c', 2, 9, false)]
        [InlineData("jjjjjjjjjjjjjjjj", 'j', 13, 15, false)]
        [InlineData("jmjdbhjjjjjjjxnjj", 'j', 2, 14, false)]
        [InlineData("qdqqkqtbcnqqqsrklqbf", 'q', 3, 9, true)]
        public void ValidateLookup(string password, char letter, int min, int max, bool expected)
        {
            Solver solver = new();
            var sample = new PasswordSample
            {
                Password = password,
                Letter = letter,
                Min = min,
                Max = max
            };

            var result = solver.ValidateLookup(sample);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2_Result()
        {
            Solver solver = new();

            var result = solver.Solve2();

            Assert.True(result > 138);
            Assert.True(result < 725);
        }
    }
}
