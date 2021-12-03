using AdventOfCode.InputParsers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.Day3
{
    public class D3Tests
    {
        private readonly ToListParser _parser;
        private readonly Solver _sut;

        public D3Tests()
        {
            _parser = new ToListParser();
            _sut = new Solver();
        }

        [Fact]
        public void Part1TestCase()
        {
            var input = new List<string> { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };

            var result = _sut.SolvePart1(input);

            result.Should().Be(198);
        }

        [Fact]
        public void Part2TestCase()
        {
            var input = new List<string> { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };

            var result = _sut.SolvePart2(input);

            result.Should().Be(230);
        }

        [Fact]
        public void SolvePart1()
        {
            var input = _parser.ParseToListOfString("Day3\\Input.txt");

            var result = _sut.SolvePart1(input);

            result.Should().Be(4191876);
        }

        [Fact]
        public void SolvePart2()
        {
            var input = _parser.ParseToListOfString("Day3\\Input.txt");

            var result = _sut.SolvePart2(input);

            result.Should().Be(3414905);
        }
    }
}
