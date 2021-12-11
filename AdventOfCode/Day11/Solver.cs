using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day11
{
    public class Solver
    {
        public int SolvePart1(int[][] input, int noOfSteps)
        {
            var totalFlashes = 0;
            
            for (int i = 0; i < noOfSteps; i++)
            {
                input = input.Select(line => line.Select(l => l += 1).ToArray()).ToArray();

                for (int row = 0; row < input.Length; row++)
                {
                    for (int column = 0; column < input.Length; column++)
                    {
                        var octopus = input[row][column];
                        if (octopus > 9)
                            Flash((row, column), ref input);
                    }
                }

                var zeros = input.SelectMany(i => i).Where(z => z == 0);
                totalFlashes += zeros.Count();
            }

            return totalFlashes;
        }

        private void Flash((int row, int column) octopus, ref int[][] incremented)
        {
            incremented[octopus.row][octopus.column] = 0;

            List<(int, int)> neighbours = GetNeighbours(octopus.row, octopus.column, incremented.Length);

            foreach (var neighbour in neighbours)
            {
                if (incremented[neighbour.Item1][neighbour.Item2] != 0)
                    incremented[neighbour.Item1][neighbour.Item2] += 1;

                if (incremented[neighbour.Item1][neighbour.Item2] > 9)
                {
                    Flash((neighbour.Item1, neighbour.Item2), ref incremented);
                }
            }
        }

        private List<(int, int)> GetNeighbours(int row, int column, int length)
        {
            var neighbours = new List<(int, int)>();

            // Get left
            if (column > 0)
                neighbours.Add((row, column - 1));
            
            // Get top left
            if (column > 0 && row > 0)
                neighbours.Add((row - 1, column - 1));
            
            // Get up
            if (row > 0)
                neighbours.Add((row - 1, column));
            
            // Get top right
            if (row > 0 && column < length - 1)
                neighbours.Add((row - 1, column + 1));
            
            // Get right
            if (column < length - 1)
                neighbours.Add((row, column + 1));
            
            // Get bottom right
            if (row < length - 1 && column < length - 1)
                neighbours.Add((row + 1, column + 1));

            // Get down
            if (row < length - 1)
                neighbours.Add((row + 1, column));

            // Get bottom left
            if (row < length - 1 && column > 0)
                neighbours.Add((row + 1, column - 1));

            return neighbours;
        }

        public int SolvePart2(int[][] inputs)
        {
            return 0;
        }
    }
}
