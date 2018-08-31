using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memores.Metrics.Wcf.Behaviors;
using Memores.Metrics.Wcf.ExtentionElements.Base;
using Memores.Metrics.Wcf.Reporters;

namespace Memores.Metrics.Wcf.ExtentionElements
{
    public class ServiceBehaviorExtentionElement: ElasticSearchBehaviorExtensionElementBase<ServiceBehavior>
    {
        protected override object Build(ElasticSearchMetricsReporter reporter) {
            return new ServiceBehavior();
        }
    }
}
