using AdventOfCode.Day2;
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

            foreach (var row in input)
            {
                var remainder = rowLength - 1 - rowPos;
                if (remainder >= 3)
                    rowPos += 3;
                else
                    rowPos = 3 + remainder;
                    

                var myPosition = row[rowPos];

                switch (myPosition) // TODO refactor to use new switch expression
                {
                    case '.':
                        row[rowPos] = 'O';
                        break;
                    case '#':
                        row[rowPos] = 'X';
                        break;
                    default:
                        break;
                }

            }

            return input.Sum(i => i.Count(pos => pos == 'X'));
        }
        
        internal int Solve2()
        {
            return 0;
        }
    }
}
