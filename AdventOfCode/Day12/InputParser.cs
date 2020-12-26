using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day12
{
    class InputParser
    {
        public List<Instruction> Parse(string fileName)
        {
            var output = new List<Instruction>();
            var path = Path.GetFullPath($"Day12\\{fileName}.txt");

            using (var sr = new StreamReader(path))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    output.Add(new Instruction(line));
                }
            }

            return output;
        }
    }
}
