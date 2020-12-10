using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day10
{
    class Solver
    {
        internal long Solve()
        {
            var parser = new InputParser();
            var input = parser.Parse();
            input.Sort();

            var deviceJoltage = input[^1] + 3;
            input.Add(deviceJoltage);

            var oneJoltDifferences = 0;
            var threeJoltDifferences = 0;

            var current = 0; // charging outlet joltage

            while (current < deviceJoltage)
            {
                var options = CalculateAdaptorOptions(current);

                var selected = input.FirstOrDefault(i => options.Any(o => o == i));

                if (selected == default)
                    break;
                
                var joltageDifference = selected - current;

                switch (joltageDifference)
                {
                    case 1:
                        oneJoltDifferences++;
                        break;
                    case 3:
                        threeJoltDifferences++;
                        break;
                    default:
                        break;
                }

                current = selected;
            }

            return oneJoltDifferences * threeJoltDifferences;
        }

        private List<int> CalculateAdaptorOptions(int current)
        {
            return new List<int> 
            { 
                current + 1,
                current + 2,
                current + 3
            };
        }

        internal int Solve2()
        {
            var parser = new InputParser();
            var input = parser.Parse();

            return 0;
        }
    }
}
