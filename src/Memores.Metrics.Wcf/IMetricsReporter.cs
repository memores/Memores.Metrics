using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memores.Metrics.Wcf.Model;

namespace Memores.Metrics.Wcf
{
    public interface IMetricsReporter {
        void Report(MetricsReport metricsReport);
    }
}
