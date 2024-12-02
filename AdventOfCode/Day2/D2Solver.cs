using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace AdventOfCode.Day2
{
    public class D2Solver
    {
        public int SolvePart1(List<List<int>> input)
        {
            var safeReportCount = 0;

            foreach (var report in input)
            {
                if (IsSafeReport(report))
                    safeReportCount++;
            }

            return safeReportCount;
        }


        public int SolvePart2(List<List<int>> input)
        {
            var safeReportCount = 0;

            foreach (var report in input)
            {
                if (IsSafeReportWithDampener(report))
                    safeReportCount++;
            }

            return safeReportCount;
        }

        private bool IsSafeReportWithDampener(List<int> report)
        {
            for (int i = 0; i < report.Count; i++)
            {
                var clonedReportArray = new int[report.Count];
                report.CopyTo(clonedReportArray);
                var clonedReport = clonedReportArray.ToList();

                clonedReport.RemoveAt(i);

                if (IsSafeReport(clonedReport))
                {
                    return true;
                };
            }

            return false;
        }
        private bool IsSafeReport(List<int> report)
        {
            var isIncreasing = false;
            var lastIncrement = 0;
            var isSafe = true;

            for (int i = 0; i < report.Count - 1; i++)
            {
                var currentIncrement = report[i + 1] - report[i];
                var incrementSign = Math.Sign(currentIncrement);

                if (Math.Abs(currentIncrement) > 3 || incrementSign == 0)
                {
                    isSafe = false;
                    break;
                }

                if (i == 0)
                {
                    if (incrementSign > 0)
                        isIncreasing = true;
                    lastIncrement = currentIncrement;
                    continue;
                }

                if (incrementSign < 0 && isIncreasing)
                {
                    isSafe = false;
                    break;
                }

                if (incrementSign > 0 && !isIncreasing)
                {
                    isSafe = false;
                    break;
                }

                lastIncrement = currentIncrement;
            }

            return isSafe;
        }
    }
}

