using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day1
{
    class InputParser
    {
        public List<int> Parse()
        {
            List<int> output = new();

            var path = Path.GetFullPath("Day1\\Input.txt");

            using (var sr = new StreamReader(path))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    var number = int.Parse(line);
                    output.Add(number);
                }
            }

            return output;
        }
    }
}
