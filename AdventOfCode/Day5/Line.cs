using System.Collections.Generic;

namespace AdventOfCode.Day5
{
    public class Line
    {
        public (int, int) Start { get; set; }
        public (int, int) End { get; set; }
        public bool IsHorizontalOrVertical { get; set; }
        public List<(int,int)> Points { get; set; }

        public Line()
        {
            Points = new List<(int, int)>();
        }
    }
}
