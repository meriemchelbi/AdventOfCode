using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Day8
{
    class Instruction
    {
        public string Operation { get; set; }
        public int Argument { get; set; }
        public bool IsExhausted { get; set; }
    }
}
