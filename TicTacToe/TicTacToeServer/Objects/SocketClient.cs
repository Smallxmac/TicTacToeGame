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
        
        public Socket Handler;
        public Accounts Account;
        public string MAddress;

        public SocketClient(Socket clientSocket)
        {
            Handler = clientSocket;
        }

        public int LoginAttempt = 0;

        public void Send(PacketBuilder packet)
        {
            Handler.BeginSend(packet.Build(), 0, packet.Build().Length, SocketFlags.None, SendCallback, this);
        }

        private void SendCallback(IAsyncResult ar)
        {
            if(Handler.Connected)
            {
                var bytesSent = Handler.EndSend(ar);
            }
        }
    }
}
