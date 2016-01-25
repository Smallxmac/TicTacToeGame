using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;
using TicTacToeClient.Networking.Packets;

namespace TicTacToeClient.Networking
{
    public class SocketClient
    {
        public EventHandler Disconnect; 

        /// <summary>
        /// Method used to connect a clientHandler to the server in the settings.
        /// </summary>
        /// <param name="clientHandler">Client handler with unused Socket</param>
        public void ConnectClient(ClientHandler clientHandler)
        {
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
                //TODO: Add a error mode for developers using this.
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// Once a client is connect this callback will be reached.
        /// Client sends the mac address to the server at this time.
        /// </summary>
        /// <param name="ar">Results from the connection.</param>
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
                var macInfo = new MacAddress();
                var macAddr =
                (
                    from nic in NetworkInterface.GetAllNetworkInterfaces()
                    where nic.OperationalStatus == OperationalStatus.Up
                    select nic.GetPhysicalAddress().ToString()
                ).FirstOrDefault();

                macInfo.MAddress = macAddr;
                client.Send(macInfo);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// When data comes in from an active connection it reads the data,
        /// then passes it onto the handler.
        /// </summary>
        /// <param name="ar">Async Result</param>
        private static void ReceiveCallback(IAsyncResult ar)
        {
            var client = (ClientHandler) ar.AsyncState;
            try
            { 
                //Data received
                var bytesRead = client.ClientSocket.EndReceive(ar);
                //Data expected
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
                    else
                    {
                        //TODO: Handle a packet that is incomplete.

                    }
                }
                else
                {
                    client.Disconnect(true);
                    
                }
            }
            catch
                (SocketException e)
            {
                if(e.SocketErrorCode != SocketError.ConnectionReset)
                    MessageBox.Show(e.Message, e.SocketErrorCode.ToString());
                else
                    client.Disconnect(true);
                }
        }
    
        /// <summary>
        /// Callback for the socket disconnect.
        /// Does not do anything as of yet.
        /// </summary>
        /// <param name="ar">Results of the Disconnect</param>
        public void DisconnectCallback(IAsyncResult ar)
        {
            var client = (ClientHandler)ar.AsyncState;
            client.ClientSocket.EndDisconnect(ar);
        }
    }
}
