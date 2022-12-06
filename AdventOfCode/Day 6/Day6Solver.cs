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
            return GetResult(input, 4);
        }

        public int SolvePart2(string input)
        {
            return GetResult(input, 14);
        }

        private static int GetResult(string input, int markerLength)
        {
            var result = 0;

            for (int i = 0; i < input.Length; i++)
            {
                var potentialMarker = input.Substring(i, markerLength);
                var uniqueCharacters = potentialMarker.Distinct().Count();
                if (uniqueCharacters == markerLength)
                {
                    result = i + markerLength;
                    break;
                }
            }

            return result;
        }
    }
}
