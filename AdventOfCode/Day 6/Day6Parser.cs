using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day_6
{
    public class Day6Parser
    {
        public string Parse(string inputPath)
        {
            var absolutePath = Path.GetFullPath(inputPath);
            string input;
            
            using (var sr = new StreamReader(absolutePath))
            {
                input = sr.ReadLine();
            }

            return input;
        }
    }
}
