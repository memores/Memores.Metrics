using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel.Dispatcher;
using Memores.Metrics.Wcf.Model;
using Memores.Metrics.Wcf.Model.Reports;

namespace Memores.Metrics.Wcf.Handlers {
    internal class ParametersInspector : IParameterInspector {
        private readonly IMetricsReporter _reporter;
        private OperationReport _paramatersInspectorMetricsReport;
        private Stopwatch _stopwatch;

        public ParametersInspector(IMetricsReporter reporter) {
            _reporter = reporter;
        }

        public object BeforeCall(string operationName, object[] inputs) {
            _stopwatch = Stopwatch.StartNew();

            _paramatersInspectorMetricsReport = new OperationReport() {
                OperationName = operationName,
                MetricsReportType = MetricsReportTypes.Operation,
                Tags = new List<Tag>() {
                    new Tag() {
                        Key = TagsKeyTypes.SourceName.ToString(),
                        Value = nameof(ParametersInspector)
                    }
                }
            };

            return null;
        }

        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState) {
            _stopwatch.Stop();
            _paramatersInspectorMetricsReport.ProcessingTime = _stopwatch.ElapsedMilliseconds;
            _reporter.Report(_paramatersInspectorMetricsReport);
        }
    }
}
