using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day9
{
    class Solver
    {
        internal long FindInvalidEntry()
        {
            var parser = new InputParser();
            var input = parser.Parse();

            for (int i = 25; i < input.Count; i++)
            {
                var current = input[i];
                var preambleStart = i - 25;

                var preamble = input.GetRange(preambleStart , 25);
                var isValid = IsValidNumber(current, preamble);
                if (isValid)
                    continue;
                else
                    return current;
            }

            return 0;
        }

        internal bool IsValidNumber(long number, List<long> preamble)
        {
            for (int i = 0; i < preamble.Count; i++)
            {
                for (int j = 0; j < preamble.Count; j++)
                {
                    if (preamble[i] == preamble[j])
                        continue;

                    if (preamble[i] + preamble[j] == number)
                        return true;
                }
            }
            return false;
        }

        internal long Solve2()
        {
            var parser = new InputParser();
            var input = parser.Parse();
            var firstIndex = 0;
            var lastIndex = 0;

            for (int start = 0; start < input.Count; start++)
            {
                long sum = 0;

                for (int i = start; i < input.Count - start; i++)
                {
                    sum += input[i];
                    if (sum == 22406676)
                    {
                        firstIndex = start;
                        lastIndex = i;
                        break;
                    }
                }
            }

            var contiguousLength = lastIndex - firstIndex;
            var contiguousNumbers = input.GetRange(firstIndex, contiguousLength);
            contiguousNumbers.Sort();
            var sumSmallestLargest = contiguousNumbers[0] + contiguousNumbers[^1];

            return sumSmallestLargest;
        }
    }
}
