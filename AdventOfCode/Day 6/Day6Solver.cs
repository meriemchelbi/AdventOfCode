using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day_6
{
    public class Day6Solver
    {
        public int SolvePart1(string input)
        {
            var result = 0;

            for (int i = 0; i < input.Length; i++)
            {
                var potentialMarker = input.Substring(i, 4);
                var uniqueCharacters = potentialMarker.Distinct().Count();
                if (uniqueCharacters == 4)
                {
                    result = i + 4;
                    break;
                }
            }

            return result;
        }

        public int SolvePart2(string input)
        {
            return 0;
        }
    }
}
