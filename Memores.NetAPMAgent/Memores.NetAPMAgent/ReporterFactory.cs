using System.Net.Http;
using Memores.NetAPMAgent.Configuration;
using Memores.NetAPMAgent.Impl;


namespace Memores.NetAPMAgent {
    public class ReporterFactory {
        public IReporter CreateReporter(string apmServer) {
            var payloader = GetPayloader(apmServer);
            var configurationManager = GetConfigurationManager();

            return new Reporter(payloader, configurationManager);
        }


        IConfigurationManager GetConfigurationManager() {
            return new NetApmAgentConfigurationManager();
        }


        IPayloader GetPayloader(string apmServer) {
            return new Payloader(new HttpClient(), apmServer);
        }
    }
}