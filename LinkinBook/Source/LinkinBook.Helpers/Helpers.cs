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
        public static string GetCurrentClientDirectoryName(string currentPath)
        {
            var directoryName = string.Empty;
            var directory = new DirectoryInfo(currentPath ?? Directory.GetCurrentDirectory());
            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }

            if (Directory.Exists(Path.Combine(directory.FullName, "Source")))
            {
                directoryName = Path.Combine(directory.FullName, "Source");
            }

            return directoryName;
        }
    }
}
