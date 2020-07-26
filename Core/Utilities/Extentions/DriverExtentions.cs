using System.IO;

namespace Core.Utilities.Extentions
{
    public static class DriverExtentions
    {
        public static void CreateFolderIfNotExists(string folder)
        {
            if (!Directory.Exists(folder))
            {
                DirectoryInfo di = Directory.CreateDirectory(folder);
            }

        }    
    }
}
