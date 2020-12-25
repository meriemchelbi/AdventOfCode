using System.Collections.Generic;

namespace AdventOfCode.Day12
{
    class Solver
    {
        internal List<char[]> _input;

        internal int Solve(string inputFileName)
        {
            var parser = new InputParser();
            _input = parser.Parse(inputFileName);

            return 0;
        }

        internal int Solve2(string inputFileName)
        {
            var parser = new InputParser();
            _input = parser.Parse(inputFileName);

            return 0;
        }
    }
}
