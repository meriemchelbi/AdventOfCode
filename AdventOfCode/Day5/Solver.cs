using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day5
{
    public class Solver
    {
        public int SolvePart1(List<Line> input)
        {
            var pointsCount = new Dictionary<(int, int), int>();

            foreach (var line in input)
            {
                foreach (var point in line.Points)
                {
                    var success = pointsCount.TryAdd(point, 1);
                    
                    if (!success)
                        pointsCount[point] += 1;
                }
            }
            
            return pointsCount.Where(p => p.Value >= 2).Count();
        }

        public int SolvePart2(List<string> input)
        {
            throw new NotImplementedException();
        }
    }
}
