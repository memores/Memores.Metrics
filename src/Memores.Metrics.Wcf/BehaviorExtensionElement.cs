using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Memores.Metrics.Wcf {
    public class DefaultBehaviorExtensionElement : BehaviorExtensionElement {

        [ConfigurationProperty("hostname", IsRequired = true)]
        public string Hostname => (string) base["hostname"];

        [ConfigurationProperty("port", DefaultValue = 9200)]
        public int Port => (int) base["port"];

        [ConfigurationProperty("index")]
        public string Index => (string) base["index"];

        public DefaultBehaviorExtensionElement() {
            
        }


        public override Type BehaviorType => typeof(EndpointBehavior);

        protected override object CreateBehavior() {
            return new EndpointBehavior();
        }
    }
}
