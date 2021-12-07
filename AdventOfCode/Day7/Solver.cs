using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day7
{
    public class Solver
    {
        public int SolvePart1(List<int> input)
        {
            var positionsCount = input.GroupBy(i => i).ToDictionary(g => g.Key, g => g.Count());

            var uniquePositions = positionsCount.Select(p => p.Key).ToList();
            
            var fuelExpenditures = new List<int>();

            foreach (var position in uniquePositions)
            {
                var fuelExpenditure = 0;

                foreach (var entry in positionsCount)
                {
                    var fuel = Math.Abs(position - entry.Key);
                    if (fuel == 0)
                        continue;
                    else
                        fuelExpenditure += fuel * entry.Value;
                }

                fuelExpenditures.Add(fuelExpenditure);
            }

            return fuelExpenditures.OrderBy(f => f).First();
        }

        public int SolvePart2(List<int> input)
        {
            var positionsCount = input.GroupBy(i => i).ToDictionary(g => g.Key, g => g.Count());

            var uniquePositions = positionsCount.Select(p => p.Key).OrderByDescending(p => p).ToList();
            var maxPosition = uniquePositions.First();
            var minPosition = uniquePositions.Last();

            var fuelExpenditures = new List<int>();

            for (int i = minPosition; i < maxPosition; i++)
            {
                var fuelExpenditure = 0;

                foreach (var position in uniquePositions)
                {
                    var fuelDifference = Math.Abs(position - i);
                    if (fuelDifference == 0)
                        continue;
                    else
                    {
                        var fuel = GetExponentialFuelConsumption(fuelDifference);
                        fuelExpenditure += fuel * positionsCount[position];
                    }
                }

                fuelExpenditures.Add(fuelExpenditure);
            }

            return fuelExpenditures.OrderBy(f => f).First();
            
        }

        private int GetExponentialFuelConsumption(int value)
        {
            int sum = 0;

            for (int i = 1; i < value + 1; i++)
            {
                sum += i;
            }

            return sum;
        }
    }
}
