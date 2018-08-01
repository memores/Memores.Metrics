using System;
using System.Collections.Generic;
using System.Text;
using Memores.NetAPMAgent.Model;


namespace Memores.NetAPMAgent.Impl
{
    public class Tracer: ITracer {
        ObjectPool<Transaction> transactionsPool;
        ObjectPool<Span> spansPool;


        public Tracer() {
            transactionsPool = new ObjectPool<Transaction>(() => new Transaction(this));
            spansPool = new ObjectPool<Span>(() => new Span(this));
        }


        public Transaction StartTransaction() {
            return transactionsPool.GetObject().Start();
        }


        public Span StartSpan(Transaction transaction = null) {
            return spansPool.GetObject().Start(transaction);
        }


        public void EndTransaction(Transaction transaction) {
            throw new NotImplementedException();
        }


        public void EndSpan(Span span) {
            throw new NotImplementedException();
        }


        public void CaptureException(Exception e) {
            throw new NotImplementedException();
        }
    }
}
