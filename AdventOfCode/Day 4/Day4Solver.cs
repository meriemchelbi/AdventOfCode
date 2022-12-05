using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day_4
{
    public class Day4Solver
    {
        public int SolvePart1(List<(int[], int[])> input)
        {
            var fullyContainedCount = 0;

            foreach (var pair in input)
            {
                var secondContainsFirst = pair.Item1.All(p => pair.Item2.Contains(p));
                var firstContainsSecond = pair.Item2.All(p => pair.Item1.Contains(p));

                if (firstContainsSecond || secondContainsFirst) 
                    fullyContainedCount++;
            }

            return fullyContainedCount;
        }

        public int SolvePart2(List<(string, string)> input)
        {
            return 0;
        }
    }
}
