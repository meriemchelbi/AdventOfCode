using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day6
{
    class Solver
    {
        internal int Solve()
        {
            var parser = new InputParser();
            var input = parser.Parse();

            var deduped = input.Select(i => DeduplicateGroupAnswers(i));

            var scores = deduped.Select(d => CalculateAnswerScore(d));

            return scores.Sum();
        }

        internal string DeduplicateGroupAnswers(string groupAnswers)
        {
            return new string(groupAnswers.Distinct().ToArray());
        }

        internal int CalculateAnswerScore(string answer)
        {
            return answer.Length;
        }

        internal int Solve2()
        {
            var parser = new InputParser();
            var input = parser.Parse();

            return 0;
        }
    }
}
