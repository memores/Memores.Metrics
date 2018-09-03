using System;
using System.Threading;
using System.Threading.Tasks;
using Memores.Metrics.Wcf.Model;

namespace Memores.Metrics.Wcf.Reporters.Counters.Base {
    public abstract class ApdexCounterBase : ICounter {
        protected readonly IMetricsReporter _reporter;
        private CancellationTokenSource _cancellationTokenSource;

        protected ApdexCounterBase(IMetricsReporter reporter) {
            _reporter = reporter;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public void Start(int timeout = 1000) {
            Task.Factory.StartNew(async (o) => {
                while (true) {
                    var currentDateTime = DateTime.Now;

                    _reporter.Report(new MetricsReport() {
                        MetricsReportType = MetricsReportTypes.Apdex,
                        Apdex = GetApdex(currentDateTime, 1, 500)
                    });

                    await Task.Delay(timeout);
                }
            }, TaskCreationOptions.LongRunning, _cancellationTokenSource.Token);
        }

        protected abstract long GetApdex(DateTime currentDateTime, int interval, int threshold);

        public void Stop() {
            _cancellationTokenSource.Cancel();
        }
    }
}
