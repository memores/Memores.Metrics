using System.Net.Http;
using System.Text;
using System.Threading;
using Memores.NetAPMAgent.Contracts;
using Newtonsoft.Json;


namespace Memores.NetAPMAgent.Impl {
    public class Payloader : IPayloader {
        readonly HttpClient _client;
        readonly string _apmServer;


        public Payloader(HttpClient client, string apmServer) {
            _client = client;
            _apmServer = apmServer;
        }


        public async void SendPayload(Payload payload) {
            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{_apmServer}/v1/transactions", content, default(CancellationToken)); //todo: add response processing
        }
    }
}