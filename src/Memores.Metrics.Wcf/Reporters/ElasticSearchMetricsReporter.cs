﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Memores.Metrics.Wcf.Model;
using Memores.Metrics.Wcf.Model.Reports.Base;
using Memores.Metrics.Wcf.Reporters.Counters;
using Nest;

namespace Memores.Metrics.Wcf.Reporters {
    public class ElasticSearchMetricsReporter : IMetricsReporter {
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

            new ElasticSearchRatesCounter(this).Start();
            new ElasticSearchApdexCounter(this).Start();
            new HealthChecker(this).Start();
        }


        public void Report<TReport>(TReport metricsReport) where TReport : MetricsReportBase {
            metricsReport.DateEnd = DateTime.Now;

            _client.Index(metricsReport);
        }

        private ElasticClient GetClient(string host, int port, string index) {
            var settings = new ConnectionSettings(new Uri($"{host}:{port}")).DefaultIndex(index);
            return _client ?? new ElasticClient(settings);
        }

        protected internal ElasticClient GetClient() {
            return _client;
        }
    }
}