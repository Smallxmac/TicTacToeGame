using System;
using System.Windows.Forms;
using TicTacToeClient.Gui;
using MainMenu = TicTacToeClient.Gui.MainMenu;

namespace TicTacToeClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());
        }
    }
}
