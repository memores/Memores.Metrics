using Memores.NetAPMAgent.Configuration.Model;

namespace Memores.NetAPMAgent.Configuration
{
    public interface IConfigurationManager
    {
        NetApmAgentConfiguration GetCurrentConfiguration();
    }
}