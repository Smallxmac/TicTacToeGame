using System;
using System.Drawing;
using System.Windows.Forms;
using TicTacToeClient.Enums;
using TicTacToeClient.Game_Components;

namespace TicTacToeClient.Gui
{
    public partial class GameBoard : Form
    {
        #region Private Variables

        //Game Objects
        private Graphics _graphics;
        private Board _playingBoard;
        //Game Information
        private bool _aiTurn;
        private bool _twoPlayers;
        private SpaceTypes _aiType;
        private SpaceTypes _playerType;
        //Player Scores
        private int _rounds;
        private int _playerWins;
        private int _aiWins;
        private int _roundsPlayed;

        #endregion
        #region GameUI

        /// <summary>
        /// Constructor that also sets the size of the form to the menu size.
        /// </summary>
        public GameBoard()
        {
            InitializeComponent();
            Size = new Size(528, 217);
        }

        /// <summary>
        /// Method called in order to get all of the values from the
        /// menu portion of this UI and begin the game.
        /// </summary>
        private void StartGame()
        {
            _playingBoard = botDifficulty.Text == ""
                ? new Board(_graphics, BotDifficulty.Random)
                : new Board(_graphics, (BotDifficulty) Enum.Parse(typeof (BotDifficulty), botDifficulty.Text));
            _playingBoard.GameOver += GameOver;
            _playerType = (SpaceTypes)Enum.Parse(typeof(SpaceTypes), playerSpaceType.Text);
            _aiType = playerSpaceType.Text == @"X" ? SpaceTypes.O : SpaceTypes.X;
            _rounds = (int)roundCount.Value;
            _twoPlayers = typeBox.Text == @"Player Vs Player";
            _aiWins = 0;
            _playerWins = 0;
            _roundsPlayed = 1;
            roundLable.Text = $"Round {_roundsPlayed} out of {_rounds}";
            if (firstTurn.Checked) return;
            _aiTurn = true;
            turnLable.Text = @"Current Turn: Player 2";
            if (!_twoPlayers)
                _playingBoard.AiMove(_aiType);
        }

        /// <summary>
        /// (Called from Event) Called at the creation of the UI,
        /// used past the graphic controller to the Board class.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gamePanel_Paint(object sender, PaintEventArgs e)
        {
            _graphics = gamePanel.CreateGraphics();
        }


        /// <summary>
        /// (Called from Event) Method used to determine the winner
        ///  and if to start the next round.
        /// </summary>
        /// <param name="sender">The winner as SpaceType. Open for draw.</param>
        /// <param name="eventArgs">Not used.</param>
        private void GameOver(object sender, EventArgs eventArgs)
        {
            SpaceTypes winner = (SpaceTypes)sender;

            if (_aiType == winner)
                _aiWins++;
            else if (winner == SpaceTypes.Open)
            {
                _aiWins++;
                _playerWins++;
            }
            else
                _playerWins++;

            if (_rounds == _roundsPlayed)
            {
                DialogResult reply;
                //Player Win
                if (_playerWins > _aiWins)
                    reply = MessageBox.Show(this, Properties.Resources.GameOver_Win,
                        Properties.Resources.GameOverMessageTitle,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //Draw
                else if (_playerWins == _aiWins)
                    reply = MessageBox.Show(this, Properties.Resources.GameOver_Draw,
                        Properties.Resources.GameOverMessageTitle,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //Player Lose
                else
                    reply = MessageBox.Show(this, Properties.Resources.Gameover_Lost,
                        Properties.Resources.GameOverMessageTitle,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (reply == DialogResult.No)
                {
                    Close();
                    return;
                }
                if (reply == DialogResult.Yes)
                {
                    menuPanel.Visible = true;
                    gamePanel.Visible = false;
                    Size = new Size(528, 217);
                }
            }
            else
                _roundsPlayed++;
            _playingBoard.ClearField();
            roundLable.Text = $"Round {_roundsPlayed} out of {_rounds}";
            if (firstTurn.Checked && _aiTurn)
                _aiTurn = false;

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
                _aiTurn = false;
            }
        }
        #endregion
        #region MenuUI

        /// <summary>
        /// (Called from Event) Event called when the menuUI's 
        /// begin button is click. Will switch UI from menu to game
        /// and call StartGame().
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BeginButtonClick(object sender, EventArgs e)
        {
            menuPanel.Visible = false;
            gamePanel.Visible = true;
            Size = new Size(640,680);
            StartGame();
        }

        /// <summary>
        /// (Called from Event) Event called when the game mode box is changed
        /// it will  enable or disable the difficulty selection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void typeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            botDifficulty.Enabled = typeBox.Text != @"Player Vs Player";
        }

        #endregion

        
    }
}
