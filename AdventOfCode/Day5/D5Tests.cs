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
            input[9].IsHorizontalOrVertical.Should().BeFalse();
            
            input[3].IsHorizontalOrVertical.Should().BeTrue();
            var points1 = new List<(int, int)> { (2,2), (2,1) };
            input[3].Points.Should().BeEquivalentTo(points1);   
            
            input[2].IsHorizontalOrVertical.Should().BeTrue();
            var points2 = new List<(int, int)> { (9,4), (8,4), (7,4), (6, 4), (5, 4), (4, 4), (3, 4) };
            input[2].Points.Should().BeEquivalentTo(points2);
        }

        [Fact]
        public void Part1TestCase()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void Part2TestCase()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void SolvePart1()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void SolvePart2()
        {
            throw new NotImplementedException();
        }
    }
}
