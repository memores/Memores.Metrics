﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Memores.Metrics.Wcf.Model;

namespace Memores.Metrics.Wcf.Reporters.Counters {
    public class ElasticSearchRatesCounter : RatesCounterBase {
        private ElasticSearchMetricsReporter _elasticSearchMetricsReporter;


        public ElasticSearchRatesCounter(IMetricsReporter reporter) : base(reporter) {
            _elasticSearchMetricsReporter = reporter as ElasticSearchMetricsReporter;
        }

        protected override long GetRate(DateTime currentDateTime, int min) {
            return _elasticSearchMetricsReporter.GetClient().Count<MetricsReport>(c => c
                .Query(q =>
                    q.Match(m => m.Field(f => f.MetricsReportType).Query(((int)MetricsReportTypes.ServiceCall).ToString())) &&
                    q.DateRange(
                        r => r.Field(f => f.DateStart)
                            .GreaterThanOrEquals(currentDateTime.AddMinutes(-min))
                            .LessThan(currentDateTime)
                    ))).Count;
        }
    }
}
