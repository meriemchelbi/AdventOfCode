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

        [Theory]
        [InlineData(true, 3, 3417, "17", "x", "13", "19")]
        [InlineData(true, 4, 754018, "67","7","59","61")]
        [InlineData(true, 4, 779210, "67", "x", "7","59","61")]
        [InlineData(true, 4, 1261476, "67", "7", "x", "59","61")]
        [InlineData(true, 4, 1202161486, "1789","37","47","1889")]
        public void IsWinningTimestamp(bool expected, int busCount, uint timestamp, params string[] timetable)
        {
            Solver solver = new();

            var busIds = solver.ExtractIndexedBusIds(timetable);

            var result = solver.IsWinningTimestamp(busIds, timestamp);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2_Result()
        {
            Solver solver = new();

            var result = solver.Solve3("Input");

            //Assert.NotEqual(46639, result);
        }
    }
}
