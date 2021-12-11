using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day10
{
    public class Solver
    {
        private readonly Dictionary<char, char> _openingClosing;
        private readonly Dictionary<char, int> _charIllegalScores;
        private readonly Dictionary<char, int> _charIncompleteScores;

        public Solver()
        {
            _openingClosing = new Dictionary<char, char>
            {
                { '{', '}' },
                { '(', ')' },
                { '[', ']' },
                { '<', '>' }
            };
            _charIllegalScores = new Dictionary<char, int>
            {
                { ')', 3 },
                { ']', 57 },
                { '}', 1197 },
                { '>', 25137 }
            };
            _charIncompleteScores = new Dictionary<char, int>
            {
                { ')', 1 },
                { ']', 2 },
                { '}', 3 },
                { '>', 4 }
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
                var charScore = _charIllegalScores[illegalCount.Key];
                var score = charScore * illegalCount.Value;
                totalSyntaxErrorScore += score;
            }

            return totalSyntaxErrorScore;
        }

        public long SolvePart2(List<string> input)
        {
            var incomplete = input.Where(i => GetFirstIllegalChar(i) == default)
                                  .Select(i => CompleteLine(i)).ToList();

            var scores = new List<long>();

            foreach (var line in incomplete)
            {
                long score = 0;

                foreach (var character in line)
                {
                    score *= 5;
                    score += _charIncompleteScores[character];
                }

                scores.Add(score);
            }

            var sorted = scores.OrderBy(s => s).ToList();
            var middleIndex = scores.Count / 2;

            return sorted[middleIndex];
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

        public string CompleteLine(string line)
        {
            var openingChunk = new List<char>();
            var sb = new StringBuilder();

            for (int i = 0; i < line.Length; i++)
            {
                var character = line[i];
                if (IsOpening(character))
                    openingChunk.Add(character);

                if (IsClosing(character))
                {
                    var lastOpeningChar = openingChunk[^1];

                    if (character == _openingClosing[lastOpeningChar])
                        openingChunk.RemoveAt(openingChunk.Count - 1);
                }
            }

            openingChunk.Reverse();

            foreach (var character in openingChunk)
            {
                sb.Append(_openingClosing[character]);
            }

            return sb.ToString();
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
