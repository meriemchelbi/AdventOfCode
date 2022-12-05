using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day_3
{
    public class Solver
    {
        public int SolvePart1(List<(int, int)> strategy)
        {
            var totalScore = 0;

            foreach (var round in strategy)
            {
                var score = RoundOutcome(round) + round.Item2;
                
                // Validation
                if (score > 9)
                {
                    throw new Exception("invalid score!");
                }

                totalScore += score;
            }
            
            return totalScore;
        }
        
        //public int SolvePart2(List<int> totalCaloriesPerElf)
        //{
        //    var orderedDescending = totalCaloriesPerElf.OrderByDescending(e => e);
        //    var topThree = orderedDescending.Take(3);

        //    var total = 0;

        //    foreach (var item in topThree)
        //    {
        //        total += item;
        //    }
            
        //    return total;
        //}

        private int RoundOutcome((int, int) strategy)
        {
            // draw
            if (strategy.Item1 == strategy.Item2)
            {
                return 3;
            }
            
            // win
            if (strategy.Item1 < strategy.Item2)
            {
                return 6;
            }

            // loss
            if (strategy.Item1 > strategy.Item2)
            {
                return 0;
            }

            else return 1000;
        }
    }
}
