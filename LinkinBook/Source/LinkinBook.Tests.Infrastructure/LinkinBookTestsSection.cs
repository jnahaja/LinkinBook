using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkinBook.Tests.Infrastructure
{
   public class LinkinBookTestsSection : ConfigurationSection
    {

        [ConfigurationProperty("buildDirectory", IsRequired = true)]
        public string BuildDirectory
        {
            get
            {
                //var buildDirectory = (string)this["buildDirectory"];

                //var buildDirectoryInfo = GetCurrentBuildDirectoryName(Directory.GetCurrentDirectory());

                //var result = Path.Combine(buildDirectoryInfo, buildDirectory);

                //if (!Directory.Exists(result))
                //{
                //    throw new Exception(@"Invalid buildDirectory on App.config file <vagueBookTests /> element");
                //}
                //return result;
                var clientDirectory = (string)this["buildDirectory"];
                var result = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, clientDirectory);
                if (!Directory.Exists(result))
                {
                    throw new Exception(@"Invalid buildDirectory on App.config file <vagueBookTests /> element");
                }
                return result;
            }
            set
            {
                this["buildDirectory"] = value;
            }
        }
        //private static string GetCurrentBuildDirectoryName(string currentPath)
        //{
        //    var config = new LinkinBookTestsSectionFactory().Create();

        //    var directoryName = string.Empty;
        //    var directory = new DirectoryInfo(currentPath ?? Directory.GetCurrentDirectory());
        //    while (directory != null && !directory.GetFiles("*.sln").Any())
        //    {
        //        directory = directory.Parent;
        //    }

        //    if (directory != null && Directory.Exists(Path.Combine(directory.FullName, config.BuildDirectory)))
        //    {
        //        directoryName = Path.Combine(directory.FullName, config.BuildDirectory);
        //    }

        //    return directoryName;
        //}
    }
}
