using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using Memores.Metrics.Wcf.Model;

namespace Memores.Metrics.Wcf
{
    public class CallContextInitializer : ICallContextInitializer
    {
        private readonly IMetricsReporter _reporter;
        private MetricsReport _callContextMetricsReport;

        public CallContextInitializer(IMetricsReporter reporter) {
            _reporter = reporter;
        }

        public object BeforeInvoke(InstanceContext instanceContext, IClientChannel channel, Message message) {
            _callContextMetricsReport = new MetricsReport() {
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
