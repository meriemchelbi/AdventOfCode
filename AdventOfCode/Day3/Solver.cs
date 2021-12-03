using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day3
{
    public class Solver
    {
        // key = position of bit, value = most common value for position
        private Dictionary<int, char> _mostCommon = new Dictionary<int, char>();

        public int SolvePart1(List<string> input)
        {
            for (int i = 0; i < input[0].Length; i++)
            {
                var mostCommonValue = FindMostCommon(i, input);
                _mostCommon.Add(i, mostCommonValue);
            }

            var gammaRateBinary = CalculateGammaRate();
            var gammaRateDecimal = Convert.ToInt32(gammaRateBinary, 2);

            string epsilonRateBinary = CalculateEpsilonRate(gammaRateBinary);
            var epsilonRateDecimal = Convert.ToInt32(epsilonRateBinary, 2);

            return gammaRateDecimal * epsilonRateDecimal;
        }

        public int SolvePart2(List<string> input)
        {
            int oxygenRating = CalculateRating(input, true);

            int co2Rating = CalculateRating(input, false);

            return oxygenRating * co2Rating;
        }

        private string CalculateGammaRate()
        {
            var gammaRate = new StringBuilder();

            foreach (var element in _mostCommon)
                gammaRate.Append(element.Value);

            return gammaRate.ToString();
        }

        private string CalculateEpsilonRate(string gammaRate)
        {
            var epsilonRate = new StringBuilder();

            foreach (var character in gammaRate)
            {
                if (character.Equals('1'))
                    epsilonRate.Append("0");
                else
                    epsilonRate.Append("1");
            }

            return epsilonRate.ToString();
        }

        private int CalculateRating(List<string> input, bool isOxygen)
        {
            var numberLength = input[0].Length;
            var shortList = new List<string>(input);

            for (int i = 0; i < numberLength; i++)
            {
                var mostCommon = FindMostCommon(i, shortList);

                shortList = shortList.Where(element => element[i].Equals(mostCommon) == isOxygen)
                    .ToList();
                if (shortList.Count == 1)
                    break;
            }

            return Convert.ToInt32(shortList[0], 2);
        }

        private char FindMostCommon(int position, List<string> input)
        {
            var countOf1 = 0;

            foreach (var item in input)
            {
                if (item[position].Equals('1'))
                    countOf1++;
            }

            var majorityCount = Math.Ceiling((double)input.Count / 2);
            if (countOf1 >= majorityCount)
                return '1';
            
            return '0';
        }
    }
}
