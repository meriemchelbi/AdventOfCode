using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day_9
{
    public class Day9Parser
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
                    var direction = instructions[0].ToString();
                    var distance = int.Parse(instructions[1].ToString());

                    output.Add((direction, distance));
                }
            }

            return output;
        }
    }
}
