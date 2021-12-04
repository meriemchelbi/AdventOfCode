using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day4
{
    public class D4Parser
    {
        public BingoGame ParseInput(string inputPath)
        {
            var output = new BingoGame();

            var absolutePath = Path.GetFullPath(inputPath);

            using (var sr = new StreamReader(absolutePath))
            {
                string line;
                var sb = new StringBuilder();
                var boardStrings = new List<String>();

                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Length > 20)
                        output.CallingNumbers = line.Split(',').Select(c => int.Parse(c)).ToList();

                    else
                    {
                        if (!line.Equals(string.Empty))
                        {
                            sb.Append(line);
                            sb.Append("|");
                        }
                         else
                        {
                            if (sb.Length > 0)
                            {
                                boardStrings.Add(sb.ToString().TrimEnd('|'));
                                sb.Clear();
                            }
                        }
                    }
                }

                boardStrings.Add(sb.ToString().TrimEnd('|'));
                sb.Clear();

                var boards = boardStrings.Select(b => b.Split('|')
                                                        .Select(s => s.Split(' ')
                                                               .Where(a => !a.Equals(""))
                                                                    .Select(s => (int.Parse(s), false)).ToArray()).ToArray());

                output.Boards = boards.ToList();
            }

            return output;

        }
    }
}
