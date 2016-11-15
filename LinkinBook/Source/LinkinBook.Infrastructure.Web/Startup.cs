using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkinBook.Infrastructure.Web
{
    public class Startup
    {
        private string _clientDirectory;

        /// <summary>
        /// Creates an Owin Bootstrapper.
        /// </summary>
        /// <param name="clientDirectory">The directory where the static client-side files are stored.</param>
        public Startup(string clientDirectory)
        {
            this._clientDirectory = clientDirectory;
        }

        /// <summary>
        /// Associates this Startup with an Owin IAppBuilder.
        /// </summary>
        public void Configure(IAppBuilder appBuilder)
        {
            // Enable the client.
            var options = new FileServerOptions();
            options.DefaultFilesOptions.DefaultFileNames = new[] { "index.html" };
            var fileSystem = new PhysicalFileSystem(this._clientDirectory);
            options.FileSystem = fileSystem;
            appBuilder.UseFileServer(options);
        }
    }
}
