using System;
using Memores.NetAPMAgent;
using Memores.NetAPMAgent.Impl;
using Memores.NetAPMAgent.Model;


namespace NetAPMAgent.ConsoleSample {
    class Program {
        static void Main(string[] args) {
            var tracer = TracerBuilder.Build();

            using (var transaction = tracer.StartTransaction()) {
                using (var span = tracer.StartSpan(transaction)) {
                    span.Name = "Some span #1";
                    span.Type = "Write some line";

                    Console.WriteLine("Hello World!");
                }

                using (var span = tracer.StartSpan(transaction)) {
                    span.Name = "Some span #2";
                    span.Type = "Write some line";

                    Console.WriteLine("Bye World!");
                }

                transaction.Result = "Work done!";
            }
        }
    }
}
