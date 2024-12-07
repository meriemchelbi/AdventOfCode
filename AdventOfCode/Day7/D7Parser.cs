using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day7
{
    public class D7Parser
    {
        public List<CalibrationEquation> Parse(string inputPath)
        {
            var output = new List<CalibrationEquation>();

            var absolutePath = Path.GetFullPath(inputPath);

            using (var sr = new StreamReader(absolutePath))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    var split = line.Split(':');
                    var result = long.Parse(split[0]);

                    var numbersSplit = split[1].TrimStart().Split(' ');
                    var numbers = numbersSplit.Select(n => int.Parse(n)).ToList();

                    output.Add( new CalibrationEquation
                    {
                        Result = result,
                        Numbers = numbers
                    } );
                }
            }

            return output;
        }
    }
}
