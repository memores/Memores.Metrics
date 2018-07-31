using System;
using System.Collections.Generic;


namespace Memores.NetAPMAgent.Model {
    /// <summary>
    /// Transaction is the data captured by an agent representing an event occurring in a monitored service and groups multiple spans in a logical group
    /// </summary>
    public abstract class Transaction : IDisposable {

        /// <summary>
        /// Name of the current transaction
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// The type of the transaction
        /// </summary>
        public string Type { get; set; }


        /// <summary>
        /// Information about the user/client
        /// </summary>
        public User User { get; set; }


        /// <summary>
        /// User-defined tags with string values. Note: the tags are indexed in Elasticsearch so that they are searchable and aggregatable
        /// </summary>
        public virtual ICollection<Tag> Tags { get; set; }


        public Transaction(string name, string type) {
            Name = name;
            Type = type;
        }


        /// <summary>
        /// End tracking the transaction
        /// </summary>
        public abstract void End();


        #region IDisposable impl

        public void Dispose() {
            End();
        }

        #endregion
    }
}