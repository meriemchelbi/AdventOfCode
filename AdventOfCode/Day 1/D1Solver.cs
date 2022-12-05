using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day_1
{
    public class D1Solver
    {
        public int SolvePart1(List<int> totalCaloriesPerElf)
        {
            return totalCaloriesPerElf.Max();
        }
        
        public int SolvePart2(List<int> totalCaloriesPerElf)
        {
            var orderedDescending = totalCaloriesPerElf.OrderByDescending(e => e);
            var topThree = orderedDescending.Take(3);

            var total = 0;

            foreach (var item in topThree)
            {
                total += item;
            }
            
            return total;
        }
    }
}
