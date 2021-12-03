using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day3
{
    public class Solver
    {
        // key = position of bit, value = number of 1s
        private Dictionary<int, int> _countOfBits = new Dictionary<int, int>();

        public int SolvePart1(List<string> input)
        {
            ConstructCountOfBits(input);

            string gammaRateBinary = CalculateGammaRate(input.Count);
            var gammaRateDecimal = Convert.ToInt32(gammaRateBinary, 2);

            string epsilonRateBinary = CalculateEpsilonRate(gammaRateBinary);
            var epsilonRateDecimal = Convert.ToInt32(epsilonRateBinary, 2);

            return gammaRateDecimal * epsilonRateDecimal;
        }

        public int SolvePart2(List<string> input)
        {
            int oxygenRating = CalculateOxygenRating(input);

            int co2Rating = CalculateCo2Rating(input);

            return oxygenRating * co2Rating;
        }

        private void ConstructCountOfBits(List<string> input)
        {
            var countOfBits = new Dictionary<int, int>();
            for (int i = 0; i < input[0].Length; i++)
            {
                countOfBits.Add(i, 0);
            }

            foreach (var bitfield in input)
            {
                for (int i = 0; i < bitfield.Length; i++)
                {
                    if (bitfield[i].Equals('1'))
                        countOfBits[i] += 1;
                }
            }

            _countOfBits = countOfBits;
        }

        private string CalculateGammaRate(int countOfNumbers)
        {
            var minimumForMajority = countOfNumbers / 2;
            var gammaRate = new StringBuilder();

            foreach (var count in _countOfBits)
            {
                if (count.Value >= minimumForMajority)
                    gammaRate.Append("1");
                else
                    gammaRate.Append("0");
            }

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

        private int CalculateOxygenRating(List<string> input)
        {
            var numberLength = input[0].Length;
            var shortList = new List<string>(input);

            for (int i = 0; i < numberLength; i++)
            {
                // find most common element in position
                char mostCommon;
                var countOf1 = 0;
                foreach (var item in shortList)
                {
                    if (item[i].Equals('1'))
                        countOf1++;
                }

                var majorityCount = Math.Ceiling((double)shortList.Count/2);
                if (countOf1 >= majorityCount)
                {
                    mostCommon = '1';
                }
                else mostCommon = '0';

                // filter shortlist to exclude all other elements
                shortList = shortList.Where(element => element[i].Equals(mostCommon)).ToList();
                if (shortList.Count == 1)
                    break;
            }

            return Convert.ToInt32(shortList[0], 2);
        }

        private int CalculateCo2Rating(List<string> input)
        {
            var numberLength = input[0].Length;
            var shortList = new List<string>(input);

            for (int i = 0; i < numberLength; i++)
            {
                // find least common element in position
                char mostCommon;
                var countOf1 = 0;
                foreach (var item in shortList)
                {
                    if (item[i].Equals('1'))
                        countOf1++;
                }

                var majorityCount = Math.Ceiling((double)shortList.Count/2);
                if (countOf1 >= majorityCount)
                {
                    mostCommon = '1';
                }
                else mostCommon = '0';

                // filter shortlist to exclude all other elements
                shortList = shortList.Where(element => !element[i].Equals(mostCommon)).ToList();
                if (shortList.Count == 1)
                    break;
            }

            return Convert.ToInt32(shortList[0], 2);
        }
    }
}
