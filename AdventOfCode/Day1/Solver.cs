namespace AdventOfCode.Day1
{
    class Solver
    {
        public int Solve()
        {
            var parser = new InputParser();
            var input = parser.Parse();

            foreach (var item in input)
            {
                foreach (var thing in input)
                {
                    if (thing == item)
                        continue;

                    var sum = item + thing;

                    if (sum == 2020)
                    {
                        return item * thing;
                    }
                }
            }
            
            return 0;
        }

    }
}
