using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memores.Metrics.Wcf
{
    public interface IMetricsReporter {
        void Report(MetricsReport metricsReport);
    }
}
