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

        [Fact]
        public void CalculatesCorrectNumberOfMeasurementIncreases()
        {
            var input = _parser.ParseToIntJagged("Day11\\TestInput.txt");

            var result = _sut.SolvePart1(input);

            result.Should().Be(1656);
        }

        [Fact]
        public void SolvePart1()
        {
            var input = _parser.ParseToIntJagged("Day11\\Input.txt");

            var result = _sut.SolvePart1(input);

            result.Should().Be(0);
        }

        [Fact]
        public void CalculatesCorrectNumberOfSlidingWindowIncreases()
        {
            var input = _parser.ParseToIntJagged("Day11\\TestInput.txt");

            var result = _sut.SolvePart2(input);

            result.Should().Be(0);
        }

        [Fact]
        public void SolvePart2()
        {
            var input = _parser.ParseToIntJagged("Day11\\Input.txt");

            var result = _sut.SolvePart2(input);

            result.Should().Be(1158);
        }
    }
}
