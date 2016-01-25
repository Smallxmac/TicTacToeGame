using System;
using System.Linq;
using System.Text;
using TicTacToeClient.Enums;

namespace TicTacToeClient.Networking
{
    public class PacketBuilder
    {
        private readonly byte[] _buffer;

        /// <summary>
        /// Constructor used to build packet base.
        /// </summary>
        /// <param name="type">Enum of the type of packet it is.</param>
        /// <param name="length">Packet size, NOT including header.</param>
        public PacketBuilder(PacketType type, int length)
        {
            _buffer = new byte[length+4];
            WriteHeader(type, length+4);
        }

        /// <summary>
        /// Constructor used to read information from a byte array.
        /// </summary>
        /// <param name="bytes">Byte array of data</param>
        public PacketBuilder(byte[] bytes)
        {
            _buffer = bytes;
        }

        #region Write
        /// <summary>
        /// Writes the header for the packets which includes the type of the packet and the length.
        /// </summary>
        /// <param name="type">PacketType enum type</param>
        /// <param name="length">Length of the packet</param>
        private void WriteHeader(PacketType type, int length)
        {
            WriteShort((short)type, 0);
            WriteShort((short)length, 2);
        }

        /// <summary>
        /// Writes a value at the offset specified.
        /// </summary>
        /// <param name="value">Value that will be written.</param>
        /// <param name="offset">Offset where the value will be written.</param>
        public void WriteByte(byte value, int offset)
        {
            _buffer[offset] = value;
        }

        /// <summary>
        /// Writes a value at the offset specified.
        /// </summary>
        /// <param name="value">Value that will be written.</param>
        /// <param name="offset">Offset where the value will be written.</param>
        public void WriteShort(short value, int offset)
        {
            BitConverter.GetBytes(value).CopyTo(_buffer, offset);
        }

        /// <summary>
        /// Writes a value at the offset specified.
        /// </summary>
        /// <param name="value">Value that will be written.</param>
        /// <param name="offset">Offset where the value will be written.</param>
        public void WriteInt(int value, int offset)
        {
            BitConverter.GetBytes(value).CopyTo(_buffer, offset);
        }

        /// <summary>
        /// Writes a value at the offset specified.
        /// </summary>
        /// <param name="value">Value that will be written.</param>
        /// <param name="offset">Offset where the value will be written.</param>
        public void WriteDouble(double value, int offset)
        {
            BitConverter.GetBytes(value).CopyTo(_buffer, offset);
        }

        /// <summary>
        /// Writes a value at the offset specified.
        /// </summary>
        /// <param name="value">Value that will be written.</param>
        /// <param name="offset">Offset where the value will be written.</param>
        public void WriteLong(long value, int offset)
        {
            BitConverter.GetBytes(value).CopyTo(_buffer, offset);
        }

        /// <summary>
        /// Writes a value at the offset specified.
        /// </summary>
        /// <param name="value">Value that will be written.</param>
        /// <param name="offset">Offset where the value will be written.</param>
        /// <param name="nextOffset">The next open offset for data</param>
        public void WriteString(string value, int offset, out int nextOffset)
        {
            nextOffset = offset;
            WriteByte((byte) value.Length, nextOffset);
            nextOffset ++;
            Encoding.ASCII.GetBytes(value).CopyTo(_buffer, nextOffset);
            nextOffset += value.Length;
        }

        /// <summary>
        /// Writes a value at the offset specified.
        /// </summary>
        /// <param name="value">Value that will be written.</param>
        /// <param name="offset">Offset where the value will be written.</param>
        /// <param name="nextOffset">The next open offset for data</param>
        public void WriteStringArray(string[] value, int offset, out int nextOffset)
        {
            nextOffset = offset;
            WriteByte((byte) value.Length, nextOffset);
            nextOffset++;
            foreach (var message in value)
                WriteString(message, nextOffset, out nextOffset);
        }
        #endregion
        #region Read

        /// <summary>
        /// Reads the data at a specific offset.
        /// </summary>
        /// <param name="offset">Target offset of the data</param>
        /// <returns>Value at that offset</returns>
        public byte ReadByte(int offset)
        {
            return _buffer[offset];
        }

        /// <summary>
        /// Reads the data at a specific offset.
        /// </summary>
        /// <param name="offset">Target offset of the data</param>
        /// <returns>Value at that offset</returns>
        public short ReadShort(int offset)
        {
            return BitConverter.ToInt16(_buffer, offset);
        }

        /// <summary>
        /// Reads the data at a specific offset.
        /// </summary>
        /// <param name="offset">Target offset of the data</param>
        /// <returns>Value at that offset</returns>
        public int ReadInt(int offset)
        {
            return BitConverter.ToInt32(_buffer, offset);
        }

        /// <summary>
        /// Reads the data at a specific offset.
        /// </summary>
        /// <param name="offset">Target offset of the data</param>
        /// <returns>Value at that offset</returns>
        public long ReadLong(int offset)
        {
            return BitConverter.ToInt64(_buffer, offset);
        }

        /// <summary>
        /// Reads the data at a specific offset.
        /// </summary>
        /// <param name="offset">Target offset of the data</param>
        /// <returns>Value at that offset</returns>
        public double ReadDouble(int offset)
        {
            return BitConverter.ToDouble(_buffer, offset);
        }

        /// <summary>
        /// Reads the data at a specific offset.
        /// </summary>
        /// <param name="offset">Target offset of the data</param>
        /// <param name="nextOffset">The last offset for the next data.</param>
        /// <returns>Value at that offset</returns>
        public string ReadString(int offset, out int nextOffset)
        {
            nextOffset = offset;
            var ln = ReadByte(nextOffset);
            nextOffset++;
            var message = Encoding.ASCII.GetString(_buffer, nextOffset, ln);
            nextOffset += ln;
            return message;
        }

        /// <summary>
        /// Reads the data at a specific offset.
        /// </summary>
        /// <param name="offset">Target offset of the data</param>
        /// <param name="nextOffset">The last offset for the next data.</param>
        /// <returns>Value at that offset</returns>
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
        #endregion
        #region Misc 

        /// <summary>
        /// Method used to return the buffer of the current packet. 
        /// </summary>
        /// <returns>_buffer[byte]</returns>
        public byte[] Build()
        {
            return _buffer;
        }

        /// <summary>
        /// Method used to get the size of a string array so that the packet will have the right length.
        /// </summary>
        /// <param name="arrayStrings">Array to calculate</param>
        /// <returns>Length of the array.</returns>
        public static int SizeOfStringArray(string[] arrayStrings)
        {
            return arrayStrings.Length + arrayStrings.Sum(message => (message.Length + 1));
        }

        /// <summary>
        /// Method used to get the size of a string.
        /// basically the length + 1.
        /// </summary>
        /// <param name="String">String to calculate.</param>
        /// <returns>Length that will be written.</returns>
        public static int SizeOfString(string String)
        {
            return String.Length + 1;
        }
        #endregion
    }
}
