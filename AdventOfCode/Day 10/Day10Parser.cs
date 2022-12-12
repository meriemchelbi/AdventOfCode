using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day_10
{
    public class Day10Parser
    {
        public List<(string, int)> Parse(string inputPath)
        {
            var output = new List<(string, int)>();

            var absolutePath = Path.GetFullPath(inputPath);

            using (var sr = new StreamReader(absolutePath))
            {
                string line;
                
                while ((line = sr.ReadLine()) != null)
                {
                    var instructions = line.Split(' ');
                    var command = instructions[0].ToString();
                    var v = command != "noop" ? int.Parse(instructions[1].ToString()) : 0;

                    output.Add((command, v));
                }
            }

            return output;
        }
    }
}
