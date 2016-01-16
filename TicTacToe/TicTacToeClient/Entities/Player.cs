using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeClient.Gui;
using TicTacToeClient.Networking;

namespace TicTacToeClient.Entities
{
    /// <summary>
    /// A player is a client side entity that is used to handle people you friends with
    /// or playing with in a match. The only player that uses the ClientHandler is the logged in user.
    /// </summary>
    public class Player
    {
        public ClientHandler Handler;
        public int AccountId;
        public string Username;
        public bool Online;
        public bool Pending;
        public bool Receiving;
        public Dictionary<int,Player> Friends = new Dictionary<int, Player>();
        public OnlineMenu OnMenu;
    }
}
