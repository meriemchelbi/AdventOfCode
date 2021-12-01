using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.InputParsers
{
    public class ToListParser
    {
        public List<int> ParseToListOfInt(string inputPath)
        {
            var output = new List<int>();

            var absolutePath = Path.GetFullPath(inputPath);

            using (var sr = new StreamReader(absolutePath))
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
