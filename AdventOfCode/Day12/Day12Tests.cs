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

        [Theory]
        [InlineData(-1, 10, 0, 0, 10, -10, 100)]
        [InlineData(-4, 10, -10, 100, 7, -38, 170)]
        [InlineData(10, 4, -38, 170, 11, 72, 214)]
        [InlineData(-1, -1, -10, 100, 5, -15, 95)]
        [InlineData(-1, -1, 10, -100, 5, 5, -105)]
        [InlineData(1, -1, -10, 100, 5, -5, 95)]
        public void MoveToWaypoint(int waypointNS,
                                   int waypointEW,
                                   int shipNS,
                                   int shipEW,
                                   int instruction,
                                   int expectedShipNS,
                                   int expectedShipEW)
        {
            var solver = new Solver
            {
                WaypointNorthSouthPosition = waypointNS,
                WaypointEastWestPosition = waypointEW,
                ShipNorthSouthPosition = shipNS,
                ShipEastWestPosition = shipEW
            };

            solver.MoveToWaypoint(instruction);

            solver.ShipNorthSouthPosition.Should().Be(expectedShipNS);
            solver.ShipEastWestPosition.Should().Be(expectedShipEW);
        }
        
        [Theory]
        [InlineData(-1, 10, "N3", -4, 10)]
        [InlineData(-1, 10, "S3", 2, 10)]
        [InlineData(-1, 10, "E3", -1, 13)]
        [InlineData(-1, 10, "W3", -1, 7)]
        public void MoveWaypoint(int waypointNS,
                                   int waypointEW,
                                   string instructionInput,
                                   int expectedNS,
                                   int expectedEW)
        {
            Solver solver = new();

            solver.WaypointNorthSouthPosition = waypointNS;
            solver.WaypointEastWestPosition = waypointEW;

            var instruction = new Instruction(instructionInput);
            solver.MoveWaypoint(instruction);

            solver.WaypointNorthSouthPosition.Should().Be(expectedNS);
            solver.WaypointEastWestPosition.Should().Be(expectedEW);
        }

        [Theory]
        [InlineData(-1, 10, "R90", 10, 1)]
        [InlineData(-1, 10, "R180", -10, 1)]
        [InlineData(-1, 10, "R270", -10, -1)]
        [InlineData(-1, 10, "L90", -10, -1)]
        [InlineData(-1, 10, "L180", -10, 1)]
        [InlineData(-1, 10, "L270", 10, 1)]
        public void RotateWaypoint(int northSouth,
                                   int eastWest,
                                   string instructionInput,
                                   int expectedNS,
                                   int expectedEW)
        {
            var solver = new Solver
            {
                WaypointNorthSouthPosition = northSouth,
                WaypointEastWestPosition = eastWest
            };

            var instruction = new Instruction(instructionInput);

            solver.RotateWaypoint(instruction);

            solver.WaypointEastWestPosition.Should().Be(expectedEW);
            solver.WaypointNorthSouthPosition.Should().Be(expectedNS);
        }

        [Fact]
        public void Solve2Test()
        {
            Solver solver = new();

            var result = solver.Solve2("TestInput");

            result.Should().Be(286);
        }

        [Fact]
        public void Part2_Result()
        {
            Solver solver = new();

            var result = solver.Solve2("Input");

            Assert.True(result > 8267);
            Assert.True(result < 2146001992);
            Assert.True(result < 2043926620);
            Assert.NotEqual(46639, result);
        }
    }
}
