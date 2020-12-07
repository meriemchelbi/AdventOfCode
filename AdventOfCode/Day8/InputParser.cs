using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode.Day8
{
    class InputParser
    {
        public Dictionary<string, Dictionary<string, int>> Parse()
        {
            var output = new Dictionary<string, Dictionary<string, int>>();
            var path = Path.GetFullPath("Day8\\Input.txt");

            using (var sr = new StreamReader(path))
            {
                string line;
                StringBuilder sb = new();

                while ((line = sr.ReadLine()) != null)
                {
                    
                }
            }

            return output;
        }
    }
