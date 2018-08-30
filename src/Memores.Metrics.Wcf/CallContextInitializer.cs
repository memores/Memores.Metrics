using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace Memores.Metrics.Wcf
{
    public class CallContextInitializer : ICallContextInitializer
    {
        public object BeforeInvoke(InstanceContext instanceContext, IClientChannel channel, Message message) {
            throw new NotImplementedException();
        }

        public void AfterInvoke(object correlationState) {
            throw new NotImplementedException();
        }
    }
}
