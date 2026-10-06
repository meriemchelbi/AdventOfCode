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
            var numberOfLoops = 0;

            for (int obstacleRow = 0; obstacleRow < input.Count; obstacleRow++)
            {
                for (int obstacleColumn = 0; obstacleColumn < input[0].Length; obstacleColumn++)
                {
                    var clonedInput = input.ToList();

                    var currentRow = clonedInput.First(i => i.Contains('^'));
                    var guardRow = clonedInput.IndexOf(currentRow);
                    var guardColumn = currentRow.IndexOf('^');

                    // if space is guard starting position, continue
                    if (obstacleRow == guardRow && obstacleColumn == guardColumn)
                        break;

                    // replace space with obstacle
                    clonedInput[obstacleRow] = ReplaceSpace(clonedInput[obstacleRow], obstacleColumn, '#');

                    var startingPosition = (guardRow, guardColumn);
                    var direction = clonedInput[guardRow][guardColumn];

                    var startingState = new State { Position = startingPosition, Direction = direction };
                    var previousPositions = new List<State> { startingState };

                    var currentPosition = startingPosition;

                    while (!IsOnMapEdge(currentPosition.guardRow, currentPosition.guardColumn, clonedInput))
                    {
                        currentPosition = MoveGuard(direction, currentPosition.guardRow, currentPosition.guardColumn, clonedInput);
                        var currentState = new State { Position = currentPosition, Direction = direction };
                        if (previousPositions.Last().Position == currentPosition 
                            && previousPositions.Last().Direction == direction)

                        {
                            break;
                        }
                        if (previousPositions.Any(p => p.Position == currentState.Position
                                                       && p.Direction == currentState.Direction))
                        {
                            numberOfLoops++;
                            break;
                        }

                        previousPositions.Add(currentState);
                        direction = GetNextDirection(direction);
                    }
                }

            }

            return numberOfLoops;
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
                if (nextDistrict.Equals('.') || nextDistrict.Equals('X') || nextDistrict.Equals('^'))
                {
                    input[i] = ReplaceSpace(input[i], CurrentColumn, 'X');

                    if (i == 0)
                    {
                        currentRow = i;
                        break;
                    }

                    continue;
                }
                if (nextDistrict.Equals('#') && i != currentRow - 1)
                {
                    currentRow = i + 1;
                    break;
                }
            }

            return (currentRow, CurrentColumn);
        }

        private (int, int) MoveDown(int currentRow, int CurrentColumn, List<string> input)
        {
            for (int i = currentRow + 1; i < input.Count; i++)
            {
                var nextDistrict = input[i][CurrentColumn];
                if (nextDistrict.Equals('.') || nextDistrict.Equals('X') || nextDistrict.Equals('^'))
                {
                    input[i] = ReplaceSpace(input[i], CurrentColumn, 'X');

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
                if (nextDistrict.Equals('.') || nextDistrict.Equals('X') || nextDistrict.Equals('^'))
                {
                    input[currentRow] = ReplaceSpace(input[currentRow], i, 'X');

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
                if (nextDistrict.Equals('.') || nextDistrict.Equals('X') || nextDistrict.Equals('^'))
                {
                    input[currentRow] = ReplaceSpace(input[currentRow], i, 'X');

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

        private string ReplaceSpace(string row, int currentColumn, char replaceWith)
        {
            var list = row.ToList();
            list[currentColumn] = replaceWith;

            return new string(list.ToArray());
        }

        private class State
        {
            public (int, int) Position;
            public char Direction;
        }
    }
}
