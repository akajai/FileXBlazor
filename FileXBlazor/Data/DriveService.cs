using FileXBlazor.Models;

namespace FileXBlazor.Data
{
    public class DriveService
    {
        public DriveService() { }
        public List<FolderInfo> GetAllDrives()
        {
            var result= DriveInfo.GetDrives().ToList().Select(a=> new FolderInfo {AvailableFreeSpace=a.AvailableFreeSpace,DriveFormat=a.DriveFormat,Name=a.Name,TotalFreeSpace=a.TotalFreeSpace,TotalSize=a.TotalSize,VolumeLabel=a.VolumeLabel }).ToList();
            return result;
        }
    }
}
