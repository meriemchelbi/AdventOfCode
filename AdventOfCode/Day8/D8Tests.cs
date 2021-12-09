using AdventOfCode.InputParsers;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.Day8
{
    public class D8Tests
    {
        private readonly Day8Parser _parser;
        private readonly Solver _sut;

        public D8Tests()
        {
            _parser = new Day8Parser();
            _sut = new Solver();
        }

        [Fact]
        public void Part1TestCase()
        {
            var input = _parser.ParsePart1("Day8\\TestInput.txt");

            var result = _sut.SolvePart1(input);

            result.Should().Be(26);
        }

        [Fact]
        public void Part2SimpleTest()
        {
            var patterns = new string[] { "acedgfb", "cdfbe", "gcdfa", "fbcad", "dab", "cefabd", "cdfgeb", "eafb", "cagedb", "ab" };
            var outputs = new string[] { "cdfeb", "fcadb", "cdfeb", "cdbaf" };

            var input = new List<(string[], string[])> { (patterns, outputs) };

            var result = _sut.SolvePart2(input);

            result.Should().Be(5353);
        }

        [Fact]
        public void Part2TestCase()
        {
            var input = _parser.ParsePart2("Day8\\TestInput.txt");

            var result = _sut.SolvePart2(input);

            result.Should().Be(61229);
        }

        [Fact]
        public void SolvePart1()
        {
            var input = _parser.ParsePart1("Day8\\Input.txt");

            var result = _sut.SolvePart1(input);

            result.Should().Be(294);
        }

        [Fact]
        public void SolvePart2()
        {
            var input = _parser.ParsePart2("Day8\\Input.txt");

            var result = _sut.SolvePart2(input);

            result.Should().Be(0);
        }
    }
}
