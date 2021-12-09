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

            //var zero = eight.Substring(0, 5) + eight[^1];
            //signalPatterns.Add(zero, "0");

            //var two = eight[0] + eight.Substring(2, 2) + eight.Substring(5, 2);
            //signalPatterns.Add(two, "2");
            
            //var three = eight.Substring(0, 4)+ eight[5];
            //signalPatterns.Add(three, "3");
            
            //var five = eight.Substring(1, 5);
            //signalPatterns.Add(five, "5");
            
            var six = patterns.Where(p => (p + eight).Distinct().Count() == 1 && (p + one).Distinct().Count() == 1).ToString();
            signalPatterns.Add(six, "6"); // done
            
            //var nine = eight.Substring(0, 6);
            //signalPatterns.Add(nine, "9");

            return signalPatterns;
        }

    }
}
