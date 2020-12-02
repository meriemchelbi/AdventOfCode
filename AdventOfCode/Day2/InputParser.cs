using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day2
{
    class InputParser
    {
        public List<PasswordSample> Parse()
        {
            List<PasswordSample> output = new();

            var path = Path.GetFullPath("Day2\\Input.txt");

            using (var sr = new StreamReader(path))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    var elements = line.Split(' ', '-', ':').ToList();
                    elements.RemoveAll(s => s.Equals(" "));

                    output.Add(new PasswordSample
                    {
                        Min = int.Parse(elements[0]),
                        Max = int.Parse(elements[1]),
                        Letter = char.Parse(elements[2]),
                        Password = elements[^1]
                    });
                }
            }

            return output;
        }
    }
}
