using Memores.NetAPMAgent.Configuration.Model;

namespace Memores.NetAPMAgent.Configuration
{
    interface IConfigurationManager
    {
        NetApmAgentConfiguration GetCurrentConfiguration();
    }
}