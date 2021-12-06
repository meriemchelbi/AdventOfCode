using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day6
{
    public class Solver
    {
        public int SolvePart1(List<int> input)
        {
            var lifespanCount = new Dictionary<int, int> 
            { 
                { 0, 0 },
                { 1, 0 },
                { 2, 0 },
                { 3, 0 },
                { 4, 0 },
                { 5, 0 },
                { 6, 0 },
                { 7, 0 },
                { 8, 0 }
            };

            foreach (var fishLifespan in input)
            {
                lifespanCount[fishLifespan] += 1;
            }

            for (int i = 0; i < 80; i++)
            {
                for (int lifespan = 0; lifespan < lifespanCount.Count; lifespan++)
                {
                    int countOfLifespan = lifespanCount[lifespan];
                    
                    if (lifespan == 0)
                    {

                        lifespanCount[8] += countOfLifespan;
                        lifespanCount[6] += countOfLifespan;
                        lifespanCount[0] = 0;
                    }

                    else
                    {
                        var newLifespan = lifespan - 1;
                        lifespanCount[newLifespan] += countOfLifespan;
                        lifespanCount[lifespan] = 0;
                    }
                }
            }

            return lifespanCount.Select(l => l.Key * l.Value).Sum();
        }

        public int SolvePart2(List<string> input)
        {
            throw new NotImplementedException();
        }
    }
}
