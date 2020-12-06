using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode.Day7
{
    class InputParser
    {
        public List<string> Parse()
        {
            var output = new List<string>();
            var path = Path.GetFullPath("Day7\\Input.txt");

            using (var sr = new StreamReader(path))
            {
                string line;
                StringBuilder sb = new();

                while ((line = sr.ReadLine()) != null)
                {
                    if (!line.Equals(string.Empty))
                    {
                        sb.Append(line);
                    }

                    else
                    {
                        output.Add(sb.ToString());
                        sb.Clear();
                    }
                }

                output.Add(sb.ToString());
                sb.Clear();
            }

            return output;
        }
    }
}
