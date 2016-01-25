using System;
using System.Net.Sockets;
using System.Windows.Forms;
using TicTacToeClient.Gui;

namespace TicTacToeClient.Networking
{
    public class ClientHandler
    {
        #region Vars
        // Size of receive buffer.
        public static int BufferSize = 1024;
        // Receive buffer.
        public byte[] Buffer = new byte[BufferSize];
        public byte[] PacketBuffer;
        public Socket ClientSocket;
        public EventHandler RecivedResponseHandler;
        public EventHandler RecivedUiPacketHandler;
        public SocketClient Client;
        public Login LoginUi;
        public OnlineMenu OnMenu;
#endregion

        /// <summary>
        /// Method used to connect to the sever, sometime is called when already connected so it will not connect again.
        /// </summary>
        public void Connect()
        {
            if(ClientSocket != null)
                if(ClientSocket.Connected)
                    return;
            Client = new SocketClient();

            Client.ConnectClient(this);
        }

        /// <summary>
        /// Sends a prebuilt packet to the sever by using the packet's build method. 
        /// </summary>
        /// <param name="packet"></param>
        public void Send(PacketBuilder packet)
        {
            if (ClientSocket.Connected)
                ClientSocket.Send(packet.Build(), SocketFlags.None);
        }

        /// <summary>
        /// This tells the client to disconnect from the server, or if the connection was reset.
        /// </summary>
        /// <param name="show">If true it will show a message saying the server has been disconnected from.</param>
        public void Disconnect(bool show)
        {
            if(show)
                OnMenu?.Invoke(
                    (MethodInvoker)(() => OnMenu.Disconnected(show)));
            ClientSocket.Disconnect(false);
        }
    }
}
