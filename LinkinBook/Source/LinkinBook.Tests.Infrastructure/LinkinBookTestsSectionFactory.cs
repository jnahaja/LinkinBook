using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkinBook.Tests.Infrastructure
{
   public class LinkinBookTestsSectionFactory
    {
        public LinkinBookTestsSection Create()
        {

            var config = (LinkinBookTestsSection)ConfigurationManager.GetSection("linkinBookTests");
            if (config == null)
            {
                var message = @"App.config file missing <linkinBookTests /> element.";
                throw new Exception(message);
            }

            return config;
        }
    }
}
