using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day7
{
    public class D7Parser
    {
        public List<int> Parse(string inputPath)
        {
            var output = new List<int>();

            var absolutePath = Path.GetFullPath(inputPath);

            using (var sr = new StreamReader(absolutePath))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Length != 0)
                    {
                        var number = int.Parse(line);
                        output.Add(number);
                    }
                    else
                    {
                        // do a thing 
                    }
                }

                // do the thing one last time
            }

            return output;
        }
    }
}
