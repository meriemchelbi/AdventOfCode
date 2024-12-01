using System.Collections.Generic;

namespace AdventOfCode.Day1
{
    public class D1Solver
    {
        public int SolvePart1(Locations input)
        {
            var distances = 0;

            input.LeftList.Sort();
            input.RightList.Sort();

            for (int i = 0; i < input.LeftList.Count; i++)
            {
                var distance = Math.Abs(input.RightList[i] - input.LeftList[i]);
                distances += distance;
            }

            return distances;
        }

        public int SolvePart2(Locations input)
        {
            var similarityScores = 0;
            var rightListCounts = input.RightList.GroupBy(i => i)
                                                  .ToDictionary(g => g.Key, g => g.Count() );
            foreach (var item in input.LeftList)
            {
                var isInRightList = rightListCounts.TryGetValue(item, out var itemCount);
                
                if (!isInRightList)
                    continue;

                similarityScores += (itemCount * item);
            }

            return similarityScores;
        }
    }
}
