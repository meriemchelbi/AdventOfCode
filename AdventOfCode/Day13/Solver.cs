using System;
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

        internal UInt64 Solve2(string inputFileName)
        {
            var parser = new InputParser();
            var input = parser.Parse(inputFileName);

            var indexedBusIds = ExtractIndexedBusIds(input.Timetable);
            var busIds = input.Timetable.Where(t => !t.Equals("x"))
                                        .Select(b => int.Parse(b)).ToArray();
            var firstBus = (UInt64) indexedBusIds[0];

            UInt64 winningTimestamp = 0;

            for (UInt64 i = firstBus; i < UInt64.MaxValue; i += (UInt64)busIds[0])
            {
                var isWinner = IsWinningTimestamp(indexedBusIds, i);

                if (isWinner)
                {
                    winningTimestamp = i;
                    break;
                }
            }

            return winningTimestamp;
        }

        internal Dictionary<int, int> ExtractIndexedBusIds(string[] timetable)
        {
            var result = new Dictionary<int, int>();

            for (int i = 0; i < timetable.Length; i++)
            {
                if (timetable[i].Equals("x"))
                    continue;

                else
                    result[i] = int.Parse(timetable[i]);
            }

            return result;
        }
        
        internal Dictionary<int, int> ExtractRelativeBusIds(string[] timetable, int rootBusIndex)
        {
            var result = new Dictionary<int, int>();
            var list = timetable.ToList();
            var rootBusId = int.Parse(timetable[rootBusIndex]);

            result[0] = rootBusId;

            for (int i = 0; i < timetable.Length; i++)
            {
                if (timetable[i].Equals("x"))
                    continue;

                else
                {
                    var index = i - rootBusIndex;
                    result[index] = int.Parse(timetable[i]);
                }
            }

            return result;
        }

        internal bool IsWinningTimestamp(Dictionary<int, int> indexedBusIds, UInt64 timestamp)
        {
            foreach (var bus in indexedBusIds)
            {
                var busId = bus.Value;
                var nextTimestamp = timestamp + (ulong) bus.Key;
                var hasRemainder = (nextTimestamp % (ulong) busId) != 0;

                if (hasRemainder)
                    return false;
            }

            return true;
        }

        internal ulong Solve3(string inputFileName)
        {
            var parser = new InputParser();
            var input = parser.Parse(inputFileName);
            var busIds = input.Timetable.Where(t => !t.Equals("x"))
                                        .Select(b => int.Parse(b)).ToList();
            var highestBusId = busIds.Max();
            var highestBusIndex = input.Timetable.ToList().IndexOf(highestBusId.ToString());
            var indexedBusIds = ExtractRelativeBusIds(input.Timetable, highestBusIndex);

            UInt64 winningTimestamp = 0;

            for (ulong i = 100000000000000; i < ulong.MaxValue; i += (ulong)highestBusId)
            {
                var isWinner = IsWinningTimestamp(indexedBusIds, i);

                if (isWinner)
                {
                    winningTimestamp = i;
                    break;
                }
            }

            return winningTimestamp;
        }

        private List<int> ExtractBusIds(string[] timetable)
        {
            return timetable.Where(t => !t.Equals("x"))
                            .Select(b => int.Parse(b))
                            .ToList();
        }
    }
}
