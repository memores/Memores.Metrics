using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using Memores.NetAPMAgent.Configuration;
using Memores.NetAPMAgent.Contracts;
using Memores.NetAPMAgent.Model;


namespace Memores.NetAPMAgent.Impl {
    public class Reporter : IReporter {
        readonly IPayloader _payloader;
        readonly IConfigurationManager _configurationManager;

        readonly ConcurrentDictionary<Guid, List<Span>> _spansToPayload;
        readonly object _lockObject = new object();


        public Reporter(IPayloader payloader, IConfigurationManager configurationManager) {
            _payloader = payloader;
            _configurationManager = configurationManager;
            _spansToPayload = new ConcurrentDictionary<Guid, List<Span>>();
        }


        public void Report(Transaction transaction) {
            var configuration = _configurationManager.GetCurrentConfiguration();

            Payload payload = new Payload() {
                Service = configuration.Service,
                Process = configuration.Process,
                SystemInfo = configuration.SystemInfo,
                Transactions = new[] {transaction}
            };

            List<Span> spans;
            lock (_lockObject) {
                if (!_spansToPayload.TryGetValue(transaction.Id, out spans)) {
                    _payloader.SendPayload(payload);
                    return;
                }
            }

            foreach (var span in spans) {
                transaction.AddSpan(span);
            }

            _payloader.SendPayload(payload);
        }


        public void Report(Span span) {
            lock (_lockObject) {
                if (!_spansToPayload.TryGetValue(span.TransactionId, out var spans)) {
                    _spansToPayload.TryAdd(span.TransactionId, new List<Span>() {span});
                    return;
                }

                spans.Add(span);
                _spansToPayload[span.TransactionId] = spans;
            }
        }


        public void Report(Error error) {
            throw new NotSupportedException();
        }
    }
}
