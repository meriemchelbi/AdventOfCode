using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day_1
{
    public class D1Parser
    {
        public List<int> Parse(string inputPath)
        {
            var output = new List<int>();

            var absolutePath = Path.GetFullPath(inputPath);

            using (var sr = new StreamReader(absolutePath))
            {
                string line;

                var elfCalories = new List<int>();
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Length != 0)
                    {
                        var number = int.Parse(line);
                        elfCalories.Add(number);
                    }
                    else
                    {
                        GetTotalCalories(output, elfCalories);
                    }
                }
                GetTotalCalories(output, elfCalories);
            }

            return output;
        }

        private static void GetTotalCalories(List<int> output, List<int> elfCalories)
        {
            var totalCalories = 0;
            elfCalories.ForEach(c => totalCalories += c);
            output.Add(totalCalories);
            elfCalories.Clear();
        }
    }
}
