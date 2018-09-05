using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memores.Metrics.Wcf.Model.Reports.Base;

namespace Memores.Metrics.Wcf.Model.Reports
{
    public class HealthCheckReport : MetricsReportBase {
        public long TotalPhysicalMemory { get; set; }
        public long AvailablePhysicalMemory { get; set; }

        public long TotalVirtualMemory { get; set; }
        public long AvailableVirtualMemory { get; set; }

        public long CpuRate { get; set; }
    }
}
