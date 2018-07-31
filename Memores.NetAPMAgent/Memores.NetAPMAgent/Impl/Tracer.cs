using System;
using System.Collections.Generic;
using System.Text;
using Memores.NetAPMAgent.Model;


namespace Memores.NetAPMAgent.Impl
{
    public class Tracer: ITracer
    {
        public Transaction StartTransaction() {
            throw new NotImplementedException();
        }


        public Span StartSpan() {
            throw new NotImplementedException();
        }


        public void CaptureException(Exception e) {
            throw new NotImplementedException();
        }
    }
}
