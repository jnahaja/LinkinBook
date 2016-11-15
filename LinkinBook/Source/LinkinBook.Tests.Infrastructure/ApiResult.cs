using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LinkinBook.Tests.Infrastructure
{
    public class ApiResult
    {
        /// <summary>
        /// A response from the Web Server
        /// </summary>
        public HttpResponseMessage Response { get; set; }

        /// <summary>
        /// The Content, read as a string, from the response.
        /// </summary>
        public string ContentString { get; set; }

        /// <summary>
        /// The HTTP StatusCode read from the response.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
    }
}
