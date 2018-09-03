using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Memores.Metrics.Wcf.Handlers;

namespace Memores.Metrics.Wcf.Behaviors {
    public class ServiceBehavior : IServiceBehavior {
        private readonly IMetricsReporter _reporter;

        public ServiceBehavior(IMetricsReporter reporter) {
            _reporter = reporter;
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) {
            //do nothing
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters) {
            //do nothing
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) {
            foreach (var channelDispatcherBase in serviceHostBase.ChannelDispatchers) {
                var channelDispatcher = (ChannelDispatcher) channelDispatcherBase;
                channelDispatcher.ErrorHandlers.Add(new ErrorHandler(_reporter));
            }
        }
    }
}
