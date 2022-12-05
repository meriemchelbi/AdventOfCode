using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day_4
{
    public class Day4Parser
    {
        public List<(int[], int[])> Parse(string inputPath)
        {
            var output = new List<(int[], int[])>();

            var absolutePath = Path.GetFullPath(inputPath);

            using (var sr = new StreamReader(absolutePath))
            {
                string line;
                
                while ((line = sr.ReadLine()) != null)
                {
                    var assignments = line.Split(',');
                    var expanded = assignments.Select(ExpandAssignment);
                    output.Add((expanded.First(), expanded.Last()));
                }
            }

            return output;
        }

        private int[] ExpandAssignment(string assigment)
        {
            var assignmentRange = assigment.Split('-');
            var rangeStart = int.Parse(assignmentRange.First().ToString());
            var rangeEnd = int.Parse(assignmentRange.Last().ToString());

            var rangeLength = rangeEnd - rangeStart + 1;
            var range = Enumerable.Range(rangeStart, rangeLength).ToArray();
            
            return range;   
        }
    }
}
