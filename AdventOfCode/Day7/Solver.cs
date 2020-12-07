using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day7
{
    class Solver
    {
        internal int Solve()
        {
            var parser = new InputParser();
            var input = parser.Parse();
            var colours = new List<string>();

            FindContainingColours(input, "shiny gold", colours);

            return colours.Distinct().Count();
        }

        internal void FindContainingColours(Dictionary<string, Dictionary<string, int>> input,
                                            string colour,
                                            List<string> colours)
        {
            var containColour = new List<string>();

            foreach (var entry in input)
            {
                if (entry.Value is null)
                    continue;

                var valueKeys = entry.Value.Keys;
                foreach (var key in valueKeys)
                {
                    if (key.Contains(colour))
                    {
                        containColour.Add(entry.Key);
                        colours.Add(entry.Key);
                    }
                }
            }

            foreach (var c in containColour)
            {
                FindContainingColours(input, c, colours);
            }
        }

        internal int Solve2()
        {
            var parser = new InputParser();
            var input = parser.Parse();

            return CountContainedBags(input, "shiny gold");
        }

        internal int CountContainedBags(Dictionary<string, Dictionary<string, int>> input, string colour)
        {
            var contained = input[colour];
            var total = 0;

            if (contained is null)
            {
                return 0;
            }

            foreach (var item in contained)
            {
                total += item.Value + (item.Value * CountContainedBags(input, item.Key));
            }

            return total;
        }
    }
}
