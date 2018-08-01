using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Memores.NetAPMAgent.Model;


namespace Memores.NetAPMAgent.Impl {
    public class Tracer : ITracer {
        readonly IReporter _reporter;

        readonly ObjectPool<Transaction> _transactionsPool;
        readonly ObjectPool<Span> _spansPool;


        public Tracer(IReporter reporter) {
            _reporter = reporter;

            _transactionsPool = new ObjectPool<Transaction>(() => new Transaction(this));
            _spansPool = new ObjectPool<Span>(() => new Span(this));
        }


        public Transaction StartTransaction() {
            return _transactionsPool.GetObject().Start() as Transaction;
        }


        public Span StartSpan(Transaction transaction = null) {
            return _spansPool.GetObject().Start(transaction) as Span;
        }


        public void EndTransaction(Transaction transaction) {
            try {
                _reporter.Report(transaction);
            }
            catch (Exception e) {
                Debug.Write(e);
                throw;
            }
            finally {
                transaction.Recycle(transaction);
            }
        }


        public void EndSpan(Span span) {
            try {
                _reporter.Report(span);
            }
            catch (Exception e) {
                Debug.Write(e);
                throw;
            }
            finally {
                span.Recycle(span);
            }
        }


        public void CaptureError(Error error) {
            _reporter.Report(error);
        }


        public void Recycle(Span span) {
            _spansPool.Recycle(span);
        }


        public void Recycle(Transaction transaction) {
            foreach (var span in transaction.Spans) {
                _spansPool.Recycle(span);
            }
            _transactionsPool.Recycle(transaction);
        }

    }
}