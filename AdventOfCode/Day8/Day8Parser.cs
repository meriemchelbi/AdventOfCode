using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode.Day8
{
    public class Day8Parser
    {
        public List<string[]> ParsePart1(string inputPath)
        {
            var input = new List<string[]>();

            var absolutePath = Path.GetFullPath(inputPath);

            using (var sr = new StreamReader(absolutePath))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    var split = line.Split('|');
                    var output = split[^1].TrimStart();
                    input.Add(output.Split(' '));
                }
            }

            return input;
        }
    }
}
