using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day1
{
    public class Solver
    {
        public int CalculateMeasurementIncreases(List<int> inputs)
        {
            var numberOfIncreases = 0;

            for (int i = 1; i < inputs.Count; i++)
            {
                if (inputs[i] > inputs[i - 1])
                {
                    numberOfIncreases++;
                }
            }
            return numberOfIncreases;
        }
        
        public int CalculateSlidingWindowIncreases(List<int> inputs)
        {
            var numberOfIncreases = 0;
            var previousSum = 0;

            for (int i = 0; i < inputs.Count - 2; i++)
            {
                var slidingWindowSum = inputs[i] + inputs[i + 1] + inputs[i + 2];
                
                if (slidingWindowSum > previousSum)
                {
                    numberOfIncreases++;
                }

                previousSum = slidingWindowSum;
            }

            // we don't want to count the first increase from 0 but we want the calculation of the first sum
            return numberOfIncreases - 1;
        }
    }
}
