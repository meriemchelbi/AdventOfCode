using FluentAssertions.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day3
{
    public class D3Parser
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
                    var validInstructions = Regex.Matches(line, "mul\\([0-9]+,[0-9]+\\)").ToList();
                    var parsedInstructions = validInstructions.Select(i => GetInstructionTuple(i));
                    output.AddRange(parsedInstructions);
                }
            }

            return output;
        }

        internal List<(int, int)> ParseComplex(string path)
        {
            var output = new List<(int, int)>();

            var absolutePath = Path.GetFullPath(path);

            using (var sr = new StreamReader(absolutePath))
            {
                string line;
                var sb = new StringBuilder();

                while ((line = sr.ReadLine()) != null)
                {
                    sb.Append(line);
                }

                var program = sb.ToString();

                var validInstructionsString = Regex.Replace(program, "don't\\(\\)(?s).*?(do\\(\\)|$(?![\r\n]))", "");
                var validInstructions = Regex.Matches(validInstructionsString, "mul\\([0-9]+,[0-9]+\\)").ToList();
                var parsedInstructions = validInstructions.Select(i => GetInstructionTuple(i));
                
                output.AddRange(parsedInstructions);
            }

            return output;
        }

        private (int, int) GetInstructionTuple(Match instructionMatch)
        {
            var trimmedStart = instructionMatch.Value.Remove(0, 4);
            var trimmedEnd = trimmedStart.Substring(0, trimmedStart.Length - 1);
            var numbers = trimmedEnd.Split(',').Select(s => int.Parse(s)).ToList();
            
            return (numbers[0], numbers[1]);
        }
    }
}
