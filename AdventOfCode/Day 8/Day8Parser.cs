﻿using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day_8
{
    public class Day8Parser
    {
        public List<string> Parse(string inputPath)
        {
            var absolutePath = Path.GetFullPath(inputPath);
            var output = new List<string>();
            
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
