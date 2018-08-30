using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace Memores.Metrics.Wcf {
    public class EndpointBehavior : IEndpointBehavior {
        private readonly IMetricsReporter _reporter;

        public EndpointBehavior(IMetricsReporter reporter) {
            _reporter = reporter;
        }

        public void Validate(ServiceEndpoint endpoint) {
            //do nothing
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters) {
            //do nothing
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher) {
            foreach (var operation in endpointDispatcher.DispatchRuntime.Operations) {
                operation.CallContextInitializers.Add(new CallContextInitializer(_reporter));
            }
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime) {
            //do nothing
        }
    }
}
