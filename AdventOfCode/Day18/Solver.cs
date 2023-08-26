using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day18
{
    public class Solver
    {
        public int SolvePart1(List<string> input)
        {
            var homework = new List<string>(input);

            while (homework.Count > 1)
            {
                var newNumbers = new List<string>();

                for (int n = 0; n < homework.Count - 1; n += 2)
                {
                    var added = $"[{homework[n]},{homework[n+1]}]";
                    var reduced = ReduceNumber(added);
                    
                    newNumbers.Add(reduced);
                }

                homework = newNumbers;
            }

            return GetMagnitude(homework[0]);
        }

        public string ReduceNumber(string number)
        {
            var reduced = false;

            var result = number.ToList();
            var noOfOpeningBrackets = 0;
            int previousNumber = default;
            char nextNumber = default;

            var exploding = false;
            var splitting = false;

            for (int i = 0; i < result.Count; i++)
            {
                var current = result[i];

                if (current.Equals(','))
                    continue;

                if (current.Equals('['))
                {
                    noOfOpeningBrackets++;
                    continue;
                }

                var remainingCharacters = number.Substring(i + 1).ToList();

                if (remainingCharacters.FirstOrDefault(n => IsNumber(n)) != default)
                    nextNumber = remainingCharacters.First(n => IsNumber(n));

                if (IsNumber(current))
                {
                    var currentNumber = int.Parse(current.ToString());

                    if (exploding)
                    {
                        exploding = false;

                        if (nextNumber != default)
                        {
                            var newValue = currentNumber + int.Parse(nextNumber.ToString());
                            result[i] = newValue.ToString()[0];
                        }
                        else
                        {
                            result[i] = '0';
                            previousNumber = 0;
                            reduced = true;
                        }
                    }

                    else if (noOfOpeningBrackets == 5 && IsStartOfPair(i, number))
                    {
                        exploding = true;
                        noOfOpeningBrackets = 0;

                        if (previousNumber == default)
                        {
                            result[i] = '0';
                            previousNumber = 0;
                        }
                        else
                        {
                            var newValue = currentNumber + previousNumber;
                            result[i] = newValue.ToString()[0];
                            previousNumber = newValue;
                        }
                    }
                }
            }

            //if (reduced is true)
            //    return ReduceNumber(result.ToString());
            
            return result.ToString();
        }

        private static bool IsNumber(char character)
        {
            return !character.Equals('[') && !character.Equals(']') && !character.Equals(',');
        }

        private static bool IsStartOfPair(int index, string number)
        {
            if (index < number.Length - 3 
                && number[index + 1].Equals(',') 
                && IsNumber(number[index + 2]) 
                && number[index + 3].Equals(']'))
            {
                return true;
            }

            return false;
        }

        public int GetMagnitude(string number)
        {
            


            return 0;
        }

        public int SolvePart2(List<string> input)
        {
            throw new NotImplementedException();
        }
    }
}
