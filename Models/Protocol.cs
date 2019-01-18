using Ardalis.SmartEnum;

namespace DappSniper.Net.Models
{
    public sealed class Protocol : SmartEnum<Protocol, int>
    {
        public static readonly Protocol ETH = new Protocol(nameof(ETH), 1);
        public static readonly Protocol EOS = new Protocol(nameof(EOS), 2);
        public static readonly Protocol TRON = new Protocol(nameof(TRON), 3);
        
        private Protocol(string name, int value) : base(name, value)
        {
        }
    }
}
