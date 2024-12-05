using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.Day5
{
    public class D5Tests
    {
        private readonly D5Parser _parser;
        private readonly D5Solver _solver;

        public D5Tests()
        {
            _parser = new D5Parser();
            _solver = new D5Solver();
        }

        [Fact]
        public void TestInput_Parses_PageOrderingRules()
        {
            var expected = new List<(int, int)> 
            { 
                (47,53), (97,13), (97, 61), (97,47), (75, 29), 
                (61, 13), (75, 53), (29, 13), (97, 29), (53, 29), 
                (61, 53), (97, 53), (61, 29), (47, 13), (75, 47), 
                (97, 75), (47, 61), (75, 61), (47, 29), (75, 13), (53, 13) };

            var path = "Day5\\D5TestInputOrderingRules.txt";
            var parsed = _parser.ParsePageOrderingRules(path);

            Assert.Equal(expected, parsed);
        }
        
        [Fact]
        public void TestInput_Parses_PageUpdates()
        {
            var expected = new List<List<int>>
            {
                new(){ 75,47,61,53,29 },
                new(){ 97,61,53,29,13 },
                new(){ 75,29,13 },
                new(){ 75,97,47,61,53 },
                new(){ 61,13,29 },
                new(){ 97,13,75,29,47 },
            };

            var path = "Day5\\D5TestInputPageUpdates.txt";
            var parsed = _parser.ParsePageUpdates(path);

            Assert.Equal(expected, parsed);
        }
        
        [Fact]
        public void Part1_Test()
        {
            var expected = 143;

            var orderingRulesPath = "Day5\\D5TestInputOrderingRules.txt";
            var orderingRules = _parser.ParsePageOrderingRules(orderingRulesPath);

            var pageUpdatesPath = "Day5\\D5TestInputPageUpdates.txt";
            var pargeUpdates = _parser.ParsePageUpdates(pageUpdatesPath);

            var result = _solver.SolvePart1(orderingRules, pargeUpdates);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part1_Actual()
        {
            var expected = 5509;

            var orderingRulesPath = "Day5\\D5InputOrderingRules.txt";
            var orderingRules = _parser.ParsePageOrderingRules(orderingRulesPath);

            var pageUpdatesPath = "Day5\\D5InputPageUpdates.txt";
            var pargeUpdates = _parser.ParsePageUpdates(pageUpdatesPath);

            var result = _solver.SolvePart1(orderingRules, pargeUpdates);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Part2_Test()
        {
            var expected = 123;

            var orderingRulesPath = "Day5\\D5TestInputOrderingRules.txt";
            var orderingRules = _parser.ParsePageOrderingRules(orderingRulesPath);

            var pageUpdatesPath = "Day5\\D5TestInputPageUpdates.txt";
            var pargeUpdates = _parser.ParsePageUpdates(pageUpdatesPath);

            var result = _solver.SolvePart2(orderingRules, pargeUpdates);

            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Part2_Actual()
        {
            var expected = 200945; // 5509 too high

            var orderingRulesPath = "Day5\\D5InputOrderingRules.txt";
            var orderingRules = _parser.ParsePageOrderingRules(orderingRulesPath);

            var pageUpdatesPath = "Day5\\D5InputPageUpdates.txt";
            var pargeUpdates = _parser.ParsePageUpdates(pageUpdatesPath);

            var result = _solver.SolvePart1(orderingRules, pargeUpdates);

            Assert.Equal(expected, result);
        }
    }
}
