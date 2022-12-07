using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day_7
{
    public class Day7Solver
    {
        public int SolvePart1(List<string[]> input)
        {
            var directories = GetDirectoriesList(input);

            var currentDirectory = directories.First(d => d.Name.Equals("/"));

            CalculateTotalSize(currentDirectory);

            var max100kDirectorySize = directories.Where(d => d.TotalSize <= 100000);

            return max100kDirectorySize.Select(d => d.TotalSize).Sum();
        }

        public int SolvePart1Dictionary(List<string[]> input)
        {
            var directories = GetDirectories(input);

            var currentDirectory = directories["/"];

            CalculateTotalSize(currentDirectory);

            var max100kDirectorySize = directories.Where(d => d.Value.TotalSize <= 100000)
                                                  .Select(d => d.Value);

            return max100kDirectorySize.Select(d => d.TotalSize).Sum();
        }

        private void CalculateTotalSize(Directory currentDirectory)
        {
            if (currentDirectory.Children.Count == 0)
            {
                currentDirectory.TotalSize = currentDirectory.FileSizes.Sum();
                return;
            }
            else
            {
                foreach (var child in currentDirectory.Children)
                {
                    CalculateTotalSize(child);
                }
                currentDirectory.TotalSize = currentDirectory.Children.Select(c => c.TotalSize).Sum() + currentDirectory.FileSizes.Sum();
                return;
            }
        }

        private static Dictionary<string, Directory> GetDirectories(List<string[]> input)
        {
            var directories = new Dictionary<string, Directory>
            {
                { "/", new Directory { Name = "/" } }
            };

            string currentDirectoryName = "/";

            for (int i = 0; i < input.Count; i++)
            {
                var command = input[i];

                // navigate to child directory
                if (command[0].Equals("$") && command[1].Equals("cd") && !command[2].Equals(".."))
                {
                    currentDirectoryName = command[2];
                    continue;
                }

                // navigate to parent directory
                if (command[0].Equals("$") && command[1].Equals("cd") && command[2].Equals(".."))
                {
                    currentDirectoryName = directories[currentDirectoryName].ParentName;
                    continue;
                }

                if (command[0].Equals("$") && command[1].Equals("ls"))
                {
                    i++;
                    command = input[i];

                    // while listing directory contents
                    while (!command[0].Equals("$"))
                    {
                        if (command[0].Equals("dir"))
                        {
                            string directoryName = command[1];
                            var newDirectory = new Directory
                            {
                                Name = directoryName,
                                ParentName = currentDirectoryName
                            };
                            //var currentDirectory = directories[currentDirectoryName];
                            directories[currentDirectoryName].Children.Add(newDirectory);
                            directories.Add(directoryName, newDirectory);
                            continue;
                        }

                        // add new file
                        else
                        {
                            var currentDirectory = directories[currentDirectoryName];
                            currentDirectory.FileSizes.Add(int.Parse(command[0]));
                        }

                        i++;
                        command = input[i];
                    }
                    continue;
                }
            }

            return directories;
        }

        private static List<Directory> GetDirectoriesList(List<string[]> input)
        {
            var directories = new List<Directory> { new Directory { Name = "/" } };

            string currentDirectoryName = "/";
            var currentDirectory = directories.First(d => d.Name.Equals(currentDirectoryName));

            for (int i = 0; i < input.Count; i++)
            {
                var command = input[i];

                // navigate to child directory
                if (command[0].Equals("$") && command[1].Equals("cd") && !command[2].Equals(".."))
                {
                    currentDirectoryName = command[2];
                    continue;
                }

                // navigate to parent directory
                if (command[0].Equals("$") && command[1].Equals("cd") && command[2].Equals(".."))
                {
                    currentDirectoryName = directories.First(d => d.Name.Equals(currentDirectoryName)).ParentName;
                    continue;
                }

                if (command[0].Equals("$") && command[1].Equals("ls"))
                {

                    // while listing directory contents
                    while (!command[0].Equals("$"))
                    {
                        i++;
                        command = input[i];
                        
                        if (command[0].Equals("dir"))
                        {
                            string directoryName = command[1];
                            var newDirectory = new Directory
                            {
                                Name = directoryName,
                                ParentName = currentDirectoryName
                            };
                            //var currentDirectory = directories[currentDirectoryName];
                            directories.First(d => d.Name.Equals(currentDirectoryName)).Children.Add(newDirectory);
                            directories.Add(newDirectory);
                            continue;
                        }

                        // add new file
                        else
                        {
                            directories.First(d => d.Name.Equals(currentDirectoryName)).FileSizes.Add(int.Parse(command[0]));
                        }
                    }
                    continue;
                }

            }

            return directories;
        }

        public int SolvePart2(List<string[]> input)
        {
            return 0;
        }
    }
}
