using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToeClient.Gui;

namespace TicTacToeClient
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void onlineButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, @"Thank you for taking interests in this feature however it is still in development :(",
                @"Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //TODO: Open Login Form
        }

        private void button3_Click(object sender, EventArgs e)
        {
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
            gameMenu.FormClosing += gameClosing;

        }

        private void gameClosing(object sender, EventArgs e)
        {
            Visible = true;
        }
    }
}
