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
                for (int column = 0; column < input[0].Length; column++)
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

        public int SolvePart2(int[][] input)
        {
            List<(int, int)> lowPoints = GetLowPoints(input);

            var basins = lowPoints.Select(s => GetBasinCount(s, input))
                                  .OrderByDescending(b => b).ToList();

            return basins[0] * basins[1] * basins[2];
        }

        private int GetBasinCount((int row, int column) lowPoint, int[][] input)
        {
            var surrounding = new List<(int, int)>();
            
            AddSurroundingPointsRecursive(input, lowPoint, surrounding);

            var deduplicated = surrounding.Distinct();

            return deduplicated.Count();
        }

        private List<(int, int)> GetLowPoints(int[][] input)
        {
            List<(int, int)> lowPoints = new List<(int, int)>();

            for (int row = 0; row < input.Length; row++)
            {
                for (int column = 0; column < input[0].Length; column++)
                {
                    var height = input[row][column];
                    List<int> surroundingPoints = GetSurroundingPoints(input, (row, column));

                    if (surroundingPoints.All(s => s > height))
                        lowPoints.Add((row, column));
                }
            }

            return lowPoints;
        }

        private List<int> GetSurroundingPoints(int[][] input, (int row, int column) point)
        {
            var surrounding = new List<int>();

            // up
            if (point.row > 0)
                surrounding.Add(input[point.row - 1][point.column]);
            // down
            if (point.row < input.Length - 1)
                surrounding.Add(input[point.row + 1][point.column]);
            // left
            if (point.column > 0)
                surrounding.Add(input[point.row][point.column - 1]);
            // right
            if (point.column < input[0].Length - 1)
                surrounding.Add(input[point.row][point.column + 1]);

            return surrounding;
        }

        private void AddSurroundingPointsRecursive(int[][] input, (int row, int column) point, List<(int,int)> basin)
        {
            var surrounding = new List<(int, int)>();

            // up
            if (point.row > 0 && input[point.row - 1][point.column] != 9)
               surrounding.Add((point.row - 1, point.column));
        
            // down
            if (point.row < input.Length - 1 && input[point.row + 1][point.column] != 9)
                surrounding.Add((point.row + 1, point.column));
            
            // left
            if (point.column > 0 && input[point.row][point.column - 1] != 9)
                surrounding.Add((point.row, point.column - 1));

            // right
            if (point.column < input[0].Length - 1 && input[point.row][point.column + 1] != 9)
                surrounding.Add((point.row, point.column + 1));

            var deduplicated = surrounding.Where(s => !basin.Any(b => b == s)).ToList();
            
            if (!deduplicated.Any())
                return;

            foreach (var item in deduplicated)
            {
                basin.Add(item);
                AddSurroundingPointsRecursive(input, item, basin);
            }
        }
    }
}
