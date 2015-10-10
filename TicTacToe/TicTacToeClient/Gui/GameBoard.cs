using System;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToeClient.Gui
{
    public partial class GameBoard : Form
    {

        #region Private Variables
        private Graphics _graphics;
        private Board _playingBoard;
        private bool _aiTurn;
        private bool _twoPlayers;
        private SpaceTypes _aiType;
        private SpaceTypes _playerType;
 
        private int _rounds;
        private int _playerWins;
        private int _aiWins;
        #endregion
        public GameBoard()
        {
            InitializeComponent();
            Size = new Size(528, 217);
        }
        

        private void StartGame()
        {
            _playingBoard = new Board(_graphics);
            _playingBoard.GameOver += GameOver;
            _playerType = (SpaceTypes) Enum.Parse(typeof (SpaceTypes), playerSpaceType.Text);
            _aiType = playerSpaceType.Text == @"X" ? SpaceTypes.O : SpaceTypes.X;
            _rounds = (int) roundCount.Value;
            _twoPlayers = typeBox.Text == @"Player Vs Player";
            _aiWins = 0;
            _playerWins = 0;
            if (firstTurn.Checked) return;
            _aiTurn = true;
            turnLable.Text = @"Current Turn: Player 2";
            if(!_twoPlayers)
                _playingBoard.AiMove(_aiType);
        }

        private void gamePanel_Paint(object sender, PaintEventArgs e)
        {
            _graphics = gamePanel.CreateGraphics();
        }


        /// <summary>
        /// Method used to show that the game has ended, will also 
        /// ask the user if they wish to play again.
        /// </summary>
        /// <param name="winner">The winner of the game (Open for draw)</param>
        private void GameOver(object sender, EventArgs eventArgs)
        {
            //TODO: Add in rounds and not just close it right when someone wins LOL
            //SpaceTypes winner = (SpaceTypes) sender;
            //if (_rounds == _aiWins + _playerWins)
            //{
            //    Application.Exit();
            //}
            //DialogResult reply = DialogResult.None;
            //if (winner == _aiType)
            //    reply = MessageBox.Show(this, "Sadly you have lost, would you like to play again?", Properties.Resources.GameOverMessageTitle,
            //        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (winner == _playerType)
            //    reply = MessageBox.Show(this, "Awesome you won, would you like to play again?", Properties.Resources.GameOverMessageTitle,
            //        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (winner == SpaceTypes.Open)
            //    reply = MessageBox.Show(this, "Whoa it was a draw, would you like to play again?", Properties.Resources.GameOverMessageTitle,
            //        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (reply == DialogResult.No)
            //    Application.Exit();
            //if (reply == DialogResult.Yes)
            //{
            //    Application.Exit();
            //}
            Close();
        }

        /// <summary>
        /// This method is called when ever the user clicks on the board.
        /// It will check where the user clicks and assign it to a location on the board,
        /// if the click was on an open playing field and it is the users' turn it will play.
        /// </summary>
        /// <param name="sender">The panel from which the user clicked.</param>
        /// <param name="e">Contains the users click location relative to the Panel coordinate plane.</param>
        private void gamePanel_MouseClick(object sender, MouseEventArgs e)
        {
            int row = 4, column = 4;
            if (e.X < 190)
                row = 0;
            if (e.X > 205 && e.X < 395)
                row = 1;
            if (e.X > 410)
                row = 2;
            if (e.Y < 190)
                column = 0;
            if (e.Y > 205 && e.Y < 395)
                column = 1;
            if (e.Y > 410)
                column = 2;

            if (_twoPlayers)
            {
                var playedSpace = new FieldItem(row, column);
                var playedType = _aiTurn ? _aiType : _playerType;
                if (!_playingBoard.PlaySpace(playedType, playedSpace)) return;
                _aiTurn = !_aiTurn;
                turnLable.Text = _aiTurn ? @"Current Turn: Player 2" : @"Current Turn: Player 1";
            }
            else if (!_aiTurn)
            {
                var playedSpace = new FieldItem(row, column);
                var playedType = _playerType;
                if (!_playingBoard.PlaySpace(playedType, playedSpace)) return;
                _aiTurn = true;
                _playingBoard.AiMove(_aiType);
            }
        }


        private void BeginButtonClick(object sender, EventArgs e)
        {
            menuPanel.Visible = false;
            gamePanel.Visible = true;
            Size = new Size(640,680);
            StartGame();
            //collect data
        }
    }
}
