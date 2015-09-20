using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToeClient.Gui
{
    public partial class GameBoard : Form
    {

        #region Private Varabiles
        private Graphics _graphics;
        private readonly Brush _brush = new SolidBrush(Color.Black);
        private readonly SpaceTypes[,] _fieldSpaces = new SpaceTypes[3,3];
        private readonly Random _random = new Random();
        private bool _aiTurn;
        private readonly List<FieldItem> _openFieldPlaces = new List<FieldItem>();
        #endregion

        public GameBoard()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Loading point of the Panel, this will also be the main setup of the game.
        /// Only called once durning the start of the form.
        /// </summary>
        /// <param name="sender">The Panel</param>
        /// <param name="e">No arguments</param>
        private void GameBoard_Load(object sender, EventArgs e)
        {
            ClearField();
        }

        /// <summary>
        /// Method use to draw the bounds of the field and also current tiles on the field.
        /// </summary>
        private void DrawField()
        {

            #region Rectangles

            Rectangle firstVerticalRectangle = new Rectangle(190, 0, 15, 600);
            Rectangle secondVerticalRectangle = new Rectangle(395, 0, 15, 600);
            Rectangle firstHorizontalRectangle = new Rectangle(0, 190, 600, 15);
            Rectangle secondHorizontalRectangle = new Rectangle(0, 395, 600, 15);
            Rectangle[] allRectangles =
            {
                firstVerticalRectangle, secondVerticalRectangle,
                firstHorizontalRectangle, secondHorizontalRectangle
            };

            #endregion

            #region PlaySpaces

            for (int i = 0; i < 3; i++)
            {
                int x = 0, y = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (i == 1)
                        x = 205;
                    if (i == 2)
                        x = 410;
                    if (j == 1)
                        y = 205;
                    if (j == 2)
                        y = 410;

                    switch (_fieldSpaces[i,j])
                    {
                        case SpaceTypes.Open:
                            _graphics.FillRectangle(new SolidBrush(Color.White), x, y, 190, 190);
                            break;
                        case SpaceTypes.O:
                            _graphics.DrawImage(Resources.ClientResources.tic_tac_toe_O, x, y, 190, 190);
                            break;
                        case SpaceTypes.X:
                            _graphics.DrawImage(Resources.ClientResources.tic_tac_toe_X, x, y, 190, 190);
                            break;

                    }
                }
            }


            #endregion

            _graphics.FillRectangles(_brush, allRectangles);
            CheckBoard();
        }

        /// <summary>
        /// Method used to reset the game and clear the field.
        /// </summary>
        private void ClearField()
        {
            _openFieldPlaces.Clear();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    _fieldSpaces[i, j] = SpaceTypes.Open;
                    _openFieldPlaces.Add(new FieldItem(i,j));
                }
        }

        private void gamePanel_Paint(object sender, PaintEventArgs e)
        {
            _graphics = gamePanel.CreateGraphics();
            DrawField();
        }

        /// <summary>
        /// Method used to randomly select a un-played tile for the ai if the checking
        /// method has no suggestion.
        /// </summary>
        private void AiMove()
        {
            var index = _random.Next(_openFieldPlaces.Count);
            FieldItem played = _openFieldPlaces[index];
            _fieldSpaces[played.Posion.X, played.Posion.Y] = SpaceTypes.X;
            _openFieldPlaces.Remove(played);
            DrawField();
            _aiTurn = false;
        }

        /// <summary>
        /// Method used to check the board if anyone has one,
        /// will also detect a draw.
        /// </summary>
        private void CheckBoard()
        {
            #region O Check
            if(_fieldSpaces[0,0] == SpaceTypes.O && _fieldSpaces[0,1] == SpaceTypes.O && _fieldSpaces[0, 2] == SpaceTypes.O)
                { GameOver(SpaceTypes.O); return; }
            if (_fieldSpaces[1, 0] == SpaceTypes.O && _fieldSpaces[1, 1] == SpaceTypes.O && _fieldSpaces[1, 2] == SpaceTypes.O)
                { GameOver(SpaceTypes.O); return; }
            if (_fieldSpaces[2, 0] == SpaceTypes.O && _fieldSpaces[2, 1] == SpaceTypes.O && _fieldSpaces[2, 2] == SpaceTypes.O)
                { GameOver(SpaceTypes.O); return; }
            if (_fieldSpaces[0, 0] == SpaceTypes.O && _fieldSpaces[1, 0] == SpaceTypes.O && _fieldSpaces[2, 0] == SpaceTypes.O)
                { GameOver(SpaceTypes.O); return; }
            if (_fieldSpaces[0, 1] == SpaceTypes.O && _fieldSpaces[1, 1] == SpaceTypes.O && _fieldSpaces[2, 1] == SpaceTypes.O)
                { GameOver(SpaceTypes.O); return; }
            if (_fieldSpaces[0, 2] == SpaceTypes.O && _fieldSpaces[1, 2] == SpaceTypes.O && _fieldSpaces[2, 2] == SpaceTypes.O)
                { GameOver(SpaceTypes.O); return; }
            if (_fieldSpaces[0, 0] == SpaceTypes.O && _fieldSpaces[1, 1] == SpaceTypes.O && _fieldSpaces[2, 2] == SpaceTypes.O)
                { GameOver(SpaceTypes.O); return; }
            if (_fieldSpaces[0, 2] == SpaceTypes.O && _fieldSpaces[1, 1] == SpaceTypes.O && _fieldSpaces[2, 0] == SpaceTypes.O)
                { GameOver(SpaceTypes.O); return; }
            #endregion
            #region X Check
            if (_fieldSpaces[0, 0] == SpaceTypes.X && _fieldSpaces[0, 1] == SpaceTypes.X && _fieldSpaces[0, 2] == SpaceTypes.X)
                { GameOver(SpaceTypes.X); return; }
            if (_fieldSpaces[1, 0] == SpaceTypes.X && _fieldSpaces[1, 1] == SpaceTypes.X && _fieldSpaces[1, 2] == SpaceTypes.X)
                { GameOver(SpaceTypes.X); return; }
            if (_fieldSpaces[2, 0] == SpaceTypes.X && _fieldSpaces[2, 1] == SpaceTypes.X && _fieldSpaces[2, 2] == SpaceTypes.X)
                { GameOver(SpaceTypes.X); return; }
            if (_fieldSpaces[0, 0] == SpaceTypes.X && _fieldSpaces[1, 0] == SpaceTypes.X && _fieldSpaces[2, 0] == SpaceTypes.X)
                { GameOver(SpaceTypes.X); return; }
            if (_fieldSpaces[0, 1] == SpaceTypes.X && _fieldSpaces[1, 1] == SpaceTypes.X && _fieldSpaces[2, 1] == SpaceTypes.X)
                { GameOver(SpaceTypes.X); return; }
            if (_fieldSpaces[0, 2] == SpaceTypes.X && _fieldSpaces[1, 2] == SpaceTypes.X && _fieldSpaces[2, 2] == SpaceTypes.X)
                { GameOver(SpaceTypes.X); return; }
            if (_fieldSpaces[0, 0] == SpaceTypes.X && _fieldSpaces[1, 1] == SpaceTypes.X && _fieldSpaces[2, 2] == SpaceTypes.X)
                { GameOver(SpaceTypes.X); return; }
            if (_fieldSpaces[0, 2] == SpaceTypes.X && _fieldSpaces[1, 1] == SpaceTypes.X && _fieldSpaces[2, 0] == SpaceTypes.X)
                { GameOver(SpaceTypes.X); return; }
            #endregion

            if (_openFieldPlaces.Count == 0)
                GameOver(SpaceTypes.Open);

            //TODO: Make suggestions to the ai on next move.
        }

        /// <summary>
        /// Method used to show that the game has ended, will also 
        /// ask the user if they wish to play again.
        /// </summary>
        /// <param name="winner">The winner of the game (Open for draw)</param>
        private void GameOver(SpaceTypes winner)
        {
            DialogResult reply = DialogResult.None;
            if (winner == SpaceTypes.X)
                reply = MessageBox.Show(this, "Sadly you have lost, would you like to play again?", Properties.Resources.GameOverMessageTitle,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (winner == SpaceTypes.O)
                reply = MessageBox.Show(this, "Awesome you won, would you like to play again?", Properties.Resources.GameOverMessageTitle,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (winner == SpaceTypes.Open)
                reply = MessageBox.Show(this, "Woah it was a draw, would you like to play again?", Properties.Resources.GameOverMessageTitle,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (reply == DialogResult.No)
                Application.Exit();
            if (reply == DialogResult.Yes)
            {
                ClearField();
                DrawField();
                _aiTurn = false;
            }

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
            if (!_aiTurn)
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

                if (row != 4 && column != 4 && _fieldSpaces[row,column] == SpaceTypes.Open)
                {
                    _fieldSpaces[row, column] = SpaceTypes.O;
                    _openFieldPlaces.Remove(_openFieldPlaces.Find(x => x.Posion == new Point(row,column)));
                    DrawField();
                    _aiTurn = true;
                    AiMove();
                }
            }
        }
    }

    /// <summary>
    /// The field types that are used within the program.
    /// </summary>
    enum SpaceTypes
    {
        Open,
        X,
        O
    }

    /// <summary>
    /// Used to show the field items within the game board.
    /// </summary>
    class FieldItem
    {
        public FieldItem(int r, int c)
        {
            Posion = new Point(r,c);
        }
        public Point Posion { get; set; }
    }
}
