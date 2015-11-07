using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace TicTacToeClient.Networking
{
    public class SocketClient
    {
        public void ConnectClient(ClientHandler clientHandler)
        {
            // Connect to a remote device.
            try
            {
                IPAddress ipAddress = IPAddress.Parse(Properties.Settings.Default.IP);
                IPEndPoint remoteEp = new IPEndPoint(ipAddress, Properties.Settings.Default.Port);
                clientHandler.ClientSocket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);
                // Connect to the remote endpoint.
                clientHandler.ClientSocket.BeginConnect(remoteEp,
                    ConnectCallback, clientHandler);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                var client = (ClientHandler) ar.AsyncState;
                // Complete the connection.
                client.ClientSocket.EndConnect(ar);
                client.ClientSocket.BeginReceive(client.Buffer, 0, ClientHandler.BufferSize, 0,
                    ReceiveCallback, client);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the client socket 
                // from the asynchronous state object.
                var client = (ClientHandler) ar.AsyncState;

                int bytesRead = client.ClientSocket.EndReceive(ar);
                var bytesExpected = BitConverter.ToInt16(client.Buffer, 2);
                if (bytesRead > 0)
                {
                    if (bytesRead.Equals(bytesExpected))
                    {
                        client.PacketBuffer = new byte[bytesExpected];
                        Array.Copy(client.Buffer, client.PacketBuffer, bytesExpected);
                        Handler.HandlePacket(client);
                        if (bytesRead > 0)
                        {

                            client.ClientSocket.BeginReceive(client.Buffer, 0, ClientHandler.BufferSize, 0,
                                ReceiveCallback, client);
                        }
                    }
                }
            }
            catch
                (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
