using System;
using System.Threading.Tasks;
using Memores.Metrics.Wcf.Model;

namespace Memores.Metrics.Wcf.Reporters.Counters.Base {
    public abstract class ApdexCounterBase : ICounter {
        protected readonly IMetricsReporter _reporter;

        protected ApdexCounterBase(IMetricsReporter reporter) {
            _reporter = reporter;
        }

        public void Start(int timeout = 1000) {
            Task.Factory.StartNew(async () => {
                while (true) {
                    var currentDateTime = DateTime.Now;

                    _reporter.Report(new MetricsReport() {
                        MetricsReportType = MetricsReportTypes.Apdex,
                        Apdex = GetApdex(currentDateTime, 1, 500)
                    });

                    await Task.Delay(timeout);
                }
            }, TaskCreationOptions.LongRunning);
        }

        protected abstract long GetApdex(DateTime currentDateTime, int interval, int threshold);

        public void Stop() {
            //do nothing
        }
    }
}
