using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day8
{
    class Solver
    {
        internal int Solve()
        {
            var parser = new InputParser();
            var input = parser.Parse();

            var accumulator = RunProgramme(input, out var overflows);

            return accumulator;
        }

        internal int Solve2()
        {
            var parser = new InputParser();
            var input = parser.Parse();
            var accumulator = 0;
            
            for (int i = 0; i < input.Count; i++)
            {
                var previousValue = "acc";

                switch (input[i].Operation)
                {
                    case "jmp":
                        previousValue = "jmp";
                        input[i].Operation = "nop";
                        break;
                    case "nop":
                        previousValue = "nop";
                        input[i].Operation = "jmp";
                        break;
                    default:
                        break;
                }

                accumulator = RunProgramme(input, out var overflows);

                if (!overflows)
                    break;

                else
                {
                    input[i].Operation = previousValue;
                    input.ForEach(i => i.IsExhausted = false);
                }
                
            }
            
            return accumulator;
        }

        private int RunProgramme(List<Instruction> input, out bool overflows)
        {
            var accumulator = 0;
            overflows = false;

            for (int i = 0; i < input.Count;)
            {
                var current = input[i];

                if (!current.IsExhausted)
                {
                    switch (current.Operation)
                    {
                        case "acc":
                            accumulator += current.Argument;
                            i++;
                            break;
                        case "jmp":
                            i += current.Argument;
                            break;
                        case "nop":
                            i++;
                            break;
                        default:
                            break;
                    }

                    current.IsExhausted = true;
                }

                else
                {
                    overflows = true;
                    break;
                }
            }

            return accumulator;
        }
    }
}
