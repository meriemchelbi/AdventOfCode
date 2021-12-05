using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day4
{
    public class Solver
    {
        public int SolvePart1(BingoGame input)
        {
            var lastNumberCalled = 0;
            (int, bool)[][] winningBoard = null;

            foreach (var number in input.CallingNumbers)
            {
                lastNumberCalled = number;

                foreach (var board in input.Boards)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (board[j][i].Item1 == lastNumberCalled)
                            {
                                board[j][i].Item2 = true;
                                if (IsWinningBoard(board, i, j))
                                {
                                    winningBoard = board;
                                    break;
                                }
                            }
                        }
                    }
                    continue;
                }
            }

            var sumOfUnmarked = 0;

            foreach (var row in winningBoard)
            {
                foreach (var number in row)
                {
                    if (number.Item2 is false)
                        sumOfUnmarked += number.Item1;
                }
            }
            return sumOfUnmarked * lastNumberCalled;
        }

        private bool IsWinningBoard((int, bool)[][] board, int rowIndex, int columnIndex)
        {
            if (!board[rowIndex].Any(n => n.Item2 is false))
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

        public int SolvePart2(List<string> input)
        {
            throw new NotImplementedException();
        }
    }
}
