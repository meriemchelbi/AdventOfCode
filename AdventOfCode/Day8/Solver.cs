using System;
using System.Collections.Generic;

namespace AdventOfCode.Day8
{
    public class Solver
    {
        public int SolvePart1(List<string[]> input)
        {
            var uniqueSegmentNos = 0;

            foreach (var output in input)
            {
                foreach (var signal in output)
                {
                    if (signal.Length == 2 || signal.Length == 4 || signal.Length == 3 || signal.Length == 7)
                        uniqueSegmentNos++;
                }
            }

            return uniqueSegmentNos;
        }

        public int SolvePart2(List<string[]> input)
        {
            throw new NotImplementedException();
        }

    }
}
