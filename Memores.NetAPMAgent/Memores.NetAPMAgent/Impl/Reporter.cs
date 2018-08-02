using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using Memores.NetAPMAgent.Contracts;
using Memores.NetAPMAgent.Model;


namespace Memores.NetAPMAgent.Impl {
    public class Reporter : IReporter {
        readonly IPayloader _payloader;

        readonly ConcurrentDictionary<Guid, List<Span>> _spansToPayload;
        readonly object _lockObject = new object();

        public Reporter(IPayloader payloader) {
            _payloader = payloader;
            _spansToPayload = new ConcurrentDictionary<Guid, List<Span>>();
        }


        public void Report(Transaction transaction) {
            List<Span> spans;
            lock (_lockObject) {
                if (!_spansToPayload.TryGetValue(transaction.Id, out spans)) {
                    _payloader.SendPayload(new Payload() {Transactions = new[] {transaction}});
                    return;
                }
            }

            foreach (var span in spans) {
                transaction.AddSpan(span);
            }

            _payloader.SendPayload(new Payload() {
                Transactions = new[] {transaction}
            });
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
            throw new NotImplementedException();
        }
    }
}
