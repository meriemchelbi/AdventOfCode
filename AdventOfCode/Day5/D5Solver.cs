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
            // get rules for each page in update
            var relevantRules = _orderedRules.Where(r => update.Contains(r.Key)).ToList();

            // remove pages from values which aren't in update
            var filteredRules = relevantRules.ToDictionary(r => r.Key, r => r.Value.Intersect(update).ToList());

            // order based on number of elements in value 
            var orderedFilteredRules = filteredRules.OrderByDescending(r => r.Value.Count).ToDictionary();
            
            var knownPages = orderedFilteredRules.Select(r => r.Key).ToList();

            var orderedUnknown = update.Except(knownPages).ToList();

            if (orderedUnknown.Count == 0)
            {
                return knownPages;
            }

            foreach (var item in orderedUnknown)
            {
                var precedingItems = relevantRules.Where(r => r.Value.Contains(item))
                                         .Select(r => r.Key).ToList();

                var highestPrecedingItemIndex = precedingItems.Max(p => knownPages.IndexOf(p));

                knownPages.Insert(highestPrecedingItemIndex + 1, item);
            }

            return knownPages;
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
