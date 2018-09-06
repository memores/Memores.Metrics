using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Memores.Metrics.Wcf.Model;
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
            var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            var virtualMemoryCounter = new PerformanceCounter("Memory", "Available MBytes");
            

            Task.Factory.StartNew(async (o) => {
                while (true) {
                    _reporter.Report(new HealthCheckReport() {
                        MetricsReportType = MetricsReportTypes.HealthCheck,
                        CpuRate = cpuCounter.NextValue(),
                        AvailableVirtualMemory = virtualMemoryCounter.NextValue()
                    });

                    await Task.Delay(timeout);
                }
            }, TaskCreationOptions.LongRunning, _cancellationTokenSource.Token);
        }

        public void Stop() {
           _cancellationTokenSource.Cancel();
        }
    }
}