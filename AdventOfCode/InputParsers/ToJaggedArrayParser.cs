using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.InputParsers
{
    internal class ToJaggedArrayParser
    {
        public int[][] ParseToIntJagged(string inputPath)
        {
            var absolutePath = Path.GetFullPath(inputPath);
            var arrays = new List<int[]>();
            using (var sr = new StreamReader(absolutePath))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    var lineArray = line.Select(l => int.Parse(l.ToString())).ToArray();
                    arrays.Add(lineArray);
                }
            }

            return arrays.ToArray();
        }
    }
}
