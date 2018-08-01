using System;
using System.Collections.Generic;
using System.Text;
using Memores.NetAPMAgent.Model;


namespace Memores.NetAPMAgent
{
    /// <summary>
    /// Reports to APM server about transactions, spans and errors
    /// </summary>
    public interface IReporter: IDisposable
    {


        /// <summary>
        /// Sends Transaction to APM server
        /// </summary>
        /// <param name="transaction"></param>
        void Report(Transaction transaction);

        
        /// <summary>
        /// Sends Span to APM server
        /// </summary>
        /// <param name="span"></param>
        void Report(Span span);


        /// <summary>
        /// Sends Error to APM server
        /// </summary>
        /// <param name="error"></param>
        void Report(Error error);
    }
}
