using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string ParentName { get; set; }
        public int TotalFileSize { get; set; }
        public int TotalSize { get; set; }
    }
}
