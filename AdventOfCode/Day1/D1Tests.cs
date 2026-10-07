using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.Day1
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
        public void TestInput_Parses_AsList()
        {
            var expected = new List<string> { "L68", "L30", "R48", "L5", "R60", "L55", "L1", "L99", "R14", "L82" };

            var path = "Day1\\D1TestInput.txt";
            var parsed = _parser.Parse(path);

            Assert.Equal(expected, parsed);
        }
        
        [Fact]
        public void Part1_Test()
        {
            var expected = 3;
        
            var path = "Day1\\D1TestInput.txt";
            var data = _parser.Parse(path);
            var restult = _solver.SolvePart1(data);
        
            Assert.Equal(expected, restult);
        }
        
        [Fact]
        public void Part1_Actual() // 255 too low
        {
            var expected = 1105;
        
            var path = "Day1\\D1Input.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart1(data);
        
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Part2_Test()
        {
            var expected = 6;
        
            var path = "Day1\\D1TestInput.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart2(data);
        
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Part2_Actual()
        {
            var expected = 6599;
        
            var path = "Day1\\D1Input.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart2(data);
        
            Assert.Equal(expected, result);
        }
    }
}
