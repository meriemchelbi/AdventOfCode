using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day_7
{
    public class Day7Parser
    {
        public List<string[]> Parse(string inputPath)
        {
            var absolutePath = Path.GetFullPath(inputPath);
            var output = new List<string[]>();

            using (var sr = new StreamReader(absolutePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var commands = line.Split(' ');
                    output.Add(commands);
                }
            }

            return output;
        }
    }
}
