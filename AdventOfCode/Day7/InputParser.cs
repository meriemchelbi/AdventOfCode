using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day7
{
    class InputParser
    {
        public Dictionary<string, Dictionary<string, int>> Parse()
        {
            var output = new Dictionary<string, Dictionary<string, int>>();
            var path = Path.GetFullPath("Day7\\Input.txt");

            using (var sr = new StreamReader(path))
            {
                string line;
                StringBuilder sb = new();

                while ((line = sr.ReadLine()) != null)
                {
                    var rule = ExtractRule(line);
                    output[rule.Key] = rule.Value;
                }
            }

            return output;
        }

        internal KeyValuePair<string, Dictionary<string, int>> ExtractRule(string line)
        {

            var keyValue = line.Replace("bags", "")
                                .Replace("bag", "")
                                .Replace(".", "")
                                .Split("contain")
                                .Select( k => k.Trim())
                                .ToList();

            if (keyValue[1].Contains("no other"))
                return new KeyValuePair<string, Dictionary<string, int>>(keyValue[0], null);
            
            var contents = keyValue[1].Split(',')
                                      .Select(k => k.Trim())
                                      .ToList();

            var contentsDicts = contents.ToDictionary(c => c.Substring(1).Trim(), c => int.Parse(c[0].ToString()));

            return new KeyValuePair<string, Dictionary<string, int>>(keyValue[0], contentsDicts);
        }
    }
}
