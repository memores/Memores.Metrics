using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Memores.NetAPMAgent.Model;


namespace Memores.NetAPMAgent.Impl {
    public class HttpReporter : IReporter {
        readonly HttpClient _httpClient;


        public HttpReporter(HttpClient httpClient) {
            _httpClient = httpClient;
        }


        public void Dispose() {
            throw new NotImplementedException();
        }


        public void Report(Transaction transaction) {
            throw new NotImplementedException();
        }


        public void Report(Span span) {
            throw new NotImplementedException();
        }


        public void Report(Error error) {
            throw new NotImplementedException();
        }
    }
}
