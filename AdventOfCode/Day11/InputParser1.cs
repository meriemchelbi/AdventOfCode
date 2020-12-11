using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day11
{
    class InputParser
    {
        public List<int> Parse(string fileName)
        {
            var output = new List<int>();
            var path = Path.GetFullPath($"Day10\\{fileName}.txt");

            using (var sr = new StreamReader(path))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    var num = int.Parse(line);
                    output.Add(num);
                }
            }

            return output;
        }
    }
}
