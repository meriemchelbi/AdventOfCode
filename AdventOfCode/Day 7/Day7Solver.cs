using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day_7
{
    public class Day7Solver
    {
        private readonly List<Directory> _directories;

        public Day7Solver()
        {
            _directories = new List<Directory>();
        }

        public int SolvePart1(List<string[]> input)
        {
            GetDirectories(input);

            var currentDirectory = _directories.First(d => d.Name.Equals("/"));

            CalculateTotalSize(currentDirectory);

            var max100kDirectorySize = _directories.Where(d => d.TotalSize <= 100000);

            return max100kDirectorySize.Select(d => d.TotalSize).Sum();
        }

        public int SolvePart2(List<string[]> input)
        {
            return 0;
        }
        
        private void GetDirectories(List<string[]> input)
        {
            var currentDirectory = new Directory { Name = "/" };
            _directories.Add(currentDirectory);

            for (int i = 1; i < input.Count; i++)
            {
                var output = input[i];
                var isCommand = output[0].Equals("$");

                if (isCommand && output[1].Equals("cd"))
                {
                    var destination = output[2];
                    currentDirectory = MoveDirectory(currentDirectory, destination);
                    continue;
                }

                else if (isCommand && output[1].Equals("ls"))
                {
                    continue;
                }

                else if (output[0].Equals("dir"))
                {
                    var newDirectoryName = output[1];
                    var newDirectory = new Directory
                    {
                        Name = newDirectoryName,
                        Parent = currentDirectory,
                    };
                    _directories.First(d => d == currentDirectory).Children.Add(newDirectory);
                    _directories.Add(newDirectory);
                    continue;
                }

                else
                {
                    var fileSize = int.Parse(output[0]);
                    _directories.First(d => d == currentDirectory).FileSizes.Add(fileSize);
                    continue;
                }
            }
        }

        private Directory MoveDirectory(Directory currentDirectory, string destination)
        {
            if (destination.Equals(".."))
            {
                return currentDirectory.Parent;
            }

            else
            {
                return currentDirectory.Children.First(d => d.Name.Equals(destination));
            }
        }

        private void CalculateTotalSize(Directory currentDirectory)
        {
            if (currentDirectory.Children.Count == 0)
            {
                _directories.First(d => d == currentDirectory).TotalSize = currentDirectory.FileSizes.Sum();
                return;
            }
            else
            {
                foreach (var child in currentDirectory.Children)
                {
                    CalculateTotalSize(child);
                }
                _directories.First(d => d == currentDirectory).TotalSize = currentDirectory.Children.Select(c => c.TotalSize).Sum() + currentDirectory.FileSizes.Sum();
                return;
            }
        }
    }
}
