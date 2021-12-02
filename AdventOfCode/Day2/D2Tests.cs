using AdventOfCode.InputParsers;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.Day2
{
    public class D2Tests
    {
        private readonly ToTupleParser _parser;
        private readonly Solver _sut;

        public D2Tests()
        {
            _parser = new ToTupleParser();
            _sut = new Solver();
        }

        [Fact]
        public void Part1TestCase()
        {
            var input = new List<(char, int)>
            {
                ('f', 5),
                ('d', 5),
                ('f', 8),
                ('u', 3),
                ('d', 8),
                ('f', 2)
            };

            var result = _sut.SolvePart1(input);

            result.Should().Be(150);
        }
        
        [Fact]
        public void Part2TestCase()
        {
            var input = new List<(char, int)>
            {
                ('f', 5),
                ('d', 5),
                ('f', 8),
                ('u', 3),
                ('d', 8),
                ('f', 2)
            };

            var result = _sut.SolvePart2(input);

            result.Should().Be(900);
        }

        [Fact]
        public void SolvePart1()
        {
            var input = _parser.ParseToTuple("Day2\\Input.txt");

            var result = _sut.SolvePart1(input);

            result.Should().Be(1484118);
        }
        
        [Fact]
        public void SolvePart2()
        {
            var input = _parser.ParseToTuple("Day2\\Input.txt");

            var result = _sut.SolvePart2(input);

            result.Should().Be(1463827010);
        }
    }
}
