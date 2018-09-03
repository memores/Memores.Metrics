using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace Memores.Metrics.Wcf.Handlers {
    internal class ErrorHandler : IErrorHandler {
        private IMetricsReporter _reporter;

        public ErrorHandler(IMetricsReporter reporter) {
            _reporter = reporter;
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault) {
            //do nothing
        }

        public bool HandleError(Exception error) {
            return true;
        }
    }
}
