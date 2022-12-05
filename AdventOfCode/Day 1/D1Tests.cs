using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode.Day_1
{
    public class D1Tests
    {
        private readonly D1Parser _parser;
        private readonly D1Solver _solver;

        public D1Tests()
        {
            _parser = new D1Parser();
            _solver = new D1Solver();
        }

        [Fact]
        public void TestInput_Parses_AsListOfInt()
        {
            var expected = new List<int> { 6000, 4000, 11000, 24000, 10000 };

            var path = "Day 1\\D1TestInput.txt";
            var parsed = _parser.Parse(path);

            Assert.Equal(expected, parsed);
        }
    }
}
