using System.Collections.Generic;

namespace AdventOfCode.Day2
{
    public class Solver
    {
        public int SolvePart1(List<(char, int)> input)
        {
            var horizontal = 0;
            var depth = 0;

            foreach (var instruction in input)
            {
                switch (instruction.Item1)
                {
                    case 'f':
                        horizontal += instruction.Item2;
                        break;
                    case 'd':
                        depth += instruction.Item2;
                        break;
                    case 'u':
                        depth -= instruction.Item2;
                        break;
                    default:
                        break;
                }
            }

            return horizontal * depth;
        }

        public int SolvePart2(List<(char, int)> input)
        {
            var horizontal = 0;
            var depth = 0;
            var aim = 0;

            foreach (var instruction in input)
            {
                var magnitude = instruction.Item2;

                switch (instruction.Item1)
                {
                    case 'f':
                        horizontal += magnitude;
                        depth += aim * magnitude;
                        break;
                    case 'd':
                        aim += magnitude;
                        break;
                    case 'u':
                        aim -= magnitude;
                        break;
                    default:
                        break;
                }
            }

            return horizontal * depth;
        }
    }
}
