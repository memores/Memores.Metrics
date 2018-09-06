using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memores.Metrics.Wcf.Model.Reports.Base;

namespace Memores.Metrics.Wcf.Model.Reports
{
    public class HealthCheckReport : MetricsReportBase {
        public float TotalPhysicalMemory { get; set; }
        public float AvailablePhysicalMemory { get; set; }
        public float PhysicalMemoryRate { get; set; }

        public float TotalVirtualMemory { get; set; }
        public float AvailableVirtualMemory { get; set; }
        public float VirtualMemoryRate { get; set; }

        public float CpuRate { get; set; }
    }
}
