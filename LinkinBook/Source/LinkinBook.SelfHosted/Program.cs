﻿
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkinBook.Infrastructure.Web;

namespace LinkinBook.SelfHosted
{
 public class Program
    {
        public static void Main(string[] args)
        {
            var config = new LinkinBookWebSectionFactory().Create();
           //var clientDirectoryInfo = GetCurrentClientDirectoryName(Directory.GetCurrentDirectory());

           // if (clientDirectoryInfo == null)
           // {
           //     throw new System.ArgumentException("There is a problem to get Path for Web Client");

           // }

           // var clientDirectory = Path.Combine(clientDirectoryInfo, "Client");

           // var port = 1234;
            
            var startup = new Startup(config.ClientDirectory);

            using (WebApp.Start(
                "http://localhost:" + config.Port,
                appBuilder => startup.Configure(appBuilder)))
            {
                Console.WriteLine("Web Server is running.");
                Console.WriteLine("Press any key to quit.");
                Console.ReadLine();
            }
        }
        private static string GetCurrentClientDirectoryName(string currentPath)
        {
            var directoryName = string.Empty;
            var directory = new DirectoryInfo( currentPath ?? Directory.GetCurrentDirectory());
            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }

            if (directory != null && Directory.Exists(Path.Combine(directory.FullName,"Source"))){
                directoryName = Path.Combine(directory.FullName, "Source");
            }

            return directoryName;
        }
    }
}
