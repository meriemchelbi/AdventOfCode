using FluentAssertions.Collections;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Day4
{
    public class D4Solver
    {
        public int SolvePart1(List<string> input)
        {
            var countOfXmas = 0;

            for (int row = 0; row < input.Count; row++)
            {
                for (int column = 0; column < input[0].Length; column++)
                {
                    if (input[row][column] == 'X' || input[row][column] == 'S')
                    {
                        countOfXmas += SpellsXmas((row, column), input);
                    }
                }
            }
            
            return countOfXmas;
        }

        public int SolvePart2(List<string> input)
        {
            return 0;
        }

        private int SpellsXmas((int, int) coordinates, List<string> input)
        {
            var countOfXmas = 0;

            if (SpellsHorizontal(coordinates, input))
                countOfXmas++;
            
            if (SpellsDownward(coordinates, input))
                countOfXmas++;
            
            if (SpellsDownwardDiagonal(coordinates, input))
                countOfXmas++;

            if (SpellsUpwardDiagonal(coordinates, input))
                countOfXmas++;

            return countOfXmas;
        }

        private bool SpellsUpwardDiagonal((int row, int column) coordinates, List<string> input)
        {
            if (coordinates.row < 4
                || coordinates.column > input[0].Length - 4)
            {
                return false;
            }

            var sb = new StringBuilder();

            for (int i = 0; i < 4; i++)
            {
                sb.Append(input[coordinates.row - i][coordinates.column + i]);
            }

            var word = sb.ToString();

            return word.Equals("XMAS") || word.Equals("SAMX");
        }

        private bool SpellsDownwardDiagonal((int row, int column) coordinates, List<string> input)
        {
            if (coordinates.column > input[0].Length - 4 
                || coordinates.row > input.Count - 4)
            {
                return false;
            }

            var sb = new StringBuilder();

            for (int i = 0; i < 4; i++)
            {
                sb.Append(input[coordinates.row + i][coordinates.column + i]);
            }

            var word = sb.ToString();

            return word.Equals("XMAS") || word.Equals("SAMX");
        }

        private bool SpellsDownward((int row, int column) coordinates, List<string> input)
        {
            if (coordinates.row > input[0].Length - 4)
            {
                return false;
            }

            var sb = new StringBuilder();

            for (int i = 0; i < 4; i++)
            {
                sb.Append(input[coordinates.row + i][coordinates.column]);
            }

            var word = sb.ToString();

            return word.Equals("XMAS") || word.Equals("SAMX");
        }

        private bool SpellsHorizontal((int row, int column) coordinates, List<string> input)
        {
            if (coordinates.column > input[0].Length - 4)
            {
                return false;
            }

            var sb = new StringBuilder();

            for (int i = 0; i < 4; i++)
            {
                sb.Append(input[coordinates.row][coordinates.column + i]);
            }

            var word = sb.ToString();

            return word.Equals("XMAS") || word.Equals("SAMX");

        }
    }
}
