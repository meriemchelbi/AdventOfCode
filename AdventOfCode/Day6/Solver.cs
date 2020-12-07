using System.Linq;
using System.Text;

namespace AdventOfCode.Day6
{
    class Solver
    {
        internal int Solve()
        {
            var parser = new InputParser();
            var input = parser.ParseGroups();

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
            var input = parser.ParseIndividuals();

            var deduped = input.Select(i => YesByAll(i));

            var scores = deduped.Select(d => CalculateAnswerScore(d));

            return scores.Sum();
        }

        internal string YesByAll(string[] groupResponses)
        {
            var first = groupResponses[0];
            var commonResponses = new StringBuilder();

            foreach (var item in first)
            {
                if (groupResponses.All(g => g.Contains(item)))
                    commonResponses.Append(item);
            }

            return commonResponses.ToString();
        }
    }
}
