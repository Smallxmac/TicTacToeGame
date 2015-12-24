using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeServer.Enums;

namespace TicTacToeServer.Networking.Packets
{
    public class MacAddress : PacketBuilder
    {
        public MacAddress() : base(PacketType.MaccAddress, 13)
        {
        }

        public MacAddress(byte[] bytes) : base(bytes)
        {
        }

        private int _no;
        public string MAddress
        {
            get { return ReadString(4, out _no); }
            set { WriteString(value, 4, out _no); }
        }

        public static void Handle(SocketClient client, MacAddress response)
        {
            client.MAddress = response.MAddress;
            
        }
    }
}
