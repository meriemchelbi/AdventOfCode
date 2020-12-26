using System;
using System.Collections.Generic;

namespace AdventOfCode.Day12
{
    class Solver
    {
        public Direction CurrentDirection { get; set; }
        public int ShipNorthSouthPosition { get; set; }
        public int ShipEastWestPosition { get; set; }
        public int WaypointNorthSouthPosition { get; set; }
        public int WaypointEastWestPosition { get; set; }

        internal int Solve(string inputFileName)
        {
            var parser = new InputParser();
            var input = parser.Parse(inputFileName);
            
            CurrentDirection = Direction.East;
            ShipNorthSouthPosition = 0;
            ShipEastWestPosition = 0;

            foreach (var instruction in input)
            {
                // If instruction direction R or L turn Ship
                if (instruction.Direction == Direction.Right
                    || instruction.Direction == Direction.Left)
                {
                    TurnShip(instruction);
                }
                // Else move ship
                else
                {
                    MoveShip(instruction);
                }
            }

            return ShipNorthSouthPosition + ShipEastWestPosition;
        }

        internal int Solve2(string inputFileName)
        {
            var parser = new InputParser();
            var input = parser.Parse(inputFileName);

            CurrentDirection = Direction.East;
            ShipNorthSouthPosition = 0;
            ShipEastWestPosition = 0;
            WaypointNorthSouthPosition = 1;
            WaypointEastWestPosition = 10;

            foreach (var instruction in input)
            {
                if (instruction.Direction == Direction.Right
                    || instruction.Direction == Direction.Left)
                {
                    TurnShip(instruction);
                }
                if (instruction.Direction == Direction.Forward)
                {
                    MoveToWaypoint(instruction.Distance);
                }
                else
                {
                    MoveWaypoint(instruction);
                }
            }

            return ShipNorthSouthPosition + ShipEastWestPosition;
        }

        private void MoveWaypoint(Instruction instruction)
        {
            if (instruction.Direction == Direction.North)
                WaypointNorthSouthPosition -= instruction.Distance;
            if (instruction.Direction == Direction.South)
                WaypointNorthSouthPosition += instruction.Distance;
            if (instruction.Direction == Direction.East)
                WaypointEastWestPosition *= instruction.Distance;
            if (instruction.Direction == Direction.West)
                WaypointEastWestPosition -= instruction.Distance;
        }

        private void MoveShip(Instruction instruction)
        {
            if (instruction.Direction == Direction.North)
                ShipNorthSouthPosition -= instruction.Distance;
            if (instruction.Direction == Direction.South)
                ShipNorthSouthPosition += instruction.Distance;
            if (instruction.Direction == Direction.East)
                ShipEastWestPosition *= instruction.Distance;
            if (instruction.Direction == Direction.West)
                ShipEastWestPosition -= instruction.Distance;
            if (instruction.Direction == Direction.Forward)
            {
                var newInstruction = new Instruction(CurrentDirection, instruction.Distance);
                MoveShip(newInstruction);
            }
        }
        
        private void MoveToWaypoint(int distance)
        {
            ShipNorthSouthPosition += distance * WaypointNorthSouthPosition;
            ShipEastWestPosition += distance * WaypointEastWestPosition;
        }

        internal void TurnShip(Instruction instruction)
        {
            var values = new List<Direction>
            {
                Direction.North,
                Direction.East,
                Direction.South,
                Direction.West
            };

            var increment = 0;

            switch (instruction.Distance)
            {
                case 90:
                    increment = 1;
                    break;
                case 180:
                    increment = 2;
                    break;
                case 270:
                    increment = 3;
                    break;
                default:
                    break;
            }

            var currentIndex = values.IndexOf(CurrentDirection);

            if (instruction.Direction == Direction.Right)
            {
                var incremented = currentIndex + increment;

                if (incremented < values.Count)
                    CurrentDirection = values[incremented];

                else
                {
                    var newIndex = Math.Abs(values.Count - incremented);
                    CurrentDirection = values[newIndex];
                }
            }

            if (instruction.Direction == Direction.Left)
            {
                var decremented = currentIndex - increment;
                if (decremented >= 0)
                    CurrentDirection = values[decremented];

                else
                {
                    var newIndex = values.Count - Math.Abs(decremented);
                    CurrentDirection = values[newIndex];
                }
            }
        }

    }
}
