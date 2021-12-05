using AdventOfCode.InputParsers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.Day5
{
    public class D5Tests
    {
        private readonly Day5Parser _parser;
        private readonly Solver _sut;

        public D5Tests()
        {
            _parser = new Day5Parser();
            _sut = new Solver();
        }

        [Fact]
        public void Parser()
        {
            var input = _parser.ParseInput("Day5\\TestInput.txt");

            input.Count.Should().Be(10);
            input[0].Start.Should().Be((0,9));
            input[9].End.Should().Be((8,2));
            input[9].IsHorizontal.Should().BeFalse();
            input[9].IsVertical.Should().BeFalse();
            input[0].IsHorizontal.Should().BeTrue();
            input[3].IsVertical.Should().BeTrue();
        }

        [Fact]
        public void Part1TestCase()
        {
            var input = _parser.ParseInput("Day5\\TestInput.txt");

            var result = _sut.SolvePart1(input);

            result.Should().Be(5);

            var points1 = new List<(int, int)> { (2, 2), (2, 1) };
            input[3].Points.Should().BeEquivalentTo(points1);

            var points2 = new List<(int, int)> { (9, 4), (8, 4), (7, 4), (6, 4), (5, 4), (4, 4), (3, 4) };
            input[2].Points.Should().BeEquivalentTo(points2);

            var points0 = new List<(int, int)> { (0, 9), (1, 9), (2, 9), (3, 9), (4, 9), (5, 9) };
            input[0].Points.Should().BeEquivalentTo(points0);
        }

        [Fact]
        public void Part2TestCase()
        {
            var input = _parser.ParseInput("Day5\\TestInput.txt");

            var result = _sut.SolvePart1(input);

            result.Should().Be(12);
        }

        [Fact]
        public void SolvePart1()
        {
            var input = _parser.ParseInput("Day5\\Input.txt");

            var result = _sut.SolvePart1(input);

            result.Should().Be(5169);
        }

        [Fact]
        public void SolvePart2()
        {
            var input = _parser.ParseInput("Day5\\Input.txt");

            var result = _sut.SolvePart2(input);

            result.Should().Be(0);
        }
    }
}
