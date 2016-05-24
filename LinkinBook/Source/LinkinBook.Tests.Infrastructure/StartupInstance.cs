﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LinkinBook.Infrastructure.Web;
using System.IO;
using Microsoft.Owin.Hosting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Protractor;
using System.Net.Http;

namespace LinkinBook.Tests.Infrastructure
{
    public class StartupInstance : IDisposable
    {
        private IDisposable _server;
        private string _baseAddress;
        private NgWebDriver _ngDriver;
        private ChromeDriver _driver;

        const string url = "https://docs.angularjs.org/api";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="port"></param>
        public StartupInstance(int port)
        {
            this._baseAddress = "http://localhost:" + port;
        }
        /// <summary>
        /// Starts this StartupInstance OWIN Self-Hosted Web Server.        
        /// </summary>
        public void Start()
        {
            var clientDirectoryInfo = LinkinBook.Helpers.Helpers.GetCurrentClientDirectoryName(Directory.GetCurrentDirectory());

            if (clientDirectoryInfo == null)
            {
                throw new System.ArgumentException("There is a problem to get Path for Web Client");

            }
            var clientDirectory = Path.Combine(clientDirectoryInfo, "Client");
            var startup = new Startup(clientDirectory);

            this._server = WebApp.Start(this._baseAddress, appBuilder => startup.Configure(appBuilder));


            this._driver = new ChromeDriver(@"C:\Users\jelena.nahaja\Downloads\EXEFiles");
            this._ngDriver = new NgWebDriver(_driver);


        }
        /// <summary>
        /// GetAsync method that performs an HTTP GET request
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<ApiResult> GetAsync(string url)
        {
            using (var client = new HttpClient()
            {
                BaseAddress = new Uri(this._baseAddress)
            })
            {
                var response = await client.GetAsync(url);

                var result = new ApiResult();
                result.Response = response;
                result.ContentString = await response.Content.ReadAsStringAsync();
                result.StatusCode = response.StatusCode;
                return result;
            }

        }
        public void Dispose()
        {
            if (this._server != null)
            {
                this._server.Dispose();
            }
            if (this._ngDriver != null)
            {
                this._ngDriver.Dispose();
            }

        }

    }
}
