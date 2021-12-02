using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.InputParsers
{
    public class ToTupleParser
    {
        public List<(char, int)> ParseToTuple(string inputPath)
        {
            var output = new List<(char, int)>();

            var absolutePath = Path.GetFullPath(inputPath);

            using (var sr = new StreamReader(absolutePath))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    var split = line.Split(' ');
                    var tuple = (split[0][0], int.Parse(split[1]));
                    output.Add(tuple);
                }
            }

            return output;
        }
    }
}
