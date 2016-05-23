using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LinkinBook.Tests.Infrastructure
{
    public abstract class E2ETestBase
    {
        public StartupInstance Instance { get; private set; }
        /// <summary>
        /// Sets up the end-to-end test.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            var port = 12345;
            this.Instance = new StartupInstance(port);
            this.Instance.Start();
        }
        [TearDown]
        public void TearDown()
        {
            if (this.Instance != null)
            {
                this.Instance.Dispose();
            }
        }
    }
}
