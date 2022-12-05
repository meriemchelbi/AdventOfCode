using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day_3
{
    public class Parser
    {
        public List<(int, int)> Parse(string inputPath)
        {
            var output = new List<(int, int)>();

            var absolutePath = Path.GetFullPath(inputPath);

            using (var sr = new StreamReader(absolutePath))
            {
                string line;
                
                while ((line = sr.ReadLine()) != null)
                {
                    var strategy = line.Split(' ');
                    var intMoves = new List<int>();

                    foreach (var move in strategy)
                    {
                        intMoves.Add(MatchMove(move));
                    }
                    
                    //var intMoves = strategy.Select(MatchMove);

                    // Validation
                    if (intMoves.Any(m => m > 3))
                    {
                        throw new Exception("bad data found!");
                    }

                    var moves = (intMoves[0] , intMoves[1]);
                    
                    output.Add(moves);
                }
            }

            return output;
        }

        private int MatchMove(string move)
        {
            switch (move)
            {
                // Rock
                case "A":
                case "X": 
                    return 1;
                
                // Paper
                case "B":
                case "Y": 
                    return 2;
                
                // Scissors
                case "C":
                case "Z": 
                    return 3;
                
                default:
                    return 1000000;
            }
        }
    }
}
