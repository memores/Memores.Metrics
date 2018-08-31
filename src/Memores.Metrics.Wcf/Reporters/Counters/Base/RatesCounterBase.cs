using System;
using System.Threading.Tasks;
using Memores.Metrics.Wcf.Model;

namespace Memores.Metrics.Wcf.Reporters.Counters {
    public abstract class RatesCounterBase {
        private readonly IMetricsReporter _reporter;

        public RatesCounterBase(IMetricsReporter reporter) {
            _reporter = reporter;
        }

        public virtual void Start(int timeout = 1000) {
            Task.Factory.StartNew(async () => {
                while (true) {
                    var currentDateTime = DateTime.Now;

                    var rate1m = GetRate(currentDateTime, 1);
                    var rate5m = GetRate(currentDateTime, 5);
                    var rate15m = GetRate(currentDateTime, 15);

                    _reporter.Report(new MetricsReport() {
                        MetricsReportType = MetricsReportTypes.Rates,
                        Rate1m = rate1m,
                        Rate5m = rate5m,
                        Rate15m = rate15m
                    });

                    await Task.Delay(timeout);
                }
            }, TaskCreationOptions.LongRunning);
        }

        protected abstract long GetRate(DateTime currentDateTime, int min);

        public void Stop() {
            //do nothing
        }
    }
}