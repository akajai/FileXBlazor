using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileXBlazor.Models
{
    public class SearchResult
    {
        public string DirectoryPath { get; set; }
        public int FileCount { get; set; } = 1;
        public long CombinedSize { get; set; } = 0;
    }

}
