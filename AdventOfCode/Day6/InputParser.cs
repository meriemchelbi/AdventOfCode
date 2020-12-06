using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode.Day6
{
    class InputParser
    {
        public List<string> ParseGroups()
        {
            var output = new List<string>();
            var path = Path.GetFullPath("Day6\\Input.txt");

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
        
        public List<string[]> ParseIndividuals()
        {
            var output = new List<string[]>();
            var path = Path.GetFullPath("Day6\\Input.txt");

            using (var sr = new StreamReader(path))
            {
                string line;
                StringBuilder sb = new();

                while ((line = sr.ReadLine()) != null)
                {
                    if (!line.Equals(string.Empty))
                    {
                        sb.Append(line);
                        sb.Append(' ');
                    }

                    else
                    {
                        output.Add(sb.ToString().Trim().Split(' '));
                        sb.Clear();
                    }
                }

                output.Add(sb.ToString().Trim().Split(' '));
                sb.Clear();
            }

            return output;
        }
    }
}
