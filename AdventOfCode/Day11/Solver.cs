using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day11
{
    class Solver
    {
        internal List<char[]> _input;

        internal int Solve(string inputFileName)
        {
            var parser = new InputParser();
            _input = parser.Parse(inputFileName);

            var occupiedSeats = int.MinValue;
            var previousOccupied = int.MaxValue;
            var layoutWidth = _input[0].Length;

            while (occupiedSeats != previousOccupied)
            {
                var newLayout = new List<char[]>();

                for (int rowIndex = 0; rowIndex < _input.Count; rowIndex++)
                {
                    var width = new char[layoutWidth];

                    for (int columnIndex = 0; columnIndex < layoutWidth; columnIndex++)
                    {
                        var currentSeat = _input[rowIndex][columnIndex];
                        var neighbours = CalculateAdjacentSeats(rowIndex, columnIndex);

                        //If a seat is empty(L) and there are no occupied seats adjacent to it, the seat becomes occupied.
                        if (currentSeat.Equals('L') && !neighbours.Contains('#'))
                            width[columnIndex] = '#';

                        //If a seat is occupied(#) and four or more seats adjacent to it are also occupied, the seat becomes empty.
                        else if (currentSeat.Equals('#')
                            && neighbours.Where(n => n.Equals('#')).Count() >= 4)
                            width[columnIndex] = 'L';

                        else
                            width[columnIndex] = currentSeat;
                    }

                    newLayout.Add(width);
                }

                previousOccupied = occupiedSeats;
                occupiedSeats = newLayout.Select(r => r.Count(item => item.Equals('#'))).Sum();
                _input = newLayout;
            }

            return occupiedSeats;
        }

        internal List<char> CalculateAdjacentSeats(int rowIndex, int columnIndex)
        {
            var neighbours = new List<char>();

            // East
            if (columnIndex < _input[0].Length - 1)
                neighbours.Add(_input[rowIndex][columnIndex + 1]);

            // NorthEast
            if (rowIndex > 0 && columnIndex < _input[0].Length - 1)
                neighbours.Add(_input[rowIndex - 1][columnIndex + 1]);

            // North
            if (rowIndex > 0)
                neighbours.Add(_input[rowIndex - 1][columnIndex]);

            // NorthWest
            if (columnIndex > 0 && rowIndex > 0)
                neighbours.Add(_input[rowIndex - 1][columnIndex - 1]);

            // West
            if (columnIndex > 0)
                neighbours.Add(_input[rowIndex][columnIndex - 1]);

            // SouthWest
            if (rowIndex < _input.Count - 1 && columnIndex > 0)
                neighbours.Add(_input[rowIndex + 1][columnIndex - 1]);

            // South
            if (rowIndex < _input.Count - 1)
                neighbours.Add(_input[rowIndex + 1][columnIndex]);

            // SouthEast
            if (rowIndex < _input.Count - 1 && columnIndex < _input[0].Length - 1)
                neighbours.Add(_input[rowIndex + 1][columnIndex + 1]);

            return neighbours;
        }

        internal int Solve2(string inputFileName)
        {
            var parser = new InputParser();
            _input = parser.Parse(inputFileName);

            var occupiedSeats = int.MinValue;
            var previousOccupied = int.MaxValue;
            var layoutWidth = _input[0].Length;

            while (occupiedSeats != previousOccupied)
            {
                var newLayout = new List<char[]>();

                for (int rowIndex = 0; rowIndex < _input.Count; rowIndex++)
                {
                    var width = new char[layoutWidth];

                    for (int columnIndex = 0; columnIndex < layoutWidth; columnIndex++)
                    {
                        var currentSeat = _input[rowIndex][columnIndex];
                        var visibleSeats = CalculateVisibleSeats(rowIndex, columnIndex);

                        //If a seat is empty(L) and there are no occupied seats adjacent to it, the seat becomes occupied.
                        if (currentSeat.Equals('L') && !visibleSeats.Contains('#'))
                            width[columnIndex] = '#';

                        //If a seat is occupied(#) and four or more seats adjacent to it are also occupied, the seat becomes empty.
                        else if (currentSeat.Equals('#')
                            && visibleSeats.Where(n => n.Equals('#')).Count() >= 5)
                            width[columnIndex] = 'L';

                        else
                            width[columnIndex] = currentSeat;
                    }

                    newLayout.Add(width);
                }

                previousOccupied = occupiedSeats;
                occupiedSeats = newLayout.Select(r => r.Count(item => item.Equals('#'))).Sum();
                _input = newLayout;
            }

            return occupiedSeats;
        }

        internal List<char> CalculateVisibleSeats(int rowIndex, int columnIndex)
        {
            var visible = new List<char>
            {
                FindNextVisible(rowIndex, columnIndex + 1, "east"),
                FindNextVisible(rowIndex, columnIndex - 1, "west"),

                FindNextVisible(rowIndex - 1, columnIndex, "north"),
                FindNextVisible(rowIndex - 1, columnIndex + 1, "northEast"),
                FindNextVisible(rowIndex - 1, columnIndex - 1, "northWest"),

                FindNextVisible(rowIndex + 1, columnIndex - 1, "southWest"),
                FindNextVisible(rowIndex + 1, columnIndex, "south"),
                FindNextVisible(rowIndex + 1, columnIndex + 1, "southEast")
            };

            return visible.Where(v => v != default).ToList();
        }

        private char FindNextVisible(int rowIndex, int columnIndex, string direction)
        {
            if (rowIndex >= _input.Count || rowIndex < 0
                || columnIndex >= _input[0].Length || columnIndex < 0)
                return default;
            
            var currentSeat = _input[rowIndex][columnIndex];
            
            if (currentSeat.Equals('#') || currentSeat.Equals('L'))
                return currentSeat;
            
            if (direction.Equals("north") && rowIndex > 0)
                return FindNextVisible(rowIndex - 1, columnIndex, direction);

            if (direction.Equals("northEast") 
                && rowIndex > 0 && columnIndex < _input[0].Length - 1)
                return FindNextVisible(rowIndex - 1, columnIndex + 1, direction);
            
            if (direction.Equals("northWest") 
                && columnIndex > 0 
                && columnIndex > 0 && rowIndex > 0)
                return FindNextVisible(rowIndex - 1, columnIndex - 1, direction);

            if (direction.Equals("south") 
                && rowIndex < _input.Count - 1)
                return FindNextVisible(rowIndex + 1, columnIndex, direction);
            
            if (direction.Equals("southEast") 
                && rowIndex < _input.Count - 1 && columnIndex < _input[0].Length - 1)
                return FindNextVisible(rowIndex + 1, columnIndex + 1, direction);
            
            if (direction.Equals("southWest") 
                && rowIndex < _input.Count - 1 && columnIndex > 0)
                return FindNextVisible(rowIndex + 1, columnIndex - 1, direction);

            if (direction.Equals("east") 
                && columnIndex < _input[0].Length - 1)
                return FindNextVisible(rowIndex, columnIndex + 1, direction);

            if (direction.Equals("west") 
                && columnIndex > 0)
                return FindNextVisible(rowIndex, columnIndex - 1, direction);

            else
                return default;
        }
    }
}
