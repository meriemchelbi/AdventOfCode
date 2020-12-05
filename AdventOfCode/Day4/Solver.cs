using System;
using System.Linq;

namespace AdventOfCode.Day4
{
    class Solver
    {
        internal int Solve()
        {
            var parser = new InputParser();
            var passports = parser.Parse();

            var validPassports = passports.Where(p => IsValidPassport1(p));

            return validPassports.Count();
        }

        internal int Solve2()
        {
            var parser = new InputParser();
            var passports = parser.Parse();

            var validPassports = passports.Where(p => IsValidPassport2(p));
            
            return validPassports.Count();
        }

        private bool IsValidPassport2(Passport p)
        {
            return IsValidBirthYear(p.BirthYear)
                && IsValidIssueYear(p.IssueYear)
                && IsValidExpiration(p.ExpirationYear)
                && IsValidEyeColour(p.EyeColour)
                && IsValidHairColour(p.HairColour)
                && IsValidHeight(p.Height)
                && IsValidPassportId(p.PassportId);
        }

        private bool IsValidPassport1(Passport passport)
        {
            return passport.PassportId is not null
                   && passport.BirthYear is not null
                   && passport.IssueYear is not null
                   && passport.ExpirationYear is not null
                   && passport.Height is not null
                   && passport.HairColour is not null
                   && passport.EyeColour is not null;
        }

        internal bool IsValidBirthYear(string birthYear)
        {
            if (birthYear is null)
                return false;

            var numYear = int.Parse(birthYear);

            return birthYear.Length == 4
                   && numYear >= 1920
                   && numYear <= 2002;
        }

        internal bool IsValidIssueYear(string issueYear)
        {
            if (issueYear is null)
                return false;

            var numYear = int.Parse(issueYear);

            return issueYear.Length == 4
                   && numYear >= 2010
                   && numYear <= 2020;
        }
        
        internal bool IsValidExpiration(string expirationYear)
        {
            if (expirationYear is null)
                return false;

            var numYear = int.Parse(expirationYear);

            return expirationYear.Length == 4
                   && numYear >= 2020
                   && numYear <= 2030;
        }
        
        internal bool IsValidHeight(string height)
        {
            if (height is null)
                return false;

            var suffix = height.Substring(height.Length - 2);
            var success = int.TryParse(height.Substring(0, height.Length - 2), out var numheight);

            if (!success)
                return false;

            if (suffix.Equals("cm") 
                && numheight >= 150
                && numheight <= 193)
            {
                return true;
            }
            
            if (suffix.Equals("in") 
                && numheight >= 59
                && numheight <= 76)
            {
                return true;
            }

            return false;
        }

        internal bool IsValidHairColour(string colour)
        {
            if (colour is null)
                return false;

            if (!colour[0].Equals('#') || colour.Length != 7)
                return false;
            
            var allowed = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
            
            return colour.Substring(1).All(c => allowed.Any(a => c.Equals(a)));
        }

        internal bool IsValidEyeColour(string eyeColour)
        {
            if (eyeColour is null)
                return false;

            var allowed = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

            return allowed.Any(a => eyeColour.Equals(a));
        }

        internal bool IsValidPassportId(string passportId)
        {
            if (passportId is null)
                return false;

            return passportId.Length == 9;
        }
    }
}
