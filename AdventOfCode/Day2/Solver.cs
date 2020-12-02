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
                if (Validate(password))
                    password.IsValid = true;
            }

            return input.Count(i => i.IsValid);
        }

        private bool Validate(PasswordSample password)
        {
            int letterCount = password.Password.Count(l => l.Equals(password.Letter));
            
            return letterCount >= password.Min 
                   && letterCount <= password.Max;
        }
    }
}
