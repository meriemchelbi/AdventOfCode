using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day6
{
    class InputParser
    {
        public List<string> Parse()
        {
            var output = new List<string>();
            var path = Path.GetFullPath("Day5\\Input.txt");

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
