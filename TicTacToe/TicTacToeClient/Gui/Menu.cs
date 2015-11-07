using System;
using System.Windows.Forms;
using TicTacToeClient.Networking;

namespace TicTacToeClient.Gui
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void onlineButton_Click(object sender, EventArgs e)
        {
            Visible = false;
            var online = new Login(new ClientHandler());
            online.Show(this);
            online.FormClosing += ChildClosing;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var loding = new LoadingUI();
            loding.ShowDialog(this);
            MessageBox.Show(this, @"Thank you for taking interests in this feature however it is still in development :(",
                @"Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, @"Thank you for taking interests in this feature however it is still in development :(",
                @"Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void offlineButton_Click(object sender, EventArgs e)
        {
            Visible = false;
            var gameMenu = new GameBoard();
            gameMenu.Show(this);
            gameMenu.FormClosing += ChildClosing;

        }

        private void ChildClosing(object sender, EventArgs e)
        {
            Visible = true;
        }
    }
}
