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
        public Transaction Start() {
            Id = Guid.NewGuid();
            return this;
        }


        /// <summary>
        /// End tracking the transaction
        /// </summary>
        public override void End() {
            _tracer.EndTransaction(this);
        }


        #region IDisposable impl

        public void Dispose() {
            End();
        }

        #endregion
    }
}