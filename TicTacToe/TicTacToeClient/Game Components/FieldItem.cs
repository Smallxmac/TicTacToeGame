using System.Drawing;

namespace TicTacToeClient.Game_Components
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
