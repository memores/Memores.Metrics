using Memores.Metrics.Wcf.Model.Reports.Base;

namespace Memores.Metrics.Wcf.Model.Reports {
    public class OperationReport : MetricsReportBase {
        public string OperationName { get; set; }

        public long ProcessingTime { get; set; }
    }
}