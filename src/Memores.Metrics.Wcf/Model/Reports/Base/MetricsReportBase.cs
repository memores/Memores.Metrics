using System;
using System.Collections.Generic;

namespace Memores.Metrics.Wcf.Model.Reports.Base {
    public class MetricsReportBase {

        public MetricsReportBase() {
            TimeStamp = DateTime.Now;
            DateStart = DateTime.Now;
        }

        public MetricsReportTypes MetricsReportType { get; set; }
        
        public DateTime TimeStamp { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }
        
        public List<Tag> Tags { get; set; }    
    }
}