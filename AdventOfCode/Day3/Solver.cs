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
                if (rowPos == rowLength)
                    rowPos = 0;

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

                rowPos++;
            }

            return input.Sum(i => i.Count(pos => pos == 'X'));
        }
        
        internal int Solve2()
        {
            return 0;
        }
    }
}
