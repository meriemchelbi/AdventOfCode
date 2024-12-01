using System.Collections.Generic;

namespace AdventOfCode.Day1
{
    public class D1Solver
    {
        public int SolvePart1(Locations input)
        {
            var distances = new List<int>();

            input.LeftList.Sort();
            input.RightList.Sort();

            for (int i = 0; i < input.LeftList.Count; i++)
            {
                var distance = Math.Abs(input.RightList[i] - input.LeftList[i]);
                distances.Add(distance);
            }

            return distances.Sum();
        }

        public int SolvePart2(Locations input)
        {
            var similarityScores = new List<int>();
            var rightListCounts = input.RightList.GroupBy(i => i)
                                                  .ToDictionary(g => g.Key, g => g.Count() );
            foreach (var item in input.LeftList)
            {
                var isInRightList = rightListCounts.TryGetValue(item, out var itemCount);
                
                if (!isInRightList)
                    continue;

                similarityScores.Add(itemCount * item);
            }

            return similarityScores.Sum();
        }
    }
}
