using Memores.NetAPMAgent.Impl;


namespace Memores.NetAPMAgent
{
    public class TracerBuilder
    {
        IReporter _reporter;


        public ITracer Build(string apmServer = "http://localhost:8200/") {
            if (_reporter == null)
                _reporter = new ReporterFactory().CreateReporter(apmServer);

            return new Tracer(_reporter);
        }
    }
}
