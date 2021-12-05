using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day4
{
    public class Solver
    {
        public int SolvePart1(BingoGame input)
        {
            (int, bool)[][] winningBoard = FindWinningBoard(input, out var lastNumberCalled);
            int sumOfUnmarked = CalculateSumOfUnmarked(winningBoard);
            return sumOfUnmarked * lastNumberCalled;
        }


        public int SolvePart2(BingoGame input)
        {
            var remainingLosingBoards = input.Boards.Count;
            (int, bool)[][] lastBoard = null;
            var lastNumberCalled = 0;

            while (remainingLosingBoards > 0)
            {
                lastBoard = FindWinningBoard(input, out lastNumberCalled);
                input.Boards.Remove(lastBoard);
                remainingLosingBoards--;
            }

            var sumOfUnmarked = CalculateSumOfUnmarked(lastBoard);

            return sumOfUnmarked * lastNumberCalled;
        }

        private (int, bool)[][] FindWinningBoard(BingoGame input, out int lastNumberCalled)
        {
            lastNumberCalled = 0;

            foreach (var number in input.CallingNumbers)
            {
                lastNumberCalled = number;

                foreach (var board in input.Boards)
                {
                    for (int rowIndex = 0; rowIndex < 5; rowIndex++)
                    {
                        for (int columnIndex = 0; columnIndex < 5; columnIndex++)
                        {
                            if (board[rowIndex][columnIndex].Item1 == lastNumberCalled)
                            {
                                board[rowIndex][columnIndex].Item2 = true;
                                if (IsWinningBoard(board, rowIndex, columnIndex))
                                {
                                    return board;
                                }
                            }
                        }
                    }
                    continue;
                }
            }

            return default;
        }

        private bool IsWinningBoard((int, bool)[][] board, int rowIndex, int columnIndex)
        {
            var rowElements = board[rowIndex];
            if (!(rowElements.Any(n => n.Item2 is false)))
                return true;

            var columnTrueCount = 0;
            foreach (var row in board)
            {
                if (row[columnIndex].Item2 is true)
                    columnTrueCount++;
            }

            if (columnTrueCount == 5)
                return true;

            return false;
        }

        private static int CalculateSumOfUnmarked((int, bool)[][] board)
        {
            var sumOfUnmarked = 0;

            foreach (var row in board)
            {
                foreach (var number in row)
                {
                    if (number.Item2 is false)
                        sumOfUnmarked += number.Item1;
                }
            }

            return sumOfUnmarked;
        }
    }
}
