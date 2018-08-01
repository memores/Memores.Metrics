using System;
using System.Collections.Generic;
using Memores.NetAPMAgent.Model.Base;


namespace Memores.NetAPMAgent.Model {
    /// <summary>
    /// Transaction is the data captured by an agent representing an event occurring in a monitored service and groups multiple spans in a logical group
    /// </summary>
    public class Transaction : TrackingObject, IDisposable {
        readonly ITracer _tracer;

        /// <summary>
        /// Information about the user/client
        /// </summary>
        public User User { get; set; }


        /// <summary>
        /// User-defined tags with string values. Note: the tags are indexed in Elasticsearch so that they are searchable and aggregatable
        /// </summary>
        public virtual ICollection<Tag> Tags { get; set; }

        /// <summary>
        /// Span elements, which contains information about transaction parts
        /// </summary>
        public virtual ICollection<Span> Spans { get; set; }


        public Transaction(ITracer tracer) {
            _tracer = tracer;
        }


        /// <summary>
        /// Start transaction
        /// </summary>
        /// <returns></returns>
        protected Transaction Start(Transaction transaction) {
            Id = Guid.NewGuid();
            DateStart = DateTime.UtcNow;

            return this;
        }


        /// <inheritdoc />
        internal override TrackingObject Start(TrackingObject trackingObject = null) {
            return Start(trackingObject);
        }


        /// <summary>
        /// End tracking the transaction
        /// </summary>
        internal override void End() {
            DateEnd = DateTime.UtcNow;
            _tracer.EndTransaction(this);
        }


        public void AddTag() {
            
        }


        public void AddSpan() {
            
        }


        #region IDisposable impl

        public void Dispose() {
            End();
        }

        #endregion
    }
}