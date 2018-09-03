using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memores.Metrics.Wcf.Model.Reports.Base;

namespace Memores.Metrics.Wcf.Model.Reports {
    public class ExceptionReport : MetricsReportBase {
        public string Type { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}