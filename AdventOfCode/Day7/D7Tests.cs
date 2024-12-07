using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.Day7
{
    public class D7Tests
    {
        private readonly D7Parser _parser;
        private readonly D7Solver _solver;

        public D7Tests()
        {
            _parser = new D7Parser();
            _solver = new D7Solver();
        }

        [Fact]
        public void TestInput_Parses()
        {
            var expected = new List<CalibrationEquation> 
            {
                new(){ Result = 190, Numbers = [10, 19]  },
                new(){ Result = 3267, Numbers = [81, 40, 27]  },
                new(){ Result = 83, Numbers = [17, 5]  },
                new(){ Result = 156, Numbers = [15, 6]  },
                new(){ Result = 7290, Numbers = [6, 8, 6, 15]  },
                new(){ Result = 161011, Numbers = [16, 10, 13]  },
                new(){ Result = 192, Numbers = [17, 8, 14]  },
                new(){ Result = 21037, Numbers = [9, 7, 18, 13]  },
                new(){ Result = 292, Numbers = [11, 6, 16, 20]  },
            };

            var path = "Day7\\D7TestInput.txt";
            var parsed = _parser.Parse(path);

            parsed.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Part1_Test()
        {
            var expected = 3749;

            var path = "Day7\\D7TestInput.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart1(data);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part1_Actual()
        {
            var expected = 4122618559853;

            var path = "Day7\\D7Input.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart1(data);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2_Test()
        {
            var expected = 11387;

            var path = "Day7\\D7TestInput.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart2(data);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2_Actual()
        {
            var expected = 227615740238334;

            var path = "Day7\\D7Input.txt";
            var data = _parser.Parse(path);
            var result = _solver.SolvePart2(data);

            Assert.Equal(expected, result);
        }
    }
}
