using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day_5
{
    public class MoveInstruction
    {
        public int NumberToMove { get; set; }
        public int OriginStack { get; set; }
        public int DestinationStack { get; set; }
    }
}
