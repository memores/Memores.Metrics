using System;
using System.Collections.Generic;
using System.Text;
using Memores.NetAPMAgent.Model.Base;


namespace Memores.NetAPMAgent.Model
{
    public class Error : Recyclable
    {
        public Exception Exception { get; set; }

        public override void ResetState() {
            Exception = null;
        }
    }
}
