using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day5
{
    public class Day5Parser
    {
        public List<Line> ParseInput(string inputPath)
        {
            var absolutePath = Path.GetFullPath(inputPath);
            var lines = new List<Line>();

            using (var sr = new StreamReader(absolutePath))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    var split = line.Split(' ').ToList();
                    var coordinates = split.SelectMany(s => s.Split(',')).ToArray();
                    
                    var newLine = new Line
                    {
                        Start = (int.Parse(coordinates[0]), int.Parse(coordinates[1].ToString())),
                        End = (int.Parse(coordinates[^2].ToString()), int.Parse(coordinates[^1].ToString()))
                    };

                    if (newLine.Start.Item1 == newLine.End.Item1)
                    {
                        newLine.IsVertical = true;
                        lines.Add(newLine);
                    }

                    else if (newLine.Start.Item2 == newLine.End.Item2)
                    {
                        newLine.IsHorizontal = true;
                        lines.Add(newLine);
                    }

                    else
                    {
                        lines.Add(newLine);
                    }
                }
            }

            return lines;
        }
    }
}
