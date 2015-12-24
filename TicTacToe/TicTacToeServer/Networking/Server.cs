using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using TicTacToeServer.Database.Respositorys;
using TicTacToeServer.Enums;
using TicTacToeServer.Networking.Packets;
using TicTacToeServer.Other;

namespace TicTacToeServer.Networking
{
    public class Server
    {
        public void StartListening()
        {
            // Data buffer for incoming data.
            byte[] bytes = new byte[1024];

            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, Properties.Settings.Default.Port);

            // Create a TCP/IP socket.
            Socket listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and listen for incoming connections.
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);


                    // Start an asynchronous socket to listen for connections.
                    Logger.Success($"Server started on port {Properties.Settings.Default.Port}, Listening for connections!");
                    listener.BeginAccept(
                        AcceptCallback,
                        listener);

                

            }
            catch (Exception e)
            {
                Logger.Error($"Server Error: {e.Message}");
            }
        }

        public void AcceptCallback(IAsyncResult ar)
        {
            // Get the socket that handles the client request.
            var listener = (Socket) ar.AsyncState;
            var handler = listener.EndAccept(ar);
            var client = new SocketClient(handler);
            handler.BeginReceive(client.buffer, 0, SocketClient.BufferSize, 0,
                ReadCallback, client);
            listener.BeginAccept(
                        AcceptCallback,
                        listener);
            // Create the state object.
        }

        public void ReadCallback(IAsyncResult ar)
        {
            // Retrieve the state object and the handler socket
            // from the asynchronous state object.
            var client = (SocketClient) ar.AsyncState;
            Socket handler = client.Handler;
            // Read data from the client socket. 
            try
            {
                int bytesRead = handler.EndReceive(ar);
                var bytesExpected = BitConverter.ToInt16(client.buffer, 2);
                if (bytesRead > 0)
                {
                    if (bytesRead.Equals(bytesExpected))
                    {
                        if (client.MAddress == null && BitConverter.ToInt16(client.buffer, 0) == 100)
                        {
                            client.PacketBuffer = new byte[bytesExpected];
                            Array.Copy(client.buffer, client.PacketBuffer, bytesExpected);
                            Handler.HandlePacket(client);
                            handler.BeginReceive(client.buffer, 0, SocketClient.BufferSize, 0,
                            ReadCallback, client);
                        }
                        else if (client.MAddress != null)
                        {
                            var record = BlacklistIpsRepository.GetRecordByMac(client.MAddress);
                            if (record == null || record.BlacklistLiftTime < DateTime.Now)
                            {
                                client.PacketBuffer = new byte[bytesExpected];
                                Array.Copy(client.buffer, client.PacketBuffer, bytesExpected);
                                Handler.HandlePacket(client);
                                handler.BeginReceive(client.buffer, 0, SocketClient.BufferSize, 0,
                                    ReadCallback, client);
                            }
                            else
                            {
                                var reply = new LoginResponse
                                {
                                    ResponseType = LoginResponseType.TooManyTries,
                                    AccountId = (int) record.BlacklistLiftTime.Subtract(DateTime.Now).TotalMinutes
                                };
                                client.Send(reply);
                                client.Handler.Shutdown(SocketShutdown.Both);
                                client.Handler.Close(50);
                            }
                        }
                        else
                        {
                            var reply = new LoginResponse { ResponseType = LoginResponseType.InvalidMac };
                            client.Send(reply);
                            client.Handler.Shutdown(SocketShutdown.Both);
                            client.Handler.Close(50);
                        }
                        
                    }
                    else
                    {
                        //TODO: Fragmented packet.
                    }
                }
            }
            catch (SocketException e)
            {
                Logger.Error($"Server Error: {e.Message}");
                client.Handler.Shutdown(SocketShutdown.Both);
                client.Handler.Close();
            }
        }
    }
}
