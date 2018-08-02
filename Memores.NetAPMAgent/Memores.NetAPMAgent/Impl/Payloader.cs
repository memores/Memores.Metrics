using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Memores.NetAPMAgent.Contracts;


namespace Memores.NetAPMAgent.Impl
{
    public class Payloader : IPayloader
    {
        readonly HttpClient _client;


        public Payloader(HttpClient client) {
            _client = client;
        }
        public void SendPayload(Payload payload) {
            throw new NotImplementedException();
        }
    }
}
