using System;
using System.Collections.Generic;
using System.Text;
using Memores.NetAPMAgent.Model;


namespace Memores.NetAPMAgent.Impl
{
    public class Tracer: ITracer {
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
            transaction.End();
            _reporter.Report(transaction);
        }


        public void EndSpan(Span span) {
            span.End();
            _reporter.Report(span);
        }


        public void CaptureException(Exception e) {
            _reporter.Report(new Error() {Exception = e});
        }
    }
}
