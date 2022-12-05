using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day_3
{
    public class Solver
    {
        public int SolvePart1(List<string> input)
        {
            var sumOfPriorities = 0;
            
            foreach (var rucksack in input)
            {
                var compartmentContents = GetCompartmentContents(rucksack);
                var commonItem = compartmentContents.FirstOrDefault().Intersect(compartmentContents.LastOrDefault());
                var priority = GetItemPriority(commonItem.FirstOrDefault());
                sumOfPriorities += priority;
            }
            
            return sumOfPriorities;
        }
        public int SolvePart2(List<string> input)
        {
            var sumOfPriorities = 0;

            for (var i = 0; i < input.Count; i+= 3)
            {
                var groupElves = input.Take(new Range(i, i + 3)).ToList();
                var commonItems1 = groupElves[0].Intersect(groupElves[1]);
                var commonItems2 = commonItems1.Intersect(groupElves[2]);
                var priority = GetItemPriority(commonItems2.FirstOrDefault());
                sumOfPriorities += priority;
            }

            return sumOfPriorities;
        }

        private List<string> GetCompartmentContents(string rucksack)
        {
            var compartmentItems = rucksack.Length/2;
            return new List<string>
            {
                rucksack.Substring(0, compartmentItems),
                rucksack.Substring(compartmentItems, compartmentItems)
            };
        }

        private int GetItemPriority(char item)
        {
            var alphabet = "0abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            return alphabet.IndexOf(item);
        }

    }
}
