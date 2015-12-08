using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TicTacToeServer.Database;
using TicTacToeServer.Database.Domains;
using TicTacToeServer.Objects;

namespace TicTacToeServer.Networking
{
    public class SocketClient
    {
        // Size of receive buffer.
        public static int BufferSize = 1024;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        public byte[] PacketBuffer;
        
        public Socket handler;
        public Accounts Account;

        public SocketClient(Socket clientSocket)
        {
            handler = clientSocket;
        }

        public void Send(PacketBuilder packet)
        {
            handler.BeginSend(packet.Build(), 0, packet.Build().Length, SocketFlags.None, SendCallback, this);
        }

        private void SendCallback(IAsyncResult ar)
        {
            int bytesSent = handler.EndSend(ar);
        }
    }
}
