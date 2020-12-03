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

            for (int i = downSlope; i < input.Count; i += downSlope)
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
            if (rowPos <= maxIndex - rightSlope)
                rowPos += rightSlope;
            else
            {
                var remainder = maxIndex - rowPos;
                rowPos = (rightSlope - 1) - Math.Abs(remainder); // 2 because index 2 is the third position
            }

            return rowPos;
        }

        internal uint Solve2()
        {
            var slope1 = (uint)Solve(1, 1);
            var slope2 = (uint)Solve(3, 1);
            var slope3 = (uint)Solve(5, 1);
            var slope4 = (uint)Solve(7, 1);
            var slope5 = (uint)Solve(1, 2);

            //var a = slope1 * slope2;
            //var b = a * slope3;
            //var c = b * slope4;
            //var d = c * slope5;
            var product = slope1 * slope2 * slope3 * slope4 * slope5;

            return product;
        }
    }
}
