using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeClient
{
    /// <summary>
    /// Used to show the field items within the game board.
    /// </summary>
    class FieldItem
    {
        public FieldItem(int r, int c)
        {
            Posion = new Point(r, c);
        }
        public Point Posion { get; set; }
    }
}
