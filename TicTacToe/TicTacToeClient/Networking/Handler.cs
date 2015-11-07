using System;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using TicTacToeClient.Enums;
using TicTacToeClient.Networking.Packets;

namespace TicTacToeClient.Networking
{
    class Handler
    {
        public static void HandlePacket(ClientHandler client)
        {
            var type = (PacketType) BitConverter.ToInt16(client.PacketBuffer, 0);
            switch (type)
            {
                case PacketType.LoginResponse:
                    client.LoginUi.Invoke(
                        (MethodInvoker) (() => client.LoginUi.ReciveResponse(new LoginResponse(client.PacketBuffer))));
                    break;
                default:
                    Console.WriteLine("Unknown packet type: {0}, with the length of {1}", type, client.PacketBuffer.Length);
                    break;
            }
        }
    }
}
