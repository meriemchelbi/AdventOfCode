using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day6
{
    public class Solver
    {
        public int SolvePart1(List<int> input, int noOfDays)
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

            for (int day = 0; day < noOfDays; day++)
            {
                var countOfZeros = lifespanCount[0];
                for (int lifespan = 1; lifespan < lifespanCount.Count; lifespan++)
                {
                    int countOfLifespan = lifespanCount[lifespan];

                    var newLifespan = lifespan - 1;
                    lifespanCount[newLifespan] = countOfLifespan;
                    lifespanCount[lifespan] = 0;

                    if (lifespan == 8)
                    {
                        lifespanCount[8] += countOfZeros;
                        lifespanCount[6] += countOfZeros;
                    }
                }
            }

            return lifespanCount.Sum(l => l.Value);
        }


        public long SolvePart2(List<int> input, int noOfDays)
        {
            var lifespanCount = new Dictionary<int, long>
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

            for (int day = 0; day < noOfDays; day++)
            {
                var countOfZeros = lifespanCount[0];
                for (int lifespan = 1; lifespan < lifespanCount.Count; lifespan++)
                {
                    var countOfLifespan = Convert.ToInt64(lifespanCount[lifespan]);

                    var newLifespan = lifespan - 1;
                    lifespanCount[newLifespan] = countOfLifespan;
                    lifespanCount[lifespan] = 0;

                    if (lifespan == 8)
                    {
                        lifespanCount[8] += countOfZeros;
                        lifespanCount[6] += countOfZeros;
                    }
                }
            }

            return lifespanCount.Sum(l => l.Value);
        }
    }
}
