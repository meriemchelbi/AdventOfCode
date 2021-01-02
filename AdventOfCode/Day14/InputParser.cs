using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day14
{
    class InputParser
    {
        public List<char[]> Parse()
        {
            var output = new List<char[]>();
            var path = Path.GetFullPath("Day14\\Input.txt");

            using (var sr = new StreamReader(path))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    output.Add(line.ToCharArray());
                }
            }

            return output;
        }
    }
}
