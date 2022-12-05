using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day_2
{
    public class D2Solver
    {
        
        public int SolvePart1(List<(int, int)> strategy)
        {
            var totalScore = 0;

            foreach (var round in strategy)
            {
                var outcomeScore = RoundOutcome(round);
                var score =  outcomeScore + round.Item2;
                totalScore += score;
            }

            //var roundCount = new Dictionary<(int, int), int>();

            //foreach (var round in strategy)
            //{
            //    if (!roundCount.TryAdd(round, 1))
            //    {
            //        roundCount[round]++;
            //    }
            //}

            //foreach (var round in roundCount)
            //{
            //    var score = RoundOutcome(round.Key) + round.Key.Item2;
            //    totalScore += score * round.Value;
            //}

            return totalScore;
        }

        public int SolvePart2(List<(int, int)> strategy)
        {
            var totalScore = 0;

            foreach (var round in strategy)
            {
                var outcomeScore = GuessOutcome(round);
                totalScore += outcomeScore;
            }

            return totalScore;
        }
        
        private int RoundOutcome((int, int) strategy)
        {
            var scores = new Dictionary<(int, int), int>
            {
                { (1, 1), 3 },
                { (2, 2), 3 },
                { (3, 3), 3 },
                { (1, 2), 6 },
                { (1, 3), 0 },
                { (2, 1), 0 },
                { (2, 3), 6 },
                { (3, 1), 6 },
                { (3, 2), 0 },
            };
            
            return scores[strategy];
        }

        private int GuessOutcome((int, int) strategy)
        {
            var scores = new Dictionary<(int, int), int>
            {
                { (1, 1), 0 + 3 },
                { (2, 1), 0 + 1 },
                { (3, 1), 0 + 2 },
                { (1, 2), 3 + 1 },
                { (2, 2), 3 + 2 },
                { (3, 2), 3 + 3 },
                { (1, 3), 6 + 2 },
                { (2, 3), 6 + 3 },
                { (3, 3), 6 + 1 },
            };

            return scores[strategy];
        }
    }
}
