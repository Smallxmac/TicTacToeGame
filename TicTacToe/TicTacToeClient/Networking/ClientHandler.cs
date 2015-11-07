﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicTacToeClient.Gui;

namespace TicTacToeClient.Networking
{
    public class ClientHandler
    {
        // Size of receive buffer.
        public static int BufferSize = 1024;
        // Receive buffer.
        public byte[] Buffer = new byte[BufferSize];
        public byte[] PacketBuffer;
        public Socket ClientSocket;
        public EventHandler RecivedResponseHandler;
        public SocketClient Client;
        public Login LoginUi;

        public void Connect()
        {
            if(ClientSocket != null)
                if(ClientSocket.Connected)
                    return;
            Client = new SocketClient();

            Client.ConnectClient(this);
        }

        public void Send(PacketBuilder packet)
        {
            if(ClientSocket.Connected)
                ClientSocket.BeginSend(packet.Build(), 0, packet.Build().Length, SocketFlags.None, SendCallback, this);
        }

        private void SendCallback(IAsyncResult ar)
        {
            int bytesSent = ClientSocket.EndSend(ar);
        }
    }
}