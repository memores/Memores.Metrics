using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Memores.Metrics.Wcf.Handlers;

namespace Memores.Metrics.Wcf.Behaviors {
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
                operation.ParameterInspectors.Add(new ParametersInspector(_reporter));
            }
        }


        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime) {
            //do nothing
        }
    }
}
