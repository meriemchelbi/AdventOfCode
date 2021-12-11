using AdventOfCode.InputParsers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.Day10
{
    public class D10Tests
    {
        private readonly ToListParser _parser;
        private readonly Solver _sut;

        public D10Tests()
        {
            _parser = new ToListParser();
            _sut = new Solver();
        }

        [Theory]
        [InlineData("{([(<{}[<>[]}>{[]{[(<()>", '}')]
        [InlineData("[[<[([]))<([[{}[[()]]]", ')')]
        [InlineData("[{[{({}]{}}([{[{{{}}([]", ']')]
        [InlineData("[<(<(<(<{}))><([]([]()", ')')]
        [InlineData("<{([([[(<>()){}]>(<<{{", '>')]
        [InlineData("[({(<(())[]>[[{[]{<()<>>", '>')]
        public void GetFirstIllegalChar(string input, char expected)
        {
            var result = _sut.GetFirstIllegalChar(input);

            result.Should().Be(expected);
        }
        
        [Theory]
        [InlineData("[({(<(())[]>[[{[]{<()<>>", "}}]])})]")]
        [InlineData("[(()[<>])]({[<{<<[]>>(", ")}>]})")]
        [InlineData("(((({<>}<{<{<>}{[]{[]{}", "}}>}>))))")]
        [InlineData("{<[[]]>}<{[{[{[]{()[[[]", "]]}}]}]}>")]
        [InlineData("<{([{{}}[<[[[<>{}]]]>[]]", "])}>")]
        public void CompleteLine(string input, string expected)
        {
            var result = _sut.CompleteLine(input);

            result.Should().Be(expected);
        }

        [Fact]
        public void Part1TestCase()
        {
            var input = _parser.ParseToListOfString("Day10\\TestInput.txt");

            var result = _sut.SolvePart1(input);

            result.Should().Be(26397);
        }

        [Fact]
        public void Part2TestCase()
        {
            var input = _parser.ParseToListOfString("Day10\\TestInput.txt");

            var result = _sut.SolvePart2(input);

            result.Should().Be(288957);
        }

        [Fact]
        public void SolvePart1()
        {
            var input = _parser.ParseToListOfString("Day10\\Input.txt");

            var result = _sut.SolvePart1(input);

            result.Should().Be(316851);
        }

        [Fact]
        public void SolvePart2()
        {
            var input = _parser.ParseToListOfString("Day10\\Input.txt");

            var result = _sut.SolvePart2(input);

            result.Should().BeGreaterThan(45691823);
            result.Should().BeGreaterThan(63101831);
            result.Should().BeLessThan(2288035482);
        }
    }
}
