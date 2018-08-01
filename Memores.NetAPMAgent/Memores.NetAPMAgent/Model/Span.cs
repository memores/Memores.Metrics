using System;
using Memores.NetAPMAgent.Model.Base;


namespace Memores.NetAPMAgent.Model {
    /// <summary>
    /// Span contains information about a specific code path, executed as part of a transaction
    /// </summary>
    public class Span : TrackingObject, IDisposable {
        readonly ITracer _tracer;
  
        public Guid TransactionId { get; set; }


        public Span(ITracer tracer) {
            _tracer = tracer;
        }
        

        protected Span Start(Transaction transaction) {
            Id = Guid.NewGuid();
            TransactionId = transaction.Id;
            DateStart = DateTime.UtcNow;
            return this;
        }


        internal override TrackingObject Start(TrackingObject trackingObject = null) {
            return Start(trackingObject);
        }


        internal override void End() {
            DateEnd = DateTime.UtcNow;
            _tracer.EndSpan(this);
        }
        
        
        #region IDisposable impl

        public void Dispose() {
            End();
        }

        #endregion


        public override void ResetState() {
            base.ResetState();

            TransactionId = default(Guid);
        }
    }
}
