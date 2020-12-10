using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day10
{
    class InputParser
    {
        public List<int> Parse()
        {
            var output = new List<int>();
            var path = Path.GetFullPath("Day10\\Input.txt");

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
