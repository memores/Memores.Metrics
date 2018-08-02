using System;
using System.Collections.Generic;
using System.Text;
using Memores.NetAPMAgent.Contracts;


namespace Memores.NetAPMAgent
{
    public interface IPayloader {
        void SendPayload(Payload payload);
    }
}
