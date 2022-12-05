using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day_2
{
    public class D2Solver
    {
        
        public int SolvePart1Alternative(List<string> strategy)
        {
            var totalScore = 0;
            var roundCount = new Dictionary<string, int>();

            foreach (var round in strategy)
            {
                if (!roundCount.TryAdd(round, 1))
                {
                    roundCount[round]++;
                }

            }
            
            foreach (var round in roundCount)
            {
                totalScore += GetScore(round.Key) * round.Value;
            }

            return totalScore;
        }

        private int GetScore(string round)
        {
            var opponentMove = round[0];
            var myMove = round[1];

            var opponentChoice = MatchMove(opponentMove);
            var myChoice = MatchMove(myMove);

            var roundScore = RoundOutcome((opponentChoice, myChoice));

            return roundScore + myChoice;
        }

        private int MatchMove(char move)
        {
            switch (move)
            {
                // Rock
                case 'A':
                case 'X':
                    return 1;

                // Paper
                case 'B':
                case 'Y':
                    return 2;

                // Scissors
                case 'C':
                case 'Z':
                    return 3;

                default:
                    return 1000000;
            }
        }

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
    }
}
