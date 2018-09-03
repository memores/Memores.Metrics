using System;
using System.Threading;
using System.Threading.Tasks;
using Memores.Metrics.Wcf.Model;
using Memores.Metrics.Wcf.Model.Reports;

namespace Memores.Metrics.Wcf.Reporters.Counters.Base {
    public abstract class RatesCounterBase : ICounter {
        protected readonly IMetricsReporter _reporter;
        private CancellationTokenSource _cancellationTokenSource;

        public RatesCounterBase(IMetricsReporter reporter) {
            _reporter = reporter;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public void Start(int timeout = 1000) {
            Task.Factory.StartNew(async (o) => {
                while (true) {
                    var currentDateTime = DateTime.Now;

                    var rate1m = GetRate(currentDateTime, 1);
                    var rate5m = GetRate(currentDateTime, 5);
                    var rate15m = GetRate(currentDateTime, 15);

                    _reporter.Report(new RatesReport() {
                        MetricsReportType = MetricsReportTypes.Rates,
                        Rate1m = rate1m,
                        Rate5m = rate5m,
                        Rate15m = rate15m
                    });

                    await Task.Delay(timeout);
                }
            }, TaskCreationOptions.LongRunning, _cancellationTokenSource.Token);
        }

        protected abstract long GetRate(DateTime currentDateTime, int min);

        public void Stop() {
            _cancellationTokenSource.Cancel();
        }
    }
}