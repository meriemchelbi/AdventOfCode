using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode.Day4
{
    class InputParser
    {
        public List<Passport> Parse()
        {
            var output = new List<Passport>();
            var path = Path.GetFullPath("Day4\\Input.txt");
            var unserialised = ParseRawInput(path);

            return DeserialisePassports(unserialised);
        }

        private List<string> ParseRawInput(string path)
        {
            var unparsed = new List<string>();

            using (var sr = new StreamReader(path))
            {
                string line;
                StringBuilder sb = new();

                // TODO look into extracting a ReadPassport() method to iterate through the file
                // Maybe include deserialisation at this stage

                while ((line = sr.ReadLine()) != null)
                {
                    if (!line.Equals(string.Empty))
                    {
                        sb.Append(line);
                        sb.Append(" ");
                    }

                    else
                    {
                        unparsed.Add(sb.ToString());
                        sb.Clear();
                    }
                }

                unparsed.Add(sb.ToString());
                sb.Clear();
            }

            return unparsed;
        }

        private List<Passport> DeserialisePassports(List<string> unserialised)
        {
            var passports = new List<Passport>();

            foreach (var entry in unserialised)
            {
                var passport = new Passport();

                var properties = entry.Trim().Split(' ');
                foreach (var prop in properties)
                {
                    var kvp = prop.Trim().Split(':');
                    var value = kvp[1];

                    switch (kvp[0])
                    {
                        case "byr":
                            passport.BirthYear = value;
                            break;
                        case "iyr":
                            passport.IssueYear = value;
                            break;
                        case "eyr":
                            passport.ExpirationYear = value;
                            break;
                        case "hgt":
                            passport.Height = value;
                            break;
                        case "hcl":
                            passport.HairColour = value;
                            break;
                        case "ecl":
                            passport.EyeColour = value;
                            break;
                        case "pid":
                            passport.PassportId = value;
                            break;
                        case "cid":
                            passport.CountryId = value;
                            break;
                        default:
                            break;
                    }
                }

                passports.Add(passport);
            }

            return passports;
        }
    }
}
