using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day10
{
    class Solver
    {
        internal long Solve(string inputFileName)
        {
            var parser = new InputParser();
            var input = parser.Parse(inputFileName);
            input.Sort();

            var deviceJoltage = input[^1] + 3;
            input.Add(deviceJoltage);

            var oneJoltDifferences = 0;
            var threeJoltDifferences = 0;

            var current = 0; // charging outlet joltage

            while (current < deviceJoltage)
            {
                var options = CalculateAdaptorOptions(current);

                var selected = input.FirstOrDefault(i => options.Any(o => o == i));

                if (selected == default)
                    break;
                
                var joltageDifference = selected - current;

                switch (joltageDifference)
                {
                    case 1:
                        oneJoltDifferences++;
                        break;
                    case 3:
                        threeJoltDifferences++;
                        break;
                    default:
                        break;
                }

                current = selected;
            }

            return oneJoltDifferences * threeJoltDifferences;
        }

        private List<int> CalculateAdaptorOptions(int current)
        {
            return new List<int> 
            { 
                current + 1,
                current + 2,
                current + 3
            };
        }

        internal int Solve2(string inputFileName)
        {
            var parser = new InputParser();
            var input = parser.Parse(inputFileName);
            input.Sort();

            var deviceJoltage = input[^1] + 3;
            input.Add(deviceJoltage);
            input.Insert(0, 0);

            var matchesHigher = new Dictionary<int, List<int>>();
            // for each entry get matches in dictionary
            foreach (var item in input)
            {
                var options = CalculateAdaptorOptions(item);
                var matches = options.Where(o => input.Contains(o)).ToList();
                matchesHigher[item] = matches;
            }

            var total = TotalWinningCombinations2(input, matchesHigher, 0);

            return total;
        }

        //private int TotalWinningCombinations1(List<int> input, int current)
        //{
        //    var deviceJoltage = input[^1];
        //    var total = 0;

        //    var options = CalculateAdaptorOptions(current);
        //    var matches = options.Where(o => input.Contains(o)).ToList();

        //    if (matches.Count == 0)
        //        return 0;

        //    foreach (var match in matches)
        //    {
        //        if (match == deviceJoltage)
        //        {
        //            total++;
        //        }

        //        else
        //        {
        //            total += TotalWinningCombinations1(input, match);
        //        }
        //    }

        //    return total;
        //}
    //}
    
    private int TotalWinningCombinations2(List<int> input, Dictionary<int, List<int>> matches, int current)
        {
            var total = 0;

            while (matches.Any(m => m.Value.Count > 1))
            {
                var highest = matches.Where(m => m.Value.Count > 1).Last();
                var timesMatched = matches.Count(m => m.Value.Contains(highest.Key));
                total += timesMatched * (highest.Value.Count);
                matches.Remove(highest.Key);
            }

            return total;

            //var total = 0;
            //var options = CalculateAdaptorOptions(current);
            //var matches = options.Where(o => input.Contains(o)).ToList();

            //if (matches.Count == 0)
            //    return 0;

            //if (matches.Count > 1)
            //{
            //    total += matches.Count - 1;
            //}

            //foreach (var match in matches)
            //{
            //    total += TotalWinningCombinations2(input, match);
            //}

            //return total;
        }
    }
}
