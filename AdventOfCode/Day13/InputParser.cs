using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day13
{
    class InputParser
    {
        public Input Parse(string fileName)
        {
            var path = Path.GetFullPath($"Day13\\{fileName}.txt");
            var input = File.ReadAllLines(path);

            return new Input
            {
                EarliestDepartureTimestamp = int.Parse(input[0]),
                Timetable = input[1].Split(',')
            };
        }

        
    }
}
