using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day_5
{
    public class Day5Solver
    {
        public string SolvePart1(Input input)
        {
            var instructions = input.MoveInstructions;

            foreach (var instruction in instructions)
            {
                var stackToPop = instruction.OriginStack.ToString();
                var stackToPush = instruction.DestinationStack.ToString();

                for (int i = 0; i < instruction.NumberToMove; i++)
                {
                    var topValue = input.Stacks[stackToPop].Pop();
                    input.Stacks[stackToPush].Push(topValue);
                }
            }

            return GetTopCrates(input.Stacks);
        }

        public string SolvePart2(Input input)
        {
            var instructions = input.MoveInstructions;

            foreach (var instruction in instructions)
            {
                var stackToPop = instruction.OriginStack.ToString();
                var stackToPush = instruction.DestinationStack.ToString();

                var valuesToPush = new List<string>();

                for (int i = 0; i < instruction.NumberToMove; i++)
                {
                    var topValue = input.Stacks[stackToPop].Pop();
                    valuesToPush.Add(topValue);
                }

                valuesToPush.Reverse();
                foreach (var value in valuesToPush)
                {
                    input.Stacks[stackToPush].Push(value);
                }
            }

            return GetTopCrates(input.Stacks);
        }

        private string GetTopCrates(Dictionary<string, Stack<string>> stacks)
        {
            var topCrates = new List<string>();

            foreach (var stack in stacks)
            {
                var stackValues = stack.Value;
                var topCrate = stackValues.Pop();
                topCrates.Add(topCrate);
            }

            return topCrates.Aggregate((i, j) => i + j).ToString();
        }
    }
}
