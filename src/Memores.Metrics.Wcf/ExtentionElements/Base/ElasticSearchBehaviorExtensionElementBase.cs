using System;
using System.Configuration;
using System.ServiceModel.Configuration;
using Memores.Metrics.Wcf.Reporters;

namespace Memores.Metrics.Wcf.ExtentionElements.Base {
    public abstract class ElasticSearchBehaviorExtensionElementBase<TBehavior> : BehaviorExtensionElement {

        [ConfigurationProperty("hostname", IsRequired = true)]
        public string Hostname => (string) base["hostname"];

        [ConfigurationProperty("port", DefaultValue = 9200)]
        public int Port => (int) base["port"];

        [ConfigurationProperty("index")]
        public string Index => (string) base["index"];


        public override Type BehaviorType => typeof(TBehavior);

        protected override object CreateBehavior() {
            return Build(ElasticSearchMetricsReporter.GetReporter(Hostname, Port, Index));
        }

        protected abstract object Build(ElasticSearchMetricsReporter reporter);
    }
}
