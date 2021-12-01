using AdventOfCode.InputParsers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode.Day1
{
    public class D1Tests
    {
        private readonly Solver _sut;

        public D1Tests()
        {
            _sut = new Solver();
        }

        [Fact]
        public void CalculatesCorrectNumberOfMeasurementIncreases()
        {
            var input = new List<int> { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };

            var result = _sut.CalculateMeasurementIncreases(input);

            result.Should().Be(7);
        }

        [Fact]
        public void SolvePart1()
        {
            var parser = new ToListParser();
            var input = parser.ParseToListOfInt("Day1\\Input.txt");

            var result = _sut.CalculateMeasurementIncreases(input);

            result.Should().Be(1184);
        }
        
        [Fact]
        public void CalculatesCorrectNumberOfSlidingWindowIncreases()
        {
            var input = new List<int> { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };

            var result = _sut.CalculateSlidingWindowIncreases(input);

            result.Should().Be(5);
        }

        [Fact]
        public void SolvePart2()
        {
            var parser = new ToListParser();
            var input = parser.ParseToListOfInt("Day1\\Input.txt");

            var result = _sut.CalculateSlidingWindowIncreases(input);

            result.Should().Be(1158);
        }
    }
}
