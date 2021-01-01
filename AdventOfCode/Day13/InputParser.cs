using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day13
{
    class InputParser
    {
        public List<string> Parse(string fileName)
        {
            var output = new List<string>();
            var path = Path.GetFullPath($"Day13\\{fileName}.txt");

            using (var sr = new StreamReader(path))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    output.Add(line);
                }
            }

            return output;
        }
    }
}
