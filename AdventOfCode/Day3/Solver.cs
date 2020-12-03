using System;
using System.Linq;

namespace AdventOfCode.Day3
{
    class Solver
    {
        internal int Solve()
        {
            InputParser parser = new();
            var input = parser.Parse();

            var rowPos = 0;
            var rowLength = input[0].Length;

            for (int i = 1; i < input.Count; i++)
            {
                rowPos = CalculatePosition(rowPos, rowLength);

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

        public int CalculatePosition(int rowPos, int rowLength)
        {
            var maxIndex = rowLength - 1;
            if (rowPos <= maxIndex - 3)
                rowPos += 3;
            else
            {
                var remainder = maxIndex - rowPos;
                rowPos = 2 - Math.Abs(remainder); // 2 because index 2 is the third position
            }

            return rowPos;
        }

        internal int Solve2()
        {
            return 0;
        }
    }
}
