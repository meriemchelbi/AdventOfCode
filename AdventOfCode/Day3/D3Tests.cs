using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.Day3
{
    public class D3Tests
    {
        private readonly D3Parser _parser;
        private readonly D3Solver _solver;

        public D3Tests()
        {
            _parser = new D3Parser();
            _solver = new D3Solver();
        }

        [Fact]
        public void TestInput1_Parses()
        {
            var expected = new List<(int,int)> 
            { 
                (2, 4),
                (5, 5),
                (11, 8),
                (8, 5)
            };

            var path = "Day3\\D3TestInput.txt";
            var parsed = _parser.Parse(path);

            parsed.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void TestInput2_Parses()
        {
            var expected = new List<(int,int)> 
            { 
                (2, 4),
                (8, 5)
            };

            var path = "Day3\\D3TestInput2.txt";
            var parsed = _parser.ParseComplex(path);

            parsed.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void Part1_Test()
        {
            var expected = 161;

            var path = "Day3\\D3TestInput.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart1(data);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part1_Actual()
        {
            var expected = 174103751;

            var path = "Day3\\D3Input.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart1(data);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2_Test()
        {
            var expected = 48;

            var path = "Day3\\D3TestInput2.txt";
            var data = _parser.ParseComplex(path);
            var result = _solver.SolvePart2(data);

            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Part2_Actual()
        {
            var expected = 31273975;// 31273975 too low, 174103751 too high

            var path = "Day3\\D3Input.txt";
            var data = _parser.ParseComplex(path);
            var result = _solver.SolvePart2(data);

            Assert.Equal(expected, result);
        }
    }
}
