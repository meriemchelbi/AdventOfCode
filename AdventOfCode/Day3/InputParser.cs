using System.IO;

namespace AdventOfCode.Day3
{
    class InputParser
    {
        public string Parse()
        {
            var path = Path.GetFullPath("Day3\\Input.txt");

            using (var sr = new StreamReader(path))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    // code goes here
                }
            }

            return string.Empty;
        }
    }
}
