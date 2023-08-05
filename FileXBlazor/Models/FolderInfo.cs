using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileXBlazor.Models
{
    public class FolderInfo
    {
        public double AvailableFreeSpace { get; set; }
        public string DriveFormat { get; set; }
        //DriveType: Fixed
        //IsReady: true
        public string Name { get; set; }
       // public string RootDirectory { get; set; }
        public double TotalFreeSpace { get; set; }
        public double TotalSize { get; set; }
        public string VolumeLabel { get; set; }

    }
}
