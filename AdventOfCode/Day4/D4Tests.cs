using AdventOfCode.InputParsers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.Day4
{
    public class D4Tests
    {
        private readonly D4Parser _parser;
        private readonly Solver _sut;

        public D4Tests()
        {
            _parser = new D4Parser();
            _sut = new Solver();
        }

        [Fact]
        public void ParsesInput()
        {
            var input = _parser.ParseInput("Day4\\TestInput.txt");

            input.CallingNumbers.Count.Should().Be(27);
            input.Boards.Count.Should().Be(3);
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
