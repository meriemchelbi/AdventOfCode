using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode.Day8
{
    class InputParser
    {
        public List<Instruction> Parse()
        {
            var output = new List<Instruction>();
            var path = Path.GetFullPath("Day8\\Input.txt");

            using (var sr = new StreamReader(path))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    var split = line.Split(' ');
                    var operation = split[0];
                    var argument = int.Parse(split[1]);
                    var instruction = new Instruction
                    {
                        Argument = argument,
                        Operation = operation
                    };

                    output.Add(instruction);
                }
            }

            return output;
        }
    }
}
