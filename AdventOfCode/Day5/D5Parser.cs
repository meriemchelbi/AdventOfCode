using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day5
{
    public class D5Parser
    {
        public List<(int, int)> ParsePageOrderingRules(string inputPath)
        {
            var output = new List<(int, int)>();

            var absolutePath = Path.GetFullPath(inputPath);

            using (var sr = new StreamReader(absolutePath))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Length != 0)
                    {
                        var elements = line.Split('|');
                        var numbers = elements.Select(e => int.Parse(e)).ToList();
                        output.Add((numbers[0], numbers[1]));
                    }
                }
            }

            return output;
        }

        internal List<List<int>> ParsePageUpdates(string path)
        {
            var output = new List<List<int>>();

            var absolutePath = Path.GetFullPath(path);

            using (var sr = new StreamReader(absolutePath))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Length != 0)
                    {
                        var elements = line.Split(',');
                        var numbers = elements.Select(e => int.Parse(e)).ToList();
                        output.Add(numbers);
                    }
                }
            }

            return output;
        }
    }
}
