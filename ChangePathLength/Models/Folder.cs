using Delimon.Win32.IO;

namespace ChangePathLength.Models
{
    public class Folder
    {
        public string Fullpath { get; set; }
        public string FolderName { get; set; }

        public Folder()
        {

        }

        public Folder(string folderName)
        {
            FolderName = folderName;
            var di = new DirectoryInfo(FolderName);
            Fullpath = di.FullName;

        }
    }
}
