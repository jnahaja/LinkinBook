using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkinBook.Infrastructure.Web
{
    public class LinkinBookWebSectionFactory
    {
        public LinkinBookWebSection Create()
        {
            var config = (LinkinBookWebSection)ConfigurationManager.GetSection("linkinBookWeb");
            if (config == null)
            {
                var message = @"App.config file missing <linkinBookWeb /> element.";
                throw new Exception(message);
            }

            return config;
        }
    }
}
