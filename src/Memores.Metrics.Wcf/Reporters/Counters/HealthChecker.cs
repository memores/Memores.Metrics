using System;
using System.Threading;
using System.Threading.Tasks;
using Memores.Metrics.Wcf.Model.Reports;

namespace Memores.Metrics.Wcf.Reporters.Counters {
    internal class HealthChecker : ICounter {
        private readonly IMetricsReporter _reporter;
        private CancellationTokenSource _cancellationTokenSource;

        public HealthChecker(IMetricsReporter reporter) {
            _reporter = reporter;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public void Start(int timeout = 1000) {
            Task.Factory.StartNew(async (o) => {
                while (true) {
                    _reporter.Report(new HealthCheckReport());

                    await Task.Delay(timeout);
                }
            }, TaskCreationOptions.LongRunning, _cancellationTokenSource.Token);
        }

        public void Stop() {
           _cancellationTokenSource.Cancel();
        }
    }
}