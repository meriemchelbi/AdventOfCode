using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day9
{
    class Solver
    {
        internal long Solve()
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

        internal int Solve2()
        {
            var parser = new InputParser();
            var input = parser.Parse();

            return 0;
        }
    }
}
