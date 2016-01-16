using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeClient.Enums;

namespace TicTacToeClient.Networking.Packets
{
    public class PlayerData : PacketBuilder
    {
        public PlayerData(int length) : base(PacketType.PlayerData, length + 8)
        {
        }

        public PlayerData(byte[] bytes) : base(bytes)
        {
        }

        private int _no;
        public int AccountId { get { return ReadInt(4);} set { WriteInt(value, 4);} }
        public string Username { get { return ReadString(8, out _no); } set { WriteString(value, 8, out _no); } }

    }
}
