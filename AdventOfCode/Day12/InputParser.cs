using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day12
{
    class InputParser
    {
        public List<char[]> Parse(string fileName)
        {
            var output = new List<char[]>();
            var path = Path.GetFullPath($"Day11\\{fileName}.txt");

            using (var sr = new StreamReader(path))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    var row = line.ToCharArray();
                    output.Add(row);
                }
            }

            return output;
        }
    }
}
