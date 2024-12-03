using System.Collections.Generic;

namespace AdventOfCode.Day3
{
    public class D3Solver
    {
        public int SolvePart1(List<(int, int)> input)
        {
            var result = 0;

            foreach (var item in input)
            {
                result += (item.Item1 * item.Item2);
            }
            
            return result;
        }
        
        public int SolvePart2(List<(int, int)> input)
        {
            var result = 0;

            foreach (var item in input)
            {
                result += (item.Item1 * item.Item2);
            }

            return result;
        }
    }
}
