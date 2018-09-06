using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memores.Metrics.Wcf.Model.Reports.Base;

namespace Memores.Metrics.Wcf.Model.Reports
{
    public class HealthCheckReport : MetricsReportBase {
        public double AvailablePhysicalMemory { get; set; }
      
      
        public double AvailableVirtualMemory { get; set; }
       

        public float CpuRate { get; set; }
    }
}
