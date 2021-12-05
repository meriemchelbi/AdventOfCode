﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
                    var newLine = new Line
                    {
                        Start = (int.Parse(line[0].ToString()), int.Parse(line[2].ToString())),
                        End = (int.Parse(line[^3].ToString()), int.Parse(line[^1].ToString()))
                    };

                    CalculateLineProperties(newLine);

                    lines.Add(newLine);
                }
            }

            return lines;
        }

        public void CalculateLineProperties(Line line)
        {
            if (line.Start.Item1 == line.End.Item1)
            {
                line.IsHorizontalOrVertical = true;
                
                var pointsRange = line.Start.Item2 - line.End.Item2;
                var upwards = pointsRange > 0 ? false : true;
                
                for (int i = 0; i < Math.Abs(pointsRange) + 1; i++)
                {
                    (int, int) point;

                    if (upwards)
                        point = (line.Start.Item1, line.Start.Item2 + i);
                    else
                        point = (line.Start.Item1, line.Start.Item2 - i);

                    line.Points.Add(point);
                }
            }

            if (line.Start.Item2 == line.End.Item2)
            {
                line.IsHorizontalOrVertical = true;
                
                var pointsRange = line.Start.Item1 - line.End.Item1;
                var leftwards = pointsRange > 0 ? true : false;

                for (int i = 0; i < Math.Abs(pointsRange) + 1; i++)
                {
                    (int, int) point;

                    if (leftwards)
                        point = (line.Start.Item1 - i, line.Start.Item2);
                    else
                        point = (line.Start.Item1 + 1, line.Start.Item2);

                    line.Points.Add(point);
                }
            }
        }
    }
}