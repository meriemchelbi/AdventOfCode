using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.InputParsers
{
    public class ToListParser
    {
        public List<int> ParseToListOfInt(string inputPath)
        {
            var output = new List<int>();

            var absolutePath = Path.GetFullPath(inputPath);

            using (var sr = new StreamReader(absolutePath))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    var number = int.Parse(line);
                    output.Add(number);
                }
            }

            return output;
        }
        
        public List<int> ParseToListOfIntFromCsv(string inputPath)
        {
            var output = new List<int>();

            var absolutePath = Path.GetFullPath(inputPath);

            using (var sr = new StreamReader(absolutePath))
            {
                string csv;

                while ((csv = sr.ReadLine()) != null)
                {
                    var split = csv.Split(',').Select(s => int.Parse(s)).ToList();

                    output.AddRange(split);
                }
            }

            return output;
        }
        
        public List<string> ParseToListOfString(string inputPath)
        {
            var output = new List<string>();

            var absolutePath = Path.GetFullPath(inputPath);

            using (var sr = new StreamReader(absolutePath))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    output.Add(line);
                }
            }

            return output;
        }
    }
}
