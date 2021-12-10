using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day9
{
    public class Solver
    {
        public int SolvePart1(int[][] input)
        {
            var riskLevelsSum = 0;

            for (int row = 0; row < input.Length; row++)
            {
                for (int column = 0; column < input.Length; column++)
                {
                    var height = input[row][column];
                    List<int> surroundingPoints = GetSurroundingPoints(input, (row, column));

                    if (surroundingPoints.All(s => s > height))
                    {
                        var riskLevel = height + 1;
                        riskLevelsSum += riskLevel;
                    }
                }
            }

            return riskLevelsSum;
        }

        private List<int> GetSurroundingPoints(int[][] input, (int row, int column) point)
        {
            var surrounding = new List<int>();

            if (point.row > 0 && point.row < input.Length - 1)
            {
                var up = input[point.row - 1][point.column];
                surrounding.Add(up);
            }

            if (point.row > -1 && point.row < input.Length - 1)
            {
                var down = input[point.row + 1][point.column];
                surrounding.Add(down);
            }

            if (point.column > 0 && point.column < input.Length)
            {
                var left = input[point.row][point.column - 1];
                surrounding.Add(left);
            }
            
            if (point.column > -1 && point.column < input.Length - 1)
            {
                var right = input[point.row][point.column + 1];
                surrounding.Add(right);
            }

            return surrounding;
        }

        public int SolvePart2(int[][] input)
        {
            throw new NotImplementedException();
        }
    }
}
