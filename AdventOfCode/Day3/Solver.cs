using System;
using System.Linq;

namespace AdventOfCode.Day3
{
    class Solver
    {
        internal int Solve(int rightSlope, int downSlope)
        {
            InputParser parser = new();
            var input = parser.Parse();

            var rowPos = 0;
            var rowLength = input[0].Length;

            for (int i = 1; i < input.Count; i += downSlope)
            {
                rowPos = CalculatePosition(rowPos, rowLength, rightSlope);

                var myPosition = input[i][rowPos];

                switch (myPosition) // TODO refactor to use new switch expression
                {
                    case '.':
                        input[i][rowPos] = 'O';
                        break;
                    case '#':
                        input[i][rowPos] = 'X';
                        break;
                    default:
                        break;
                }
                
            }


            return input.Sum(i => i.Count(pos => pos == 'X'));
        }

        public int CalculatePosition(int rowPos, int rowLength, int rightSlope)
        {
            var maxIndex = rowLength - 1;
            if (rowPos <= maxIndex - 3)
                rowPos += rightSlope;
            else
            {
                var remainder = maxIndex - rowPos;
                rowPos = (rightSlope - 1) - Math.Abs(remainder); // 2 because index 2 is the third position
            }

            return rowPos;
        }

        internal int Solve2()
        {
            return 0;
        }
    }
}
