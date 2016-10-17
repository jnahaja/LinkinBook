using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkinBook.Helpers
{
    public class Helpers
    {
        public static string GetCurrentDirectoryName(string currentPath, string dirName)
        {
            var directoryName = string.Empty;
            var directory = new DirectoryInfo(currentPath ?? Directory.GetCurrentDirectory());
            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }
            if (directory == null) return directoryName;

            if (dirName == "build" && Directory.Exists(Path.Combine(directory.FullName, "Build")))
            {
                directoryName = directory.FullName;
            }
            if (dirName =="client" && Directory.Exists(Path.Combine(directory.FullName, "Source")))
            {
                directoryName = Path.Combine(directory.FullName, "Source");
            }

            return directoryName;
        }
    }
}
