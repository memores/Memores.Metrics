using System;
using System.Collections.Generic;

namespace Memores.Metrics.Wcf.Model {
    public class MetricsReport {

        public MetricsReport() {
            TimeStamp = DateTime.Now;
            DateStart = DateTime.Now;
        }

        public MetricsReportTypes MetricsReportType { get; set; }

        public long Rate1m { get; set; }

        public long Rate5m { get; set; }

        public long Rate15m { get; set; }

        public string OperationName { get; set; }

        public DateTime TimeStamp { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public long ProcessingTime { get; set; }

        public List<Tag> Tags { get; set; }    
    }
}