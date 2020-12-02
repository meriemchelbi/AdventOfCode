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

        //[Fact]
        //public void Part2_Result()
        //{
        //    Solver solver = new();

        //    var result = solver.Solve3();

        //    Assert.Equal(200878544, result);
        //}
    }
}
