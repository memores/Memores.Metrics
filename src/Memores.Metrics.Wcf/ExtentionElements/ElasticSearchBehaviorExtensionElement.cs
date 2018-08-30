using System;
using System.Configuration;
using System.ServiceModel.Configuration;
using Memores.Metrics.Wcf.Reporters;

namespace Memores.Metrics.Wcf.ExtentionElements {
    public class ElasticSearchBehaviorExtensionElement : BehaviorExtensionElement {

        [ConfigurationProperty("hostname", IsRequired = true)]
        public string Hostname => (string) base["hostname"];

        [ConfigurationProperty("port", DefaultValue = 9200)]
        public int Port => (int) base["port"];

        [ConfigurationProperty("index")]
        public string Index => (string) base["index"];


        public override Type BehaviorType => typeof(EndpointBehavior);

        protected override object CreateBehavior() {
            return new EndpointBehavior(ElasticSearchMetricsReporter.GetReporter(Hostname, Port, Index));
        }
    }
}
