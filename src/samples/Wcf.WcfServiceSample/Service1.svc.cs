using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;

namespace Wcf.WcfServiceSample {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1 {
        public string GetData(int value) {
            Thread.Sleep(5);
            return string.Format("You entered: {0}", value);
        }

        public string GetException() {
            throw new NotImplementedException();
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite) {
            Thread.Sleep(10);

            if (composite == null) {
                throw new ArgumentNullException("composite");
            }

            if (composite.BoolValue) {
                composite.StringValue += "Suffix";
            }

            return composite;
        }
    }
}