using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memores.Metrics.Wcf.Model;
using Memores.Metrics.Wcf.Model.Reports.Base;

namespace Memores.Metrics.Wcf
{
    public interface IMetricsReporter {
        void Report(MetricsReportBase metricsReport);
    }
}
