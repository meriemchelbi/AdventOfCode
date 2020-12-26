using System;
using System.Collections.Generic;

namespace AdventOfCode.Day12
{
    class Solver
    {
        public Direction CurrentDirection { get; set; }
        public int NorthSouthPosition { get; set; }
        public int EastWestPosition { get; set; }

        internal int Solve(string inputFileName)
        {
            var parser = new InputParser();
            var input = parser.Parse(inputFileName);
            
            CurrentDirection = Direction.East;
            NorthSouthPosition = 0;
            EastWestPosition = 0;

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

            return NorthSouthPosition + EastWestPosition;
        }

        private void MoveShip(Instruction instruction)
        {
            if (instruction.Direction == Direction.North)
                NorthSouthPosition -= instruction.Distance;
            if (instruction.Direction == Direction.South)
                NorthSouthPosition += instruction.Distance;
            if (instruction.Direction == Direction.East)
                EastWestPosition += instruction.Distance;
            if (instruction.Direction == Direction.West)
                EastWestPosition -= instruction.Distance;
            if (instruction.Direction == Direction.Forward)
            {
                var newInstruction = new Instruction(CurrentDirection, instruction.Distance);
                MoveShip(newInstruction);
            }
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

        internal int Solve2(string inputFileName)
        {
            var parser = new InputParser();
            var input = parser.Parse(inputFileName);

            return 0;
        }
    }
}
