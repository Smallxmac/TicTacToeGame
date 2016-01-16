using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeServer.Enums;

namespace TicTacToeServer.Networking.Packets
{
    public class ChatMessage : PacketBuilder
    {
        public ChatMessage(int lengthOfStringArray) : base(PacketType.ChatMessage, 13+lengthOfStringArray)
        {
        }

        public ChatMessage(byte[] bytes) : base(bytes)
        {
        }

        private int _no;

        private byte _type; //4
        private int _color; //5
        private int _senderId;//9
        private int _recipientId;//13
        private string[] _chatStrings;//17
        /// 0 = Sender's Name
        /// 1 = Recipient's Name
        /// 2 = Message

        public string[] ChatStrings
        {
            get { _chatStrings = ReadStringArray(17, out _no); return _chatStrings; }
            set { _chatStrings = value; WriteStringArray(value, 17, out _no); }
        }

        public int RecipientId
        {
            get { _recipientId = ReadInt(13); return _recipientId; }
            set { _recipientId = value; WriteInt(value, 13); }
        }

        public int SenderId
        {
            get { _senderId = ReadInt(9); return _senderId; }
            set { _senderId = value; WriteInt(value, 9); }
        }

        public int Color
        {
            get { _color = ReadInt(5); return _color; }
            set { _color = value; WriteInt(value, 5); }
        }

        public byte ChatType
        {
            get { _type = ReadByte(4); return _type; }
            set { _type = value; WriteByte(value, 4); }
        }
    }
}
