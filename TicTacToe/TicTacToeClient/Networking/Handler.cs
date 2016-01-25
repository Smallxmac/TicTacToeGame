using System;
using System.Windows.Forms;
using TicTacToeClient.Enums;
using TicTacToeClient.Networking.Packets;

namespace TicTacToeClient.Networking
{
    class Handler
    {
        /// <summary>
        /// Method used to determine how a packet is handled by the client.
        /// </summary>
        /// <param name="client">ClientHandler that contains packet data.</param>
        public static void HandlePacket(ClientHandler client)
        {
            var type = (PacketType) BitConverter.ToInt16(client.PacketBuffer, 0);
            switch (type)
            {
                case PacketType.LoginResponse:
                    client.LoginUi.Invoke(
                        (MethodInvoker) (() => client.LoginUi.ReciveResponse(new LoginResponse(client.PacketBuffer))));
                    break;
                case PacketType.PlayerAssociation:
                    if(client.OnMenu == null)
                        client.LoginUi.Invoke(
                            (MethodInvoker)(() => client.LoginUi.ReciveAssociation(new PlayerAssociation(client.PacketBuffer))));
                    else
                        client.LoginUi.Invoke(
                            (MethodInvoker)(() => client.OnMenu.ReciveAssociation(new PlayerAssociation(client.PacketBuffer))));
                    break;
                case PacketType.PlayerData:
                    client.LoginUi.Invoke(
                        (MethodInvoker)(() => client.LoginUi.RecivePlayerData(new PlayerData(client.PacketBuffer))));
                    break;
                case PacketType.GameInvite:
                    client.OnMenu.Invoke(
                        (MethodInvoker) (() => client.OnMenu.ReciveGameInvite(new GameInvite(client.PacketBuffer))));
                    break;
                default:
                    Console.WriteLine("Unknown packet type: {0}, with the length of {1}", type, client.PacketBuffer.Length);
                    break;
            }
        }
    }
}
