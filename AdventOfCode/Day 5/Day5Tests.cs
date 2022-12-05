using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode.Day_5
{
    public class Day5Tests
    {
        private readonly Day5Parser _parser;
        private readonly Day5Solver _solver;

        private const int Day = 5;

        public Day5Tests()
        {
            _parser = new Day5Parser();
            _solver = new Day5Solver();
        }

        [Fact]
        public void TestInput_Parses()
        {
            var stack1Values = new string[] { "Z", "N" };
            var stack2Values = new string[] { "M", "C", "D" };
            var stack3Values = new string[] { "P" };

            var expectedStacks = new Dictionary<string, Stack<string>>
            {
                { "1", new Stack<string>(stack1Values) },
                { "2", new Stack<string>(stack2Values) },
                { "3", new Stack<string>(stack3Values) },
            };
            
            var expected = new Input
            {
                Stacks = expectedStacks,
                MoveInstructions = new List<MoveInstruction>
                {
                    CreateInstruction(1, 2, 1),
                    CreateInstruction(3, 1, 3),
                    CreateInstruction(2, 2, 1),
                    CreateInstruction(1, 1, 2),
                }
            };

            var path = $"Day {Day}\\TestInput.txt";
            var parsed = _parser.Parse(path);

            parsed.Should().BeEquivalentTo(expected);
        }

        private MoveInstruction CreateInstruction(int numberToMove, int origin, int destination)
        {
            return new MoveInstruction
            {
                NumberToMove = numberToMove,
                OriginStack = origin,
                DestinationStack = destination
            };
        }

        [Fact]
        public void Part1_Test()
        {
            var expected = "CMZ";

            var path = $"Day {Day}\\TestInput.txt";
            var data = _parser.Parse(path);

            var result = _solver.SolvePart1(data);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part1_Actual()
        {
            var expected = "CMZ";

            var path = $"Day {Day}\\Input.txt";
            var data = _parser.Parse(path);

            var result = _solver.SolvePart1(data);

            Assert.Equal(expected, result);
        }

        //[Fact]
        //public void Part2_Test()
        //{
        //    var expected = 4;

        //    var path = $"Day {Day}\\TestInput.txt";
        //    var data = _parser.Parse(path);

        //    var result = _solver.SolvePart2(data);

        //    Assert.Equal(expected, result);
        //}

        //[Fact]
        //public void Part2_Actual()
        //{
        //    var expected = 867;

        //    var path = $"Day {Day}\\Input.txt";
        //    var data = _parser.Parse(path);

        //    var result = _solver.SolvePart2(data);

        //    Assert.Equal(expected, result);
        //}
    }
}
