﻿using System.IO;

namespace Core.Utilities.Helpers
{
    public static class Helper
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
