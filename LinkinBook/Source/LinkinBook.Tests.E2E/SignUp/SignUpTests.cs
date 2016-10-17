using LinkinBook.Tests.Infrastructure;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LinkinBook.Tests.E2E.SignUp
{
    public class SignUpTests : E2ETestBase
    {
        [Test, Requirement("1234")]
        public async Task BaseAddressShouldReturnOk()
        {
            // Act
            var result = await this.Instance.GetAsync("/");

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(result.ContentString, Does.StartWith(@"<!DOCTYPE html>"));
        }
    }
}
