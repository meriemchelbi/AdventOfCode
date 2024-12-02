using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day2
{
    public class D2Parser
    {
        public List<List<int>> Parse(string inputPath)
        {
            var output = new List<List<int>>();

            var absolutePath = Path.GetFullPath(inputPath);

            using (var sr = new StreamReader(absolutePath))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    var lineArray = line.Split(' ');
                    var intList = lineArray.Select(s => int.Parse(s)).ToList();

                    output.Add(intList);
                }
            }

            return output;
        }
    }
}
