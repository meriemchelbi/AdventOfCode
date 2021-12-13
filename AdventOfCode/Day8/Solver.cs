using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day8
{
    public class Solver
    {
        public int SolvePart1(List<string[]> input)
        {
            var uniqueSegmentNos = 0;

            foreach (var output in input)
            {
                foreach (var signal in output)
                {
                    if (signal.Length == 2 || signal.Length == 4 || signal.Length == 3 || signal.Length == 7)
                        uniqueSegmentNos++;
                }
            }

            return uniqueSegmentNos;
        }

        public int SolvePart2(List<(string[], string[])> input)
        {
            var result = 0;

            foreach (var signal in input)
            {
                var patterns = signal.Item1;

                Dictionary<string, string> signalPatterns = GetSignalPatterns(patterns);

                var sb = new StringBuilder();

                foreach (var output in signal.Item2)
                {
                    var ordered = String.Concat(output.OrderBy(o => o));
                    sb.Append(signalPatterns[ordered]);
                }

                result += int.Parse(sb.ToString());
                sb.Clear();
            }
            
            return result;
        }

        private Dictionary<string, string> GetSignalPatterns(string[] patterns)
        {
            var signalPatterns = new Dictionary<string, string>();

            var one = String.Concat(patterns.FirstOrDefault(p => p.Length == 2).OrderBy(p => p));
            signalPatterns.Add(one, "1"); // done

            var four = String.Concat(patterns.FirstOrDefault(p => p.Length == 4).OrderBy(p => p));
            signalPatterns.Add(four, "4"); // done

            var seven = String.Concat(patterns.FirstOrDefault(p => p.Length == 3).OrderBy(p => p));
            signalPatterns.Add(seven, "7"); // done

            var eight = String.Concat(patterns.FirstOrDefault(p => p.Length == 7).OrderBy(p => p));
            signalPatterns.Add(eight, "8"); // done

            var sortedPatterns = patterns.Select(p => p.OrderBy(l => l)).ToList();
            var oneDifferent = sortedPatterns.Where(p => eight.Except(p).Count() == 1).ToList();
            var twoDifferent = sortedPatterns.Where(p => eight.Except(p).Count() == 2).ToList();

            var six = String.Concat(oneDifferent.First(c => c.Intersect(one).Count() == 1));
            signalPatterns.Add(six, "6");

            var intersect = twoDifferent.Where(p => p.Except(six).Count() == 1)
                                        .First(p => p.Intersect(one).Count() == 1);
            return signalPatterns;
        }

    }
}
