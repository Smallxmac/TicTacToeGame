using System;
using System.Linq;
using System.Text;
using TicTacToeClient.Enums;

namespace TicTacToeClient.Networking
{
    public class PacketBuilder
    {
        private readonly byte[] _buffer;

        public PacketBuilder(PacketType type, int length)
        {
            _buffer = new byte[length+4];
            WriteHeader(type, length+4);
        }

        public PacketBuilder(byte[] bytes)
        {
            _buffer = bytes;
        }

        public void WriteHeader(PacketType type, int length)
        {
            WriteShort((short)type, 0);
            WriteShort((short)length, 2);
        }

        public void WriteByte(byte value, int offset)
        {
            _buffer[offset] = value;
        }
  
        public void WriteShort(short value, int offset)
        {
            BitConverter.GetBytes(value).CopyTo(_buffer, offset);
        }

        public void WriteInt(int value, int offset)
        {
            BitConverter.GetBytes(value).CopyTo(_buffer, offset);
        }

        public void WriteDouble(double value, int offset)
        {
            BitConverter.GetBytes(value).CopyTo(_buffer, offset);
        }

        public void WriteLong(long value, int offset)
        {
            BitConverter.GetBytes(value).CopyTo(_buffer, offset);
        }

        public void WriteString(string value, int offset, out int nextOffset)
        {
            nextOffset = offset;
            WriteByte((byte) value.Length, nextOffset);
            nextOffset ++;
            Encoding.ASCII.GetBytes(value).CopyTo(_buffer, nextOffset);
            nextOffset += value.Length;
        }

        public void WriteStringArray(string[] value, int offset, out int nextOffset)
        {
            nextOffset = offset;
            WriteByte((byte) value.Length, nextOffset);
            nextOffset++;
            foreach (var message in value)
                WriteString(message, nextOffset, out nextOffset);
        }

        public byte ReadByte(int offset)
        {
            return _buffer[offset];
        }

        public short ReadShort(int offset)
        {
            return BitConverter.ToInt16(_buffer, offset);
        }

        public int ReadInt(int offset)
        {
            return BitConverter.ToInt32(_buffer, offset);
        }

        public long ReadLong(int offset)
        {
            return BitConverter.ToInt64(_buffer, offset);
        }

        public double ReadDouble(int offset)
        {
            return BitConverter.ToDouble(_buffer, offset);
        }

        public string ReadString(int offset, out int nextOffset)
        {
            nextOffset = offset;
            var ln = ReadByte(nextOffset);
            nextOffset++;
            var message = Encoding.ASCII.GetString(_buffer, nextOffset, ln);
            nextOffset += ln;
            return message;
        }

        public string[] ReadStringArray(int offset, out int nextOffset)
        {
            nextOffset = offset;
            var count = ReadByte(nextOffset);
            nextOffset++;
            var messageArray = new string[count];
            for (int i = 0; i < count; i++)
                messageArray[i] = ReadString(nextOffset, out nextOffset);
            return messageArray;
        }

        public byte[] Build()
        {
            return _buffer;
        }

        public static int SizeOfStringArray(string[] arrayStrings)
        {
            return arrayStrings.Length + arrayStrings.Sum(message => (message.Length + 1));
        }

        public static int SizeOfString(string String)
        {
            return String.Length + 1;
        }
    }
}
