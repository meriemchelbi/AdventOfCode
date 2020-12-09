using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day9
{
    class InputParser
    {
        public List<long> Parse()
        {
            var output = new List<long>();
            var path = Path.GetFullPath("Day9\\Input.txt");

            using (var sr = new StreamReader(path))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    var num = long.Parse(line);
                    output.Add(num);
                }
            }

            return output;
        }
    }
}
