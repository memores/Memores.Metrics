using System;
using System.Collections.Generic;
using System.Text;
using Memores.NetAPMAgent.Model;


namespace Memores.NetAPMAgent
{
    /// <summary>
    /// The tracer gives you access to the currently active transaction and span. It can also be used to track an exception.
    /// </summary>
    public interface ITracer {
        Transaction StartTransaction();

        Span StartSpan(Transaction transaction = null);

        void EndTransaction(Transaction transaction);

        void EndSpan(Span span); 

        void CaptureException(Exception e);
    }
}
