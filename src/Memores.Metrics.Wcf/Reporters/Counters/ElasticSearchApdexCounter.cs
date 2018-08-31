using System;
using Memores.Metrics.Wcf.Model;
using Memores.Metrics.Wcf.Reporters.Counters.Base;

namespace Memores.Metrics.Wcf.Reporters.Counters {
    internal class ElasticSearchApdexCounter : ApdexCounterBase {
        public ElasticSearchApdexCounter(IMetricsReporter reporter) : base(reporter) { }

        protected override long GetApdex(DateTime currentDateTime, int interval, int threshold)
        {
            var client = ((ElasticSearchMetricsReporter) _reporter).GetClient();

            var calls = client.Count<MetricsReport>(c => c
                .Query(q =>
                    q.Match(m => m.Field(f => f.MetricsReportType).Query(((int) MetricsReportTypes.Operation).ToString())) &&
                    q.DateRange(
                        r => r.Field(f => f.DateStart)
                            .GreaterThanOrEquals(currentDateTime.AddMinutes(-interval))
                            .LessThan(currentDateTime)
                    ))).Count;

            var satisfiedCalls = client.Count<MetricsReport>(c => c
                .Query(q =>
                    q.Range(m => m.Field(f => f.ProcessingTime).LessThan(threshold)) &&
                    q.Match(m => m.Field(f => f.MetricsReportType).Query(((int) MetricsReportTypes.Operation).ToString())) &&
                    q.DateRange(
                        r => r.Field(f => f.DateStart)
                            .GreaterThanOrEquals(currentDateTime.AddMinutes(-interval))
                            .LessThan(currentDateTime)
                    ))).Count;

            var toleratedCalls = client.Count<MetricsReport>(c => c
                .Query(q =>
                    q.Range(m => m.Field(f => f.ProcessingTime).LessThan(threshold*4)) &&
                    q.Range(m => m.Field(f => f.ProcessingTime).GreaterThanOrEquals(threshold)) &&
                    q.Match(m => m.Field(f => f.MetricsReportType).Query(((int) MetricsReportTypes.Operation).ToString())) &&
                    q.DateRange(
                        r => r.Field(f => f.DateStart)
                            .GreaterThanOrEquals(currentDateTime.AddMinutes(-interval))
                            .LessThan(currentDateTime)
                    ))).Count;

            return (satisfiedCalls + (toleratedCalls / 2)) / calls;
        }
    }
}