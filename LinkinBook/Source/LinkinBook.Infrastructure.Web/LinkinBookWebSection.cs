using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace LinkinBook.Infrastructure.Web
{
    public class LinkinBookWebSection : ConfigurationSection
    {

        [ConfigurationProperty("port", IsRequired = true)]
        public int Port
        {
            get
            {
                var result = (int)this["port"];
                return result;
            }
            set
            {
                this["port"] = value;
            }
        }

        [ConfigurationProperty("clientDirectory", IsRequired = true)]
        public string ClientDirectory
        {
            get
            {
                var clientDirectory = (string)this["clientDirectory"];
                var result = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, clientDirectory);
                if (!Directory.Exists(result))
                {
                    throw new Exception(@"Invalid clientDirectory on App.config file <linkinBookWeb /> element");
                }
                return result;
            }
            set
            {
                this["clientDirectory"] = value;
            }
        }
    }
}
