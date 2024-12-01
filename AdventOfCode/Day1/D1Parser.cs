using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day1
{
    public class D1Parser
    {
        public Locations Parse(string inputPath)
        {
            var output = new Locations();

            var absolutePath = Path.GetFullPath(inputPath);

            using (var sr = new StreamReader(absolutePath))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    var numbers = line.Split("   ");
                    output.LeftList.Add(int.Parse(numbers[0]));
                    output.RightList.Add(int.Parse(numbers[1]));
                }
            }

            return output;
        }
    }
}
