namespace Memores.NetAPMAgent.Contracts
{
    public class Service {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Environment { get; set; }
        public Language Language { get; set; }
        public Runtime Runtime { get; set; }
        public Framework Framework { get; set; }
        public Agent Agent { get; set; }
    }

}