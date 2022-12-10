using System.Collections.Generic;

namespace AdventOfCode.Day_7
{
    public class Directory
    {
        public Directory()
        {
            FileSizes = new List<int>();
            Children = new List<Directory>();
        }

        public string Name { get; set; }
        public List<int> FileSizes { get; }
        public List<Directory> Children { get; }
        public Directory Parent { get; set; }
        public int TotalSize { get; set; }
    }
}
