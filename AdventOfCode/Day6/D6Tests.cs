using AdventOfCode.InputParsers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.Day6
{
    public class D6Tests
    {
        private readonly ToListParser _parser;
        private readonly Solver _sut;

        public D6Tests()
        {
            _parser = new ToListParser();
            _sut = new Solver();
        }

        [Fact]
        public void Part1TestCase()
        {
            var input = new List<int> { 3, 4, 3, 1, 2 };

            var result = _sut.SolvePart1(input);

            result.Should().Be(5934);
        }

        [Fact]
        public void Part2TestCase()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void SolvePart1()
        {
            var input = _parser.ParseToListOfIntFromCsv("Day6\\Input.txt");

            var result = _sut.SolvePart1(input);

            result.Should().Be(0);
        }

        [Fact]
        public void SolvePart2()
        {
            throw new NotImplementedException();
        }
    }
}
