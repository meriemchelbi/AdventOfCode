using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.Day4
{
    public class Day4Tests
    {
        [Fact]
        public void InputParser_ReturnsList()
        {
            InputParser parser = new();

            var result = parser.Parse();

            Assert.IsType<List<Passport>>(result);
        }

        [Fact]
        public void Part1_Result()
        {
            Solver solver = new();

            var result = solver.Solve();

            Assert.Equal(245, result);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("1900", false)]
        [InlineData("2002", true)]
        [InlineData("2003", false)]
        [InlineData("200", false)]
        [InlineData("40000", false)]
        public void IsValidBirthYear(string value, bool expected)
        {
            var sut = new Solver();

            var result = sut.IsValidBirthYear(value);

            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData(null, false)]
        [InlineData("1900", false)]
        [InlineData("2012", true)]
        [InlineData("2024", false)]
        [InlineData("200", false)]
        [InlineData("40000", false)]
        public void IsValidIssueYear(string value, bool expected)
        {
            var sut = new Solver();

            var result = sut.IsValidIssueYear(value);

            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData(null, false)]
        [InlineData("1900", false)]
        [InlineData("2022", true)]
        [InlineData("2050", false)]
        [InlineData("200", false)]
        [InlineData("40000", false)]
        public void IsValidExpirationYear(string value, bool expected)
        {
            var sut = new Solver();

            var result = sut.IsValidExpiration(value);

            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData(null, false)]
        [InlineData("60in", true)]
        [InlineData("190cm", true)]
        [InlineData("190in", false)]
        [InlineData("190", false)]
        public void IsValidHeight(string value, bool expected)
        {
            var sut = new Solver();

            var result = sut.IsValidHeight(value);

            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData(null, false)]
        [InlineData("#123abc", true)]
        [InlineData("#123abz", false)]
        [InlineData("123abc", false)]
        public void IsValidHairColour(string value, bool expected)
        {
            var sut = new Solver();

            var result = sut.IsValidHairColour(value);

            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData(null, false)]
        [InlineData("brn", true)]
        [InlineData("wat", false)]
        public void IsValidEyeColour(string value, bool expected)
        {
            var sut = new Solver();

            var result = sut.IsValidEyeColour(value);

            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData(null, false)]
        [InlineData("000000001", true)]
        [InlineData("0123456789", false)]
        public void IsValidPassportId(string value, bool expected)
        {
            var sut = new Solver();

            var result = sut.IsValidPassportId(value);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2_Result()
        {
            Solver solver = new();

            var result = solver.Solve2();

            Assert.Equal(133, result);
        }
    }
}
