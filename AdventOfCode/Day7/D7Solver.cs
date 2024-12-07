using System.Collections.Generic;

namespace AdventOfCode.Day7
{
    public class D7Solver
    {
        public long SolvePart1(List<CalibrationEquation> input)
        {
            var correctEquationValues = new List<long>();

            foreach (var equation in input)
            {
                if (IsCorrectEquation(equation))
                {
                    correctEquationValues.Add(equation.Result);
                }
            }

            return correctEquationValues.Sum();
        }

        public long SolvePart2(List<CalibrationEquation> input)
        {
            var correctEquationValues = new List<long>();

            foreach (var equation in input)
            {
                if (IsCorrectEquationWithConcatenation(equation))
                {
                    correctEquationValues.Add(equation.Result);
                }
            }

            return correctEquationValues.Sum();
        }

        private bool IsCorrectEquation(CalibrationEquation equation)
        {
            var rollingResults = new List<long> { equation.Numbers[0] };

            for (int i = 1; i < equation.Numbers.Count; i++)
            {
                var tmp = new List<long>();

                var nextNumber = equation.Numbers[i];

                foreach (var number in rollingResults)
                {
                    var added = number + nextNumber;
                    tmp.Add(added);

                    var multiplied = number * nextNumber;
                    tmp.Add(multiplied);
                }

                rollingResults = [.. tmp];
            }

            return rollingResults.Any(r => r == equation.Result);
        }
        
        private bool IsCorrectEquationWithConcatenation(CalibrationEquation equation)
        {
            var rollingResults = new List<long> { equation.Numbers[0] };

            for (int i = 1; i < equation.Numbers.Count; i++)
            {
                var tmp = new List<long>();

                var nextNumber = equation.Numbers[i];

                foreach (var number in rollingResults)
                {
                    var added = number + nextNumber;
                    tmp.Add(added);

                    var multiplied = number * nextNumber;
                    tmp.Add(multiplied);

                    var concatenated = long.Parse(number.ToString() + nextNumber.ToString());
                    tmp.Add(concatenated);
                }

                rollingResults = [.. tmp];
            }

            return rollingResults.Any(r => r == equation.Result);
        }
    }
}
