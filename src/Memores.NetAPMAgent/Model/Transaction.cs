﻿using System;
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
        /// Result of transaction
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// User-defined tags with string values. Note: the tags are indexed in Elasticsearch so that they are searchable and aggregatable
        /// </summary>
        public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();


        /// <summary>
        /// Span elements, which contains information about transaction parts
        /// </summary>
        public virtual ICollection<Span> Spans { get; set; } = new List<Span>();


        public Transaction(ITracer tracer) {
            _tracer = tracer;
        }


        /// <summary>
        /// Start transaction
        /// </summary>
        /// <returns></returns>
        protected Transaction Start() {
            Id = Guid.NewGuid();
            DateStart = DateTime.UtcNow;
            return this;
        }
        

        /// <inheritdoc />
        internal override TrackingObject Start(TrackingObject trackingObject = null) {
            return Start();
        }


        /// <summary>
        /// End tracking the transaction
        /// </summary>
        internal override void End() {
            DateEnd = DateTime.UtcNow;
            _tracer.EndTransaction(this);
        }


        public void AddTag(Tag tag) {
           Tags.Add(tag);
        }


        public void AddSpan(Span span) {
            Spans.Add(span);
        }


        #region IDisposable impl

        public void Dispose() {
            End();
        }

        #endregion


        public override void ResetState() {
            base.ResetState();

            User = null;
            Tags.Clear();
            Spans.Clear();
        }


        public void Recycle(Transaction transaction) {
            _tracer.Recycle(transaction);
        }
    }
}