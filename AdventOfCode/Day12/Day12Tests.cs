using FluentAssertions;
using Xunit;

namespace AdventOfCode.Day12
{
    public class Day12Tests
    {
        [Fact]
        public void InputParser_ReturnsList()
        {
            InputParser parser = new();

            var result = parser.Parse("Input");

            Assert.Equal(769, result.Count);
        }

        [Theory]
        [InlineData("R90", Direction.East, Direction.South)]
        [InlineData("R180", Direction.East, Direction.West)]
        [InlineData("L180", Direction.East, Direction.West)]
        [InlineData("L90", Direction.East, Direction.North)]
        [InlineData("L270", Direction.East, Direction.South)]
        public void TurnShip(string instructionString, Direction currentDirection, Direction expected)
        {
            var solver = new Solver();
            var instruction = new Instruction(instructionString);
            solver.CurrentDirection = currentDirection;
            
            solver.TurnShip(instruction);

            solver.CurrentDirection.Should().Be(expected);
        }

        [Fact]
        public void Part1_Result()
        {
            Solver solver = new();

            var result = solver.Solve("Input");

            Assert.Equal(1956, result);
        }

        [Fact]
        public void Part2_Result()
        {
            Solver solver = new();

            var result = solver.Solve2("Input");

            Assert.Equal(1865, result);
        }
    }
}
