using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day1
{
    public class D1Parser
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
                    if (line.Length != 0)
                    {
                        output.Add(line);
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
