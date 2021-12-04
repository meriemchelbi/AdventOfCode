using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Day4
{
    public class BingoGame
    {
        public BingoGame()
        {
            Boards = new List<(int, bool)[][]>();
        }

        public List<int> CallingNumbers { get; set; }
        public List<(int, bool)[][]> Boards { get; set; }
    }
}
