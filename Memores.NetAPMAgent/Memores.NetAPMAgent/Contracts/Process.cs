namespace Memores.NetAPMAgent.Contracts
{
    public class Process {
        public int Pid { get; set; }
        public int Ppid { get; set; }
        public string Title { get; set; }
        public string[] Argv { get; set; }
    }

}