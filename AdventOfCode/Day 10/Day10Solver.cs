using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day_10
{
    public class Day10Solver
    {
        public int SolvePart1(List<(string, int)> input)
        {
            return 0;
        }

        public int SolvePart2(List<(string, int)> input)
        {
            return 0;
        }

        private List<(int, int)> GetTailPositions(List<(string, int)> input, int numberOfKnots)
        {
            (int row, int column) start = (0, 0);
            var knots = new List<(int, int)>();
            for (int i = 0; i < numberOfKnots; i++)
            {
                knots.Add(start);
            }

            var tailPositions = new List<(int, int)> { start };

            foreach (var (direction, distance) in input)
            {
                for (int i = 0; i < distance; i++)
                {
                    for (int j = 1; j < numberOfKnots; j++)
                    {
                        var currentKnot = knots[j];
                        var previousKnot = knots[j - 1];
                        var previousKnotNextPosition = Move(previousKnot, direction, 1);

                        if (!AreAdjacent(currentKnot, previousKnotNextPosition))
                        {
                            knots[j] = previousKnot;

                            // if knot is final knot
                            if (j == numberOfKnots - 1)
                            {
                                tailPositions.Add(knots[j]);
                            }
                        }

                        knots[j - 1] = previousKnotNextPosition;
                    }
                }
            }

            return tailPositions;
        }

        private (int row, int column) Move((int row, int column) headPosition, string direction, int distance) 
                => direction switch {
                "U" => (headPosition.row + distance, headPosition.column),
                "D" => (headPosition.row - distance, headPosition.column),
                "R" => (headPosition.row, headPosition.column + distance),
                "L" => (headPosition.row, headPosition.column - distance),
                _ => throw new Exception(),
        };

        private bool AreAdjacent((int row, int column) headPosition, (int row, int column) tailPosition)
        {
            var rowDifferential = Math.Abs(headPosition.row - tailPosition.row);
            var columnDifferential = Math.Abs(headPosition.column - tailPosition.column);

            return rowDifferential < 2 && columnDifferential < 2;
        }
    }
}
