using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memores.Metrics.Wcf.Reporters.Counters
{
    public interface ICounter {
        void Start(int timeout);

        void Stop();
    }
}
