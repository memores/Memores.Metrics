using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Memores.Metrics.Wcf.Model;
using Memores.Metrics.Wcf.Model.Reports;

namespace Memores.Metrics.Wcf.Handlers {
    internal class CallContextInitializer : ICallContextInitializer {
        private readonly IMetricsReporter _reporter;
        private ServiceCallReport _callContextMetricsReport;

        public CallContextInitializer(IMetricsReporter reporter) {
            _reporter = reporter;
        }

        public object BeforeInvoke(InstanceContext instanceContext, IClientChannel channel, Message message) {
            _callContextMetricsReport = new ServiceCallReport() {
                MetricsReportType = MetricsReportTypes.ServiceCall,
                Tags = new List<Tag>() {
                    new Tag() {
                        Key = TagsKeyTypes.SourceName.ToString(),
                        Value = nameof(CallContextInitializer)
                    }
                }
            };

            return null;
        }

        public void AfterInvoke(object correlationState) {
            _reporter.Report(_callContextMetricsReport);
        }
    }
}
