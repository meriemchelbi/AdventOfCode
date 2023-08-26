using AdventOfCode.InputParsers;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.Day18
{
    public class D18Tests
    {
        private readonly ToListParser _parser;
        private readonly Solver _sut;

        public D18Tests()
        {
            _parser = new ToListParser();
            _sut = new Solver();
        }

        [Fact]
        public void ReduceNumber()
        {
            var result = _sut.ReduceNumber("[[[[[4,3],4],4],[7,[[8,4],9]]],[1,1]]");

            result.Should().Be("[[[[0,7],4],[[7,8],[6,0]]],[8,1]]");
        }
        
        [Fact]
        public void Part1TestCase()
        {
            var input = _parser.ParseToListOfString("Day18\\TestInput.txt");

            var result = _sut.SolvePart1(input);

            result.Should().Be(4140);
        }

        [Fact]
        public void Part2TestCase()
        {
            var input = _parser.ParseToListOfString("Day18\\TestInput.txt");

            var result = _sut.SolvePart2(input);

            result.Should().Be(0);
        }

        [Fact]
        public void SolvePart1()
        {
            var input = _parser.ParseToListOfString("Day18\\Input.txt");

            var result = _sut.SolvePart1(input);

            result.Should().Be(0);
        }

        [Fact]
        public void SolvePart2()
        {
            var input = _parser.ParseToListOfString("Day18\\Input.txt");

            var result = _sut.SolvePart2(input);

            result.Should().Be(0);
        }
    }
}
