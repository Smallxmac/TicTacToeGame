﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TicTacToeServer.Enums;
using TicTacToeServer.Networking.Packets;
using TicTacToeServer.Other;
using static System.String;

namespace TicTacToeServer.Networking
{
    class Handler
    {
        public static void HandlePacket(SocketClient client)
        {
            var type = (PacketType) BitConverter.ToInt16(client.PacketBuffer, 0);
            switch (type)
            {
                case PacketType.LoginRequest:
                    LoginRequest.Handel(client, new LoginRequest(client.PacketBuffer), false);
                    break;
                case PacketType.RegisterRequest:
                    RegisterRequest.Handle(client, new RegisterRequest(client.Buffer));
                    break;
                case PacketType.LoginResponse:
                    LoginResponse.Handle(client, new LoginResponse(client.PacketBuffer));
                    break;
                case PacketType.ForgotPasswordRequest:
                    ForgotPasswordRequest.Handel(client, new ForgotPasswordRequest(client.PacketBuffer));
                    break;
                case PacketType.MaccAddress:
                        MacAddress.Handle(client, new MacAddress(client.PacketBuffer));
                    break;
                case PacketType.PlayerAssociation:
                    PlayerAssociation.Handle(client, new PlayerAssociation(client.PacketBuffer));
                    break;
                default:
                    Logger.Warning($"Unknown packet type {type} from {client.Handler.RemoteEndPoint} with the length of {BitConverter.ToInt16(client.PacketBuffer, 2)}");
                    break;
            }
        }
        
    }
}
