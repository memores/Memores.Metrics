using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace Memores.Metrics.Wcf.Handlers {
    [Obsolete("Dosn`t implemented in current version")]
    internal class ErrorHandler : IErrorHandler {
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault) {
            throw new NotImplementedException();
        }

        public bool HandleError(Exception error) {
            throw new NotImplementedException();
        }
    }
}
