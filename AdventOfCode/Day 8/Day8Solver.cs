using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day_8
{
    public class Day8Solver
    {
        public int SolvePart1(List<string> input)
        {
            var visibleTrees = 0;

            var forestWidthInTrees = input[0].Length;
            var forestHeightInTrees = input.Count;
            visibleTrees += (forestWidthInTrees * 2) + (forestHeightInTrees * 2) - 4;

            for (int row = 1; row < forestHeightInTrees - 1; row++)
            {
                for (int col = 1; col < forestWidthInTrees - 1; col++)
                {
                    var currentTree = int.Parse(input[row][col].ToString());

                    IEnumerable<int> treesToLeft = GetTreesToLeft(input, row, col);
                    var visibleFromLeft = treesToLeft.All(t => t < currentTree);

                    IEnumerable<int> treesToRight = GetTreesToRight(input, row, col);
                    var visibleFromRight = treesToRight.All(t => t < currentTree);

                    IEnumerable<int> treesToNorth = GetTreesToNorth(input, row, col);
                    var visibleFromNorth = treesToNorth.All(t => t < currentTree);

                    IEnumerable<int> treesToSouth = GetTreesToSouth(input, row, col);
                    var visibleFromSouth = treesToSouth.All(t => t < currentTree);

                    var isVisible = visibleFromLeft || visibleFromRight || visibleFromNorth || visibleFromSouth;

                    if (isVisible)
                    {
                        visibleTrees++;
                    }
                }
            }
            return visibleTrees;
        }

        public int SolvePart2(List<string> input)
        {
            var scenicScores = new List<int>();
            var forestWidthInTrees = input[0].Length;
            var forestHeightInTrees = input.Count;

            for (int row = 0; row < forestHeightInTrees; row++)
            {
                for (int col = 0; col < forestWidthInTrees; col++)
                {
                    var currentTree = int.Parse(input[row][col].ToString());

                    var visibleToLeft = GetVisibleTreesToLeft(input, row, col).Count();

                    var visibleToRight = GetVisibleTreesToRight(input, row, col).Count();

                    var visibleToNorth = GetVisibleTreesToNorth(input, row, col).Count();

                    var visibleToSouth = GetVisibleTreesToSouth(input, row,col).Count();

                    var treeScenicScore = visibleToLeft * visibleToRight * visibleToNorth * visibleToSouth;
                    scenicScores.Add(treeScenicScore);
                }
            }
            
            return scenicScores.Max();
        }

        private static IEnumerable<int> GetTreesToSouth(List<string> input, int row, int col)
        {
            return input.Where(r => input.IndexOf(r) > row)
                                    .Select(row => row[col])
                                    .Select(t => int.Parse(t.ToString()));
        }

        private static IEnumerable<int> GetTreesToNorth(List<string> input, int row, int col)
        {
            return input.Where(r => input.IndexOf(r) < row)
                                    .Select(row => row[col])
                                    .Select(t => int.Parse(t.ToString()));
        }

        private static IEnumerable<int> GetTreesToRight(List<string> input, int row, int col)
        {
            var itemsToRight = input[0].Length - col - 1;
            return input[row].Substring(col + 1, itemsToRight).Select(t => int.Parse(t.ToString()));
        }

        private static IEnumerable<int> GetTreesToLeft(List<string> input, int row, int col)
        {
            return input[row].Substring(0, col).Select(t => int.Parse(t.ToString()));
        }

        private static IEnumerable<int> GetVisibleTreesToLeft(List<string> input, int row, int col)
        {
            var currentTree = int.Parse(input[row][col].ToString());
            var treesToLeft = GetTreesToLeft(input, row, col).ToList();
            return GetVisibleTreesBehind(currentTree, treesToLeft);
        }
        
        private static IEnumerable<int> GetVisibleTreesToNorth(List<string> input, int row, int col)
        {
            var currentTree = int.Parse(input[row][col].ToString());
            var treesToNorth = GetTreesToNorth(input, row, col).ToList();
            return GetVisibleTreesBehind(currentTree, treesToNorth);
        }

        private static IEnumerable<int> GetVisibleTreesBehind(int currentTree, List<int> treesBehind)
        {
            var visibleTreesBehind = new List<int>();

            for (int i = treesBehind.Count - 1; i >= 0; i--)
            {
                var tree = treesBehind[i];

                if (tree < currentTree)
                {
                    visibleTreesBehind.Add(tree);
                    continue;
                }

                if (tree == currentTree
                    || tree > currentTree)
                {
                    visibleTreesBehind.Add(tree);
                    break;
                }
            }

            return visibleTreesBehind;
        }

        private static IEnumerable<int> GetVisibleTreesToRight(List<string> input, int row, int col)
        {
            var currentTree = int.Parse(input[row][col].ToString());
            var treesToRight = GetTreesToRight(input, row, col).ToList();
            return GetVisibleTreesAhead(currentTree, treesToRight);
        }
        
        private static IEnumerable<int> GetVisibleTreesToSouth(List<string> input, int row, int col)
        {
            var currentTree = int.Parse(input[row][col].ToString());
            var treesToRight = GetTreesToSouth(input, row, col).ToList();
            return GetVisibleTreesAhead(currentTree, treesToRight);
        }

        private static IEnumerable<int> GetVisibleTreesAhead(int currentTree, List<int> treesAhead)
        {
            var visibleTreesAhead = new List<int>();

            for (int i = 0; i < treesAhead.Count; i++)
            {
                var tree = treesAhead[i];

                if (tree < currentTree)
                {
                    visibleTreesAhead.Add(tree);
                    continue;
                }

                if (tree == currentTree
                    || tree > currentTree)
                {
                    visibleTreesAhead.Add(tree);
                    break;
                }
            }

            return visibleTreesAhead;
        }
    }
}
