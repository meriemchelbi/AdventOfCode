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

        [Theory]
        [InlineData(18, 26)]
        [InlineData(80, 5934)]
        public void Part1TestCase(int noOfDays, int expectedFish)
        {
            var input = new List<int> { 3, 4, 3, 1, 2 };

            var result = _sut.SolvePart1(input, noOfDays);

            result.Should().Be(expectedFish);
        }

        [Fact]
        public void Part2TestCase()
        {
            var input = new List<int> { 3, 4, 3, 1, 2 };

            var result = _sut.SolvePart2(input, 256);

            result.Should().Be(26984457539);
        }

        [Fact]
        public void SolvePart1()
        {
            var input = _parser.ParseToListOfIntFromCsv("Day6\\Input.txt");

            var result = _sut.SolvePart1(input, 80);

            result.Should().Be(354564);
        }

        [Fact]
        public void SolvePart2()
        {
            var input = _parser.ParseToListOfIntFromCsv("Day6\\Input.txt");

            var result = _sut.SolvePart2(input, 256);

            result.Should().Be(1609058859115);
        }
    }
}
