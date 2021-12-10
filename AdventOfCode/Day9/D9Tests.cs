using AdventOfCode.InputParsers;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.Day9
{
    public class D9Tests
    {
        private readonly Day9Parser _parser;
        private readonly Solver _sut;

        public D9Tests()
        {
            _parser = new Day9Parser();
            _sut = new Solver();
        }

        [Fact]
        public void Part1TestCase()
        {
            var input = _parser.Parse("Day9\\TestInput.txt");

            var result = _sut.SolvePart1(input);

            result.Should().Be(15);
        }

        [Fact]
        public void Part2TestCase()
        {
            var input = _parser.Parse("Day9\\TestInput.txt");

            var result = _sut.SolvePart2(input);

            result.Should().Be(168);
        }

        [Fact]
        public void SolvePart1()
        {
            var input = _parser.Parse("Day7\\Input.txt");

            var result = _sut.SolvePart1(input);

            result.Should().Be(326132);
        }

        [Fact]
        public void SolvePart2()
        {
            var input = _parser.Parse("Day7\\Input.txt");

            var result = _sut.SolvePart2(input);

            result.Should().Be(88612508);
        }
    }
}
