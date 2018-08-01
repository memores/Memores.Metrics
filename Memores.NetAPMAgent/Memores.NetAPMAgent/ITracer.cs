using System;
using System.Collections.Generic;
using System.Text;
using Memores.NetAPMAgent.Model;


namespace Memores.NetAPMAgent {
    /// <summary>
    /// The tracer gives you access to the currently active transaction and span. It can also be used to track an exception.
    /// </summary>
    public interface ITracer {


        /// <summary>
        /// Starts the transaction
        /// </summary>
        /// <returns><see cref="Transaction"/></returns>
        Transaction StartTransaction();


        /// <summary>
        /// Starts the span - part of transaction
        /// </summary>
        /// <param name="transaction"><see cref="Transaction"/></param>
        /// <returns><see cref="Span"/></returns>
        Span StartSpan(Transaction transaction = null);


        /// <summary>
        /// End transaction
        /// </summary>
        /// <param name="transaction"><see cref="Transaction"/></param>
        void EndTransaction(Transaction transaction);


        /// <summary>
        /// End span
        /// </summary>
        /// <param name="span"><see cref="Span"/></param>
        void EndSpan(Span span);

        
        /// <summary>
        /// Capture and trace any exception
        /// </summary>
        /// <param name="e"><exception cref="Exception"></exception></param>
        void CaptureError(Error error);


        void Recycle(Transaction transaction);
        

        void Recycle(Span span);

    }
}