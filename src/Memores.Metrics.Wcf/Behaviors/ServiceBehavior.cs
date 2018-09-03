using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace Memores.Metrics.Wcf.Behaviors {
    public class ServiceBehavior : IServiceBehavior {
        [Obsolete("Dosn`t implemented in current version")]
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) {
            //do nothing
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters) {
            //do nothing
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) {
            throw new NotImplementedException();
        }
    }
}
