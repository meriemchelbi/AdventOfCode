using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day10
{
    public class Solver
    {
        private readonly Dictionary<char, char> _openingClosing;
        private readonly Dictionary<char, int> _charScores;

        public Solver()
        {
            _openingClosing = new Dictionary<char, char>
            {
                { '{', '}' },
                { '(', ')' },
                { '[', ']' },
                { '<', '>' }
            };
            _charScores = new Dictionary<char, int>
            {
                { ')', 3 },
                { ']', 57 },
                { '}', 1197 },
                { '>', 25137 }
            };
        }

        public int SolvePart1(List<string> input)
        {
            var illegalChars = input.Select(i => GetFirstIllegalChar(i))
                                    .Where(i => i != default)
                                    .GroupBy(i => i)
                                    .ToDictionary(g => g.Key, g => g.Count());

            var totalSyntaxErrorScore = 0;

            foreach (var illegalCount in illegalChars)
            {
                var charScore = _charScores[illegalCount.Key];
                var score = charScore * illegalCount.Value;
                totalSyntaxErrorScore += score;
            }

            return totalSyntaxErrorScore;
        }

        public int SolvePart2(List<string> input)
        {
            // get incomplete lines
            var incomplete = input.Where(i => GetFirstIllegalChar(i) == default).ToList();
            return 0;
        }

        public char GetFirstIllegalChar(string line)
        {
            var openingChunk = new List<char>();

            for (int i = 0; i < line.Length; i++)
            {
                var character = line[i];
                if (IsOpening(character))
                    openingChunk.Add(character);

                if (IsClosing(character))
                {
                    var lastOpeningChar = openingChunk[^1];
                    
                    if (character != _openingClosing[lastOpeningChar])
                        return character;
                
                    openingChunk.RemoveAt(openingChunk.Count - 1);
                }
            }

            return default;
        }

        private bool IsOpening(char character)
        {
            return _openingClosing.Any(c => c.Key.Equals(character));
        }
        
        private bool IsClosing(char character)
        {
            return _openingClosing.Any(c => c.Value.Equals(character));
        }
    }
}
