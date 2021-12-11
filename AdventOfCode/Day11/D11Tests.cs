using AdventOfCode.InputParsers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode.Day11
{
    public class D11Tests
    {
        private readonly ToJaggedArrayParser _parser;
        private readonly Solver _sut;

        public D11Tests()
        {
            _parser = new ToJaggedArrayParser();
            _sut = new Solver();
        }

        [Theory]
        [InlineData("Day11\\TestInput.txt", 100, 1656)]
        [InlineData("Day11\\SimpleTestInput.txt", 2, 9)]
        public void TestPart1(string inputPath, int noOfSteps, int expected)
        {
            var input = _parser.ParseToIntJagged(inputPath);

            var result = _sut.SolvePart1(input, noOfSteps);

            result.Should().Be(expected);
        }

        [Fact]
        public void SolvePart1()
        {
            var input = _parser.ParseToIntJagged("Day11\\Input.txt");

            var result = _sut.SolvePart1(input, 100);

            result.Should().Be(1601);
        }

        [Fact]
        public void TestPart2()
        {
            var input = _parser.ParseToIntJagged("Day11\\TestInput.txt");

            var result = _sut.SolvePart2(input);

            result.Should().Be(195);
        }

        [Fact]
        public void SolvePart2()
        {
            var input = _parser.ParseToIntJagged("Day11\\Input.txt");

            var result = _sut.SolvePart2(input);

            result.Should().Be(368);
        }
    }
}
