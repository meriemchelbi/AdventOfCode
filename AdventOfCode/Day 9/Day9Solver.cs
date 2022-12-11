using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day_9
{
    public class Day9Solver
    {
        public int SolvePart1(List<(string, int)> input)
        {
            (int row, int column) start = (0, 0);
            (int row, int column) tailPosition = start;
            (int row, int column) headPosition = start;

            var tailPositions = new List<(int, int)> { (0,0) };

            foreach (var (direction, distance) in input)
            {
                for (int i = 0; i < distance; i++)
                {
                    var newHeadPosition = Move(headPosition, direction, 1);

                    if (!AreAdjacent(newHeadPosition, tailPosition))
                    {
                        tailPosition = headPosition;
                        tailPositions.Add(tailPosition);
                    }
                    headPosition = newHeadPosition;
                }
            }

            return tailPositions.Distinct().Count();
        }

        private bool AreAdjacent((int row, int column) headPosition, (int row, int column) tailPosition)
        {
            var rowDifferential = Math.Abs(headPosition.row - tailPosition.row);
            var columnDifferential = Math.Abs(headPosition.column - tailPosition.column);

            return rowDifferential < 2 && columnDifferential < 2;
        }

        private (int row, int column) Move((int row, int column) headPosition, string direction, int distance) 
                => direction switch {
                "U" => (headPosition.row + distance, headPosition.column),
                "D" => (headPosition.row - distance, headPosition.column),
                "R" => (headPosition.row, headPosition.column + distance),
                "L" => (headPosition.row, headPosition.column - distance),
                _ => throw new Exception(),
        };
        public int SolvePart2(List<(string, int)> input)
        {
            return 0;
        }
    }
}
