using Memores.Metrics.Wcf.Model.Reports.Base;

namespace Memores.Metrics.Wcf.Model.Reports {
    public class RatesReport: MetricsReportBase {
        public long Rate1m { get; set; }

        public long Rate5m { get; set; }

        public long Rate15m { get; set; }
    }
}