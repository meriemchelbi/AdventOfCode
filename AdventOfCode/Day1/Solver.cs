namespace AdventOfCode.Day1
{
    class Solver
    {
        public int Solve2()
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
        
        public int Solve3()
        {
            var parser = new InputParser();
            var input = parser.Parse();

            foreach (var first in input)
            {
                foreach (var second in input)
                {
                    foreach (var third in input)
                    {
                        if (first == second || first == third || second == third)
                            continue;

                        var sum = first + second + third;

                        if (sum == 2020)
                        {
                            return first * second * third;
                        }
                    }
                }
            }
            
            return 0;
        }

    }
}
