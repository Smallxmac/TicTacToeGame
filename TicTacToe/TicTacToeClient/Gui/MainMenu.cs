using System;
using System.Windows.Forms;
using TicTacToeClient.Networking;

namespace TicTacToeClient.Gui
{
    /// <summary>
    /// The Main Menu is the first UI called from the program.
    /// This menu will also show back up once a sub window is closed.
    /// When this menu is closed the game is closed.
    /// </summary>
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method used to load the Login menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onlineButton_Click(object sender, EventArgs e)
        {
            Visible = false;
            var online = new Login(new ClientHandler());
            online.Show(this);
            online.FormClosed += ChildClosed;
        }

        /// <summary>
        /// No current use for this button.
        /// Possible chained2pvp link.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, @"Thank you for taking interests in this feature however it is still in development :(",
                @"Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// No current use for this button
        /// Possible quit or about me.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, @"Thank you for taking interests in this feature however it is still in development :(",
                @"Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Loaded the Gameboard UI so that the user can play agaist a bot or another player
        /// on the same computer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void offlineButton_Click(object sender, EventArgs e)
        {
            Visible = false;
            var gameMenu = new GameBoard();
            gameMenu.Show(this);
            gameMenu.FormClosed += ChildClosed;

        }

        /// <summary>
        /// When a child is closed this menu will come out of it's hiding.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChildClosed(object sender, EventArgs e)
        {
            Visible = true;
        }
    }
}
