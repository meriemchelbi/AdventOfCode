using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace AdventOfCode.Day1
{
    class InputParser
    {
        public List<int> Parse()
        {
            List<int> output = new();

            var path = "C:\\Users\\meriemc\\Documents\\GitHub\\AdventOfCode\\AdventOfCode\\Day1\\Input.txt";

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
