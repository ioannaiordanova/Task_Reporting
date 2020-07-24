using System;
using System.IO;
using System.Text.RegularExpressions;

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

        public static Match ExtractPartOfString(string str)
        {
            Match match = Regex.Match(str, @"\w*;*\s*scale((.*), (.*))");
            Console.WriteLine("Match: " + match.Groups[1].Value);
            return match;
        }
    }
}
