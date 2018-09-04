using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using Memores.Metrics.Wcf.Model;
using Memores.Metrics.Wcf.Model.Reports;

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
            var type = error.GetType();
            _reporter.Report(new ExceptionReport() {
                MetricsReportType = MetricsReportTypes.Exception,
                ExceptionType = type.FullName,
                Message = error.Message,
                StackTrace = error.StackTrace
            });
            return true;
        }
    }
}
