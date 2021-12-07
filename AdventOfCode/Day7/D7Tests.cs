using AdventOfCode.InputParsers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.Day7
{
    public class D7Tests
    {
        private readonly ToListParser _parser;
        private readonly Solver _sut;

        public D7Tests()
        {
            _parser = new ToListParser();
            _sut = new Solver();
        }

        [Fact]
        public void Part1TestCase()
        {
            var input = new List<int> { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 };

            var result = _sut.SolvePart1(input);

            result.Should().Be(37);
        }

        [Fact]
        public void Part2TestCase()
        {
            var input = new List<int> { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 };

            var result = _sut.SolvePart2(input);

            result.Should().Be(168);
        }

        [Fact]
        public void SolvePart1()
        {
            var input = _parser.ParseToListOfIntFromCsv("Day7\\Input.txt");

            var result = _sut.SolvePart1(input);

            result.Should().Be(326132);
        }

        [Fact]
        public void SolvePart2()
        {
            var input = _parser.ParseToListOfIntFromCsv("Day7\\Input.txt");

            var result = _sut.SolvePart2(input);

            result.Should().Be(0);
        }
    }
}
