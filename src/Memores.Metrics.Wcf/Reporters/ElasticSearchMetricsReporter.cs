using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Memores.Metrics.Wcf.Model;
using Nest;

namespace Memores.Metrics.Wcf.Reporters {
    class ElasticSearchMetricsReporter : IMetricsReporter {
        private static readonly object lockObject = new object();
        private static volatile ElasticSearchMetricsReporter _reporter;

        private readonly ElasticClient _client;

        public static ElasticSearchMetricsReporter GetReporter(string host = "http://localhost", int port = 9200, string index = "default") {
            if (_reporter == null)
                lock (lockObject) {
                    if (_reporter == null)
                        _reporter = new ElasticSearchMetricsReporter(host, port, index);
                }

            return _reporter;
        }

        private ElasticSearchMetricsReporter(string host, int port, string index) {
            _client = GetClient(host, port, index);

            StartRatesCalculating();
        }




        public void Report(MetricsReport metricsReport) {
            metricsReport.DateEnd = DateTime.Now;

            _client.Index(metricsReport);
        }



        void StartRatesCalculating(int timeout = 1000) {
            Task.Factory.StartNew(async () => {
                while (true)
                {
                    var currentDateTime = DateTime.Now;
                    //todo: bug in query (calculates all elastic elements)
                    var rate1m = _client.Count<MetricsReport>(c => c
                        .Query(q =>
                            q.DateRange(
                                r => r.Field(f => f.DateStart)
                                    .GreaterThanOrEquals(currentDateTime.AddMinutes(-1))
                                    .LessThan(currentDateTime)
                            ))).Count;
                    var rate5m = _client.Count<MetricsReport>(c => c
                        .Query(q =>
                            q.DateRange(
                                r => r.Field(f => f.DateStart)
                                    .GreaterThanOrEquals(currentDateTime.AddMinutes(-5))
                                    .LessThan(currentDateTime)
                            ))).Count;
                    var rate15m = _client.Count<MetricsReport>(c => c
                        .Query(q =>
                            q.DateRange(
                                r => r.Field(f => f.DateStart)
                                    .GreaterThanOrEquals(currentDateTime.AddMinutes(-15))
                                    .LessThan(currentDateTime)
                            ))).Count;

                    Report(new MetricsReport() {
                        OperationName = "RatesCalculator",
                        Rate1m = rate1m,
                        Rate5m = rate5m,
                        Rate15m = rate15m,
                    });

                    await Task.Delay(timeout);
                }
            }, TaskCreationOptions.LongRunning);
        }


        ElasticClient GetClient(string host, int port, string index) {
           var settings = new ConnectionSettings(new Uri($"{host}:{port}")).DefaultIndex(index);
           return new ElasticClient(settings);
       }
    }
}