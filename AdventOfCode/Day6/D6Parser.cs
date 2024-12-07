using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day6
{
    public class D6Parser
    {
        public List<string> Parse(string inputPath)
        {
            var output = new List<string>();

            var absolutePath = Path.GetFullPath(inputPath);

            using (var sr = new StreamReader(absolutePath))
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
