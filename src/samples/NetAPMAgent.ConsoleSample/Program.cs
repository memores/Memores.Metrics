using System;
using Memores.NetAPMAgent;
using Memores.NetAPMAgent.Impl;
using Memores.NetAPMAgent.Model;


namespace NetAPMAgent.ConsoleSample {
    class Program {
        static void Main(string[] args) {
            //get the ITracer
            var tracer = new TracerBuilder().Build();

            //start transaction
            using (var transaction = tracer.StartTransaction()) {
                //start span of transaction
                using (var span = tracer.StartSpan(transaction)) {
                    span.Name = "Some span #1";
                    span.Type = "Write some line";

                    //do some work
                    Console.WriteLine("Hello World!");
                }

                //start span of transaction
                using (var span = tracer.StartSpan(transaction)) {
                    span.Name = "Some span #2";
                    span.Type = "Write some line";

                    //do some work
                    Console.WriteLine("Bye World!");
                }

                //set transaction result
                transaction.Result = "Work done!";
            }
        }
    }
}
