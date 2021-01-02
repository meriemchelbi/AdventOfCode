using FluentAssertions;
using Xunit;

namespace AdventOfCode.Day13
{
    public class Day13Tests
    {
        [Fact]
        public void InputParser()
        {
            InputParser parser = new();

            var result = parser.Parse("Input");

            result.Should().NotBeNull();
            result.EarliestDepartureTimestamp.Should().Be(1003240);
            result.Timetable.Should().NotBeNull();
        }

        [Fact]
        public void Part1_Result()
        {
            Solver solver = new();

            var result = solver.Solve("Input");

            Assert.True(result < 4568);
        }

        [Fact]
        public void Part2_Result()
        {
            Solver solver = new();

            var result = solver.Solve2("Input");

            Assert.NotEqual(46639, result);
        }
    }
}
