using System.Collections.Generic;

namespace AdventOfCode.Day6
{
    public class D6Solver
    {
        public int SolvePart1(List<string> input)
        {
            var currentRow = input.First(i => i.Contains('^'));
            var guardRow = input.IndexOf(currentRow);
            var guardColumn = currentRow.IndexOf('^');

            var currentPosition = (guardRow, guardColumn);
            var guard = input[guardRow][guardColumn];

            while (!IsOnMapEdge(currentPosition.guardRow, currentPosition.guardColumn, input))
            {
                currentPosition = MoveGuard(guard, currentPosition.guardRow, currentPosition.guardColumn, input);
                guard = GetNextDirection(guard);
            }

            return input.Sum(i => i.Count(c => c == 'X')) + 1;
        }

        public int SolvePart2(List<string> input)
        {
            return 0;
        }
        private char GetNextDirection(char guard)
        {
            switch (guard)
            {
                case ('^'):
                    return '>';
                case ('>'):
                    return 'v';
                case ('v'):
                    return '<';
                case ('<'):
                    return '^';
                default:
                    break;
            }
            return 'e';
        }

        private bool IsOnMapEdge(int row, int column, List<string> input)
        {
            var leftEdge = 0;
            var rightEdge = input[0].Length - 1;
            var topEdge = 0;
            var bottomEdge = input.Count - 1;
            
            return column == leftEdge || column == rightEdge || row == topEdge || row == bottomEdge;
        }

        private (int, int) MoveGuard(Char guard,
                                     int currentRow,
                                     int CurrentColumn,
                                     List<string> input)
        {
            switch (guard)
            {
                case '^':
                    return MoveUp(currentRow, CurrentColumn, input);
                case 'v':
                    return MoveDown(currentRow, CurrentColumn, input);
                case '<':
                    return MoveLeft(currentRow, CurrentColumn, input);
                case '>':
                    return MoveRight(currentRow, CurrentColumn, input);
                default: break;
            }

            return (0, 0);
        }

        private (int, int) MoveUp(int currentRow, int CurrentColumn, List<string> input)
        {
            for (int i = currentRow - 1; i > -1; i--)
            {
                var nextDistrict = input[i][CurrentColumn];
                if (nextDistrict.Equals('.') || nextDistrict.Equals('X'))
                {
                    input[i] = MarkVisited(input[i], CurrentColumn);

                    if (i == 0)
                    {
                        currentRow = i;
                        break;
                    }

                    continue;
                }
                if (nextDistrict.Equals('#'))
                {
                    currentRow = i + 1;
                    break;
                }
            }

            return (currentRow, CurrentColumn);
        }

        private string MarkVisited(string row, int currentColumn)
        {
            var list = row.ToList();
            list[currentColumn] = 'X';

            return new string(list.ToArray());
        }

        private (int, int) MoveDown(int currentRow, int CurrentColumn, List<string> input)
        {
            for (int i = currentRow + 1; i < input.Count; i++)
            {
                var nextDistrict = input[i][CurrentColumn];
                if (nextDistrict.Equals('.') || nextDistrict.Equals('X'))
                {
                    input[i] = MarkVisited(input[i], CurrentColumn);

                    if (i == input.Count - 1)
                    {
                        currentRow = i;
                        break;
                    }
                    continue;
                }
                if (nextDistrict.Equals('#'))
                {
                    currentRow = i - 1;
                    break;
                }
            }

            return (currentRow, CurrentColumn);
        }
        
        private (int, int) MoveLeft(int currentRow, int currentColumn, List<string> input)
        {
            for (int i = currentColumn - 1; i > -1; i--)
            {
                var nextDistrict = input[currentRow][i];
                if (nextDistrict.Equals('.') || nextDistrict.Equals('X'))
                {
                    input[currentRow] = MarkVisited(input[currentRow], i);

                    if (i == 0)
                    {
                        currentColumn = i;
                        break;
                    }
                    continue;
                }
                if (nextDistrict.Equals('#'))
                {
                    currentColumn = i + 1;
                    break;
                }
            }

            return (currentRow, currentColumn);
        }
        
        private (int, int) MoveRight(int currentRow, int CurrentColumn, List<string> input)
        {
            for (int i = CurrentColumn + 1; i < input.Count; i++)
            {
                var nextDistrict = input[currentRow][i];
                if (nextDistrict.Equals('.') || nextDistrict.Equals('X'))
                {
                    input[currentRow] = MarkVisited(input[currentRow], i);

                    if (i == input[0].Length - 1)
                    {
                        CurrentColumn = i;
                        break;
                    }
                    continue;
                }
                if (nextDistrict.Equals('#'))
                {
                    CurrentColumn = i - 1;
                    break;
                }
            }

            return (currentRow, CurrentColumn);
        }
    }
}
