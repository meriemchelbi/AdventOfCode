using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day_5
{
    public class Day5Parser
    {
        public Input Parse(string inputPath)
        {
            var absolutePath = Path.GetFullPath(inputPath);
            var stacksLines = new List<string>();
            var instructionsLines = new List<string>();

            using (var sr = new StreamReader(absolutePath))
            {
                string line;
                
                while ((line = sr.ReadLine()).Length > 1)
                {
                    stacksLines.Add(line);
                }
                
                while ((line = sr.ReadLine()) != null)
                {
                    instructionsLines.Add(line);
                }
            }
                // create dictionary with correct number of stacks

            return new Input
            {
                Stacks = GetStacks(stacksLines),
                MoveInstructions = GetMoveInstructions(instructionsLines)
            };
        }

        private Dictionary<string, Stack<string>> GetStacks(List<string> stacksLines)
        {
            var stacks = stacksLines.Last().Where(c => !Char.IsWhiteSpace(c))
                                        //.Select(i => int.Parse(i.ToString()))
                                        .Select(i => i.ToString())
                                        .ToDictionary(i => i, i => new Stack<string>());

            stacksLines.RemoveAt(stacksLines.Count - 1);

            var linePosition = 0;
            var lineLength = stacksLines.First().Length;

            for (int i = 1; i < stacks.Count + 1; i++)
            {
                var stackList = new List<string>();

                foreach (var line in stacksLines)
                {
                    var crate = line.Substring(linePosition, 3);
                    if (crate.Contains('['))
                    {
                        var value = crate.Where(c => !c.Equals('[') & !c.Equals(']')).First().ToString();
                        stackList.Add(value);
                    }
                }

                stackList.Reverse();
                stacks[i.ToString()] = new Stack<string>(stackList);

                linePosition += 3;
                if (lineLength > linePosition)
                    linePosition++;
                else
                    continue;
            }

            return stacks;
        }
        
        private List<MoveInstruction> GetMoveInstructions(List<string> instructionsLines)
        {
            var moveInstructions = new List<MoveInstruction>();

            foreach (var line in instructionsLines)
            {
                var instruction = new List<string>();
                var sb = new StringBuilder();

                for (int i = 5; i < line.Length; i++)
                {
                    string currentCharacter = line[i].ToString();
                    var isDigit = int.TryParse(currentCharacter, out var value);
                    if (isDigit)
                    {
                        sb.Append(currentCharacter);
                    }
                    if (sb.Length > 0 && !isDigit
                        || i == line.Length - 1)
                    {
                        instruction.Add(sb.ToString());
                        sb.Clear();
                    }
                }
                var moveInstruction = new MoveInstruction
                {
                    NumberToMove = int.Parse(instruction[0]),
                    OriginStack = int.Parse(instruction[1]),
                    DestinationStack = int.Parse(instruction[2])
                };
                moveInstructions.Add(moveInstruction);
            }

            return moveInstructions;
        }
    }
}
