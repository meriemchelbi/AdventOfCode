using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day5
{
    public class Solver
    {
        public int SolvePart1(List<Line> input)
        {
            var pointsCount = new Dictionary<(int, int), int>();

            foreach (var line in input)
            {
                if (!line.IsVertical && !line.IsHorizontal)
                    continue;

                if (line.IsHorizontal)
                    CalculateHorizontalPoints(line);

                if (line.IsVertical)
                    CalculateVerticalPoints(line);

                foreach (var point in line.Points)
                {
                    var success = pointsCount.TryAdd(point, 1);

                    if (!success)
                        pointsCount[point] += 1;
                }
            }

            return pointsCount.Where(p => p.Value >= 2).Count();
        }

        public int SolvePart2(List<Line> input)
        {
            var pointsCount = new Dictionary<(int, int), int>();

            foreach (var line in input)
            {
                if (!line.IsVertical && !line.IsHorizontal && !line.IsDownwardDiagonal && !line.IsUpwardDiagonal)
                    continue;

                if (line.IsHorizontal)
                    CalculateHorizontalPoints(line);

                else if (line.IsVertical)
                    CalculateVerticalPoints(line);

                else if (line.IsUpwardDiagonal)
                    CalculateUpwardDiagonalPoints(line);

                else if (line.IsDownwardDiagonal)
                    CalculateDownwardDiagonalPoints(line);

                foreach (var point in line.Points)
                {
                    var success = pointsCount.TryAdd(point, 1);

                    if (!success)
                        pointsCount[point] += 1;
                }
            }

            return pointsCount.Where(p => p.Value >= 2).Count();
        }

        private static void CalculateVerticalPoints(Line line)
        {
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

        private static void CalculateHorizontalPoints(Line line)
        {
            var pointsRange = line.Start.Item1 - line.End.Item1;
            var leftwards = pointsRange > 0 ? true : false;

            for (int i = 0; i < Math.Abs(pointsRange) + 1; i++)
            {
                (int, int) point;

                if (leftwards)
                    point = (line.Start.Item1 - i, line.Start.Item2);
                else
                    point = (line.Start.Item1 + i, line.Start.Item2);

                line.Points.Add(point);
            }
        }

        private void CalculateDownwardDiagonalPoints(Line line)
        {
            var pointsRange = line.Start.Item1 - line.End.Item1;
            var leftwards = pointsRange > 0 ? true : false;

            for (int i = 0; i < Math.Abs(pointsRange) + 1; i++)
            {
                (int, int) point;

                if (leftwards)
                    point = (line.Start.Item1 - i, line.Start.Item2 + i);
                else
                    point = (line.Start.Item1 + i, line.Start.Item2 - i);

                line.Points.Add(point);
            }
        }

        private void CalculateUpwardDiagonalPoints(Line line)
        {
            var pointsRange = line.Start.Item2 - line.End.Item2;
            var upwards = pointsRange > 0 ? false : true;

            for (int i = 0; i < Math.Abs(pointsRange) + 1; i++)
            {
                (int, int) point;

                if (upwards)
                    point = (line.Start.Item1 + i, line.Start.Item2 + i);
                else
                    point = (line.Start.Item1 - i , line.Start.Item2 - i);

                line.Points.Add(point);
            }
        }
    }
}
