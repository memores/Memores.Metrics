using Memores.NetAPMAgent.Model;


namespace Memores.NetAPMAgent.Contracts
{

    public class Payload {
        public Service Service { get; set; }
        public Process Process { get; set; }
        public System System { get; set; }
        public Transaction[] Transactions { get; set; }
    }

}