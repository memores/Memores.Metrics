using System;
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
        }




        public void Report(MetricsReport metricsReport) {
            throw new NotImplementedException();
        }


       ElasticClient GetClient(string host, int port, string index) {
           var settings = new ConnectionSettings(new Uri($"{host}:{port}")).DefaultIndex(index);
           return new ElasticClient(settings);
       }
    }
}