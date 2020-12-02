using System;
using System.Linq;

namespace AdventOfCode.Day2
{
    class Solver
    {
        internal int Solve()
        {
            var parser = new InputParser();
            var input = parser.Parse();

            foreach (var password in input)
            {
                if (ValidateCounting(password))
                    password.IsValid = true;
            }

            return input.Count(i => i.IsValid);
        }

        private bool ValidateCounting(PasswordSample password)
        {
            int letterCount = password.Password.Count(l => l.Equals(password.Letter));
            
            return letterCount >= password.Min 
                   && letterCount <= password.Max;
        }
        
        internal int Solve2()
        {
            var parser = new InputParser();
            var input = parser.Parse();

            foreach (var password in input)
            {
                if (ValidateLookup(password))
                    password.IsValid = true;
            }

            return input.Count(i => i.IsValid);
        }

        internal bool ValidateLookup(PasswordSample password)
        {
            var minPosContains = password.Password[password.Min - 1] == password.Letter;
            var maxPosContains = password.Password[password.Max - 1] == password.Letter;
            return (minPosContains && !maxPosContains)
                || (!minPosContains && maxPosContains);
        }
    }
}
