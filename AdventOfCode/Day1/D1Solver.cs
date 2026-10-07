using System;
using System.Collections.Generic;

namespace AdventOfCode.Day1
{
    public class D1Solver
    {
        public int SolvePart1(List<string> input)
        {
            var pointsAtZero = 0;
            var currentPosition = 50;

            foreach (var instruction in input)
            {
                var direction = instruction[0];
                var amount = int.Parse(instruction.Remove(0, 1));
                if (direction == 'R')
                {
                    var added = (currentPosition + amount) % 100;
                    if (added > 99)
                    {
                        currentPosition = added - 100;
                    }
                    else
                    {
                        currentPosition = added;
                    }
                }

                if (direction == 'L')
                {
                    var removed = (currentPosition - amount) % 100;
                    if (removed < 0)
                    {
                        currentPosition = 100 + removed;
                    }
                    else
                    {
                        currentPosition = removed;
                    }
                }

                if (currentPosition == 0)
                {
                    pointsAtZero++;
                }          
                
            }
            return pointsAtZero;
        }
        
        public int SolvePart2(List<string> input)
        {
            var pointsAtZero = 0;
            var currentPosition = 50;

            foreach (var instruction in input)
            {
                var direction = instruction[0];
                var amount = int.Parse(instruction.Remove(0, 1));
                if (direction == 'R')
                {
                    var numberOfResets = Math.DivRem(amount, 100, out var remainder);
                    pointsAtZero += numberOfResets;
                    
                    var added = currentPosition + remainder;
                    
                    if (added > 99)
                    {
                        if (currentPosition != 0)
                        {
                            pointsAtZero++;
                        }
                        currentPosition = added - 100;
                    }
                    else
                    {
                        currentPosition = added;
                        
                        if (currentPosition == 0)
                        {
                            pointsAtZero++;
                        }
                    }
                }

                if (direction == 'L')
                {
                    var numberOfResets = Math.DivRem(amount, 100, out var remainder);
                    pointsAtZero += numberOfResets;
                    
                    var removed = currentPosition - remainder;
                    
                    if (removed < 0)
                    {
                        if (currentPosition != 0)
                        {
                            pointsAtZero++;
                        }
                        currentPosition = 100 + removed;
                    }
                    else
                    {
                        currentPosition = removed;
                        
                        if (currentPosition == 0)
                        {
                            pointsAtZero++;
                        }
                    }
                }
            }
            return pointsAtZero;
        }
    }
}
