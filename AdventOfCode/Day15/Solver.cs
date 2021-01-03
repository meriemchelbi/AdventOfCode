using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day15
{
    class Solver
    {
        private Dictionary<int, List<int>> _memory;

        internal int Solve(uint targetIteration, params int[] input)
        {
            // build dictionary with each number and its corresponding index
            var inputList = input.ToList();
            _memory = input.ToDictionary(i => i, i => new List<int> { inputList.IndexOf(i) + 1 });
            var lastSpoken = input.Last();

            for (int c = input.Length + 1; c < targetIteration + 1; c++)
            {
                var previouslySpoken = _memory.TryGetValue(lastSpoken, out var rounds);

                // if first round OR number not in memory, speak 0
                if (previouslySpoken && rounds.Count == 1 || !previouslySpoken)
                    lastSpoken = 0;

                // if number in memory, speak the age of the number
                else if (previouslySpoken)
                    lastSpoken = rounds.Count > 1 ? rounds[^1] - rounds[^2] : rounds[0];

                AddToMemory(lastSpoken, c);
            }

            return lastSpoken;
        }

        private void AddToMemory(int number, int round)
        {
            var previouslySpoken = _memory.TryGetValue(number, out var rounds);
            if (previouslySpoken)
                _memory[number].Add(round);

            else
                _memory.Add(number, new List<int> { round });
        }

        internal uint Solve2()
        {

            return 0;
        }
    }
}
