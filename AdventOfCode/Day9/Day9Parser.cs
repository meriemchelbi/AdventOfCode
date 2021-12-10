using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day9
{
    public class Day9Parser
    {
        public int[][] Parse(string inputPath)
        {
            var absolutePath = Path.GetFullPath(inputPath);
            var inputList = new List<int[]>();

            using (var sr = new StreamReader(absolutePath))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    var row = line.Select(r => int.Parse(r.ToString())).ToArray();
                    inputList.Add(row);
                }
            }

            return inputList.ToArray();
        }
    }
}
