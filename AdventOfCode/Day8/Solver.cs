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

            var accumulator = 0;

            for (int i = 0; i < input.Count; )
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

                else break;
            }

            return accumulator;
        }

        internal int Solve2()
        {
            var parser = new InputParser();
            var input = parser.Parse();

            return 0;
        }
    }
}
