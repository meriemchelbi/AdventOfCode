using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day13
{
    class Solver
    {
        internal double Solve(string inputFileName)
        {
            var parser = new InputParser();
            var input = parser.Parse(inputFileName);

            double earliestBus = 0;
            var startingTimestamp = input.EarliestDepartureTimestamp;
            var busIds = ExtractBusIds(input.Timetable);

            while (earliestBus == default)
            {
                foreach (var busId in busIds)
                {
                    var remainder = startingTimestamp % busId;
                    if (remainder == 0)
                    {
                        earliestBus = busId;
                        break;
                    }
                }

                startingTimestamp++;
            }

            var minutesWait = startingTimestamp - input.EarliestDepartureTimestamp - 1;

            return earliestBus * minutesWait;
        }

        internal int Solve2(string inputFileName)
        {
            var parser = new InputParser();
            var input = parser.Parse(inputFileName);
            
            return 0;
        }

        private List<int> ExtractBusIds(string[] timetable)
        {
            return timetable.Where(t => !t.Equals("x"))
                            .Select(b => int.Parse(b))
                            .ToList();
        }
    }
}
