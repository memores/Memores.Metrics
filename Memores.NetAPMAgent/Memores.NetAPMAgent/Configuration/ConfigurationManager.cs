using System;
using System.Collections.Generic;
using System.Text;
using Memores.NetAPMAgent.Configuration.Model;
using Microsoft.Extensions.Configuration;


namespace Memores.NetAPMAgent.Configuration
{
    class ConfigurationManager
    {
        readonly IConfiguration _configuration;


        public ConfigurationManager(IConfiguration configuration) {
            _configuration = configuration;
        }


        public NetApmAgentConfiguration GetCurrentConfiguration() {
            throw new NotImplementedException();
        }
    }
}
