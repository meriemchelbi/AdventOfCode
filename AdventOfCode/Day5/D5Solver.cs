using FluentAssertions.Equivalency;
using System.Collections.Generic;
using System.Net.Cache;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day5
{
    public class D5Solver
    {
        private Dictionary<int, List<int>> _orderedRules;

        public int SolvePart1(List<(int, int)> orderingRules, List<List<int>> pageUpdates)
        {
            _orderedRules = orderingRules.GroupBy(r => r.Item1)
                .ToDictionary(g => g.Key, g => g.Select(g => g.Item2).ToList());

            var correctlyOrderedUpdates = new List<List<int>>();

            foreach (var update in pageUpdates)
            {
                if (IsCorrectlyOrdered(update))
                    correctlyOrderedUpdates.Add(update);
            }

            var middlePages = correctlyOrderedUpdates.Select(u => GetMiddlePage(u));
            
            return middlePages.Sum();
        }

        public int SolvePart2(List<(int, int)> orderingRules, List<List<int>> pageUpdates)
        {
            _orderedRules = orderingRules.GroupBy(r => r.Item1)
                .ToDictionary(g => g.Key, g => g.Select(g => g.Item2).ToList());

            var incorrectlyOrderedUpdates = new List<List<int>>();

            foreach (var update in pageUpdates)
            {
                if (!IsCorrectlyOrdered(update))
                {
                    var reorderedUpdate = Reorder(update);
                    incorrectlyOrderedUpdates.Add(reorderedUpdate);
                }
            }

            var middlePages = incorrectlyOrderedUpdates.Select(u => GetMiddlePage(u));

            return middlePages.Sum();
        }

        private List<int> Reorder(List<int> update)
        {
            var orderedList = new List<int>();
            var relevantRules = _orderedRules.Where(r => update.Contains(r.Key)).ToList();

            // remove pages from values which aren't in update
            var filteredRules = relevantRules.ToDictionary(r => r.Key, r => r.Value.Intersect(update).ToList());

            var firstItem = filteredRules.Where(r => update.Contains(r.Key))
                                            .OrderByDescending(r => r.Value.Count)
                                            .FirstOrDefault();


            foreach (var child in firstItem.Value)
            {
                if (!update.Contains(child) || orderedList.Contains(child))
                    continue;

                if (!orderedList.Contains(child))
                {
                    GetSmallestChild(child, orderedList, filteredRules);
                }
            }

            orderedList.Add(firstItem.Key);

            return orderedList.Distinct().Reverse().ToList();
        }

        private void GetSmallestChild(int item,
                                      List<int> orderedList,
                                      Dictionary<int, List<int>> filteredRules)
        {
            var hasRule = filteredRules.TryGetValue(item, out var rule);

            if (!hasRule || rule.Count == 0)
            {
                orderedList.Add(item);
                return;
            }

            if (orderedList.All(o => rule.Contains(o)))
            {
                orderedList.Add(item);
                return;
            }

            foreach (var child in rule)
            {
                GetSmallestChild(child, orderedList, filteredRules);
            }
        }

        private bool IsCorrectlyOrdered(List<int> update)
        {
            for (int i = 0; i < update.Count; i++)
            {
                var pageNumber = update[i];
                var hasRule = _orderedRules.TryGetValue(pageNumber, out var subsequentPages);
                
                if (!hasRule && i != update.Count - 1)
                    return false;

                var followingPages = update.GetRange(i + 1, update.Count - (i + 1));
                var ruleContainsAllFollowers = followingPages.All(f => subsequentPages.Contains(f));

                if (!ruleContainsAllFollowers)
                    return false;
            }

            return true;
        }

        private int GetMiddlePage(List<int> pageUpdates)
        {
            if (pageUpdates.Count % 2 == 0)
                return 0;

            var index = Convert.ToInt32(Math.Floor(pageUpdates.Count / 2m));

            return pageUpdates[index];
        }
    }
}
