using System;
using System.Collections.Generic;
using System.Drawing;
using TicTacToeClient.Resources;

namespace TicTacToeClient.Game_Components
{
    class Board
    {
        
        private readonly SpaceTypes[,] _fieldSpaces = new SpaceTypes[3, 3];
        private readonly List<FieldItem> _openFieldPlaces = new List<FieldItem>();
        private readonly Graphics _graphics;
        public delegate void GameOverHandler(SpaceTypes winner, EventArgs e);
        public event EventHandler GameOver;
        private readonly Random _random = new Random();

        /// <summary>
        /// Constructor called that clears the field and also draws the board. 
        /// </summary>
        /// <param name="g">The Graphics of the panel it draws on.</param>
        public Board(Graphics g)
        {
            _graphics = g;
            ClearField();
            DrawField();
        }

        /// <summary>
        /// Method used to play any space on the board.
        /// </summary>
        /// <param name="type">SpaceType that is being played.</param>
        /// <param name="playedSpace">The position of the requested play space.</param>
        /// <returns>Returns true if space open and played, otherwise false if space is take</returns>
        public bool PlaySpace(SpaceTypes type, FieldItem playedSpace)
        {
            if (playedSpace.Posion.X == 4 || playedSpace.Posion.Y == 4 ||
                _fieldSpaces[playedSpace.Posion.X, playedSpace.Posion.Y] != SpaceTypes.Open) return false;

            _fieldSpaces[playedSpace.Posion.X, playedSpace.Posion.Y] = type;
            _openFieldPlaces.Remove(_openFieldPlaces.Find(x => x.Posion == new Point(playedSpace.Posion.X, playedSpace.Posion.Y)));
            DrawField();
            return true;
        }

        /// <summary>
        /// Method used to randomly select a unplaced tile for the AI if the checking
        /// method has no suggestion.
        /// </summary>
        public void AiMove(SpaceTypes aiType)
        {
            var index = _random.Next(_openFieldPlaces.Count);
            FieldItem played = _openFieldPlaces[index];
            PlaySpace(aiType, played);
            DrawField();
            //TODO: Add counter moves and AI Logic
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

                    switch (_fieldSpaces[i, j])
                    {
                        case SpaceTypes.Open:
                            _graphics.FillRectangle(new SolidBrush(Color.White), x, y, 190, 190);
                            break;
                        case SpaceTypes.O:
                            _graphics.DrawImage(ClientResources.tic_tac_toe_O, x, y, 190, 190);
                            break;
                        case SpaceTypes.X:
                            _graphics.DrawImage(ClientResources.tic_tac_toe_X, x, y, 190, 190);
                            break;

                    }
                }
            }


            #endregion

            _graphics.FillRectangles(new SolidBrush(Color.Black), allRectangles);
            CheckBoard();
        }

        /// <summary>
        /// Method used to reset the game and clear the field.
        /// </summary>
        public void ClearField()
        {
            _openFieldPlaces.Clear();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    _fieldSpaces[i, j] = SpaceTypes.Open;
                    _openFieldPlaces.Add(new FieldItem(i, j));
                }
            DrawField();
        }

        /// <summary>
        /// Method used to check the board if anyone has one,
        /// will also detect a draw.
        /// </summary>
        private void CheckBoard()
        {
            #region O Check

            for (int i = 0; i < 3; i++)
                if (_fieldSpaces[i, 0] == SpaceTypes.O && _fieldSpaces[i, 1] == SpaceTypes.O && _fieldSpaces[i, 2] == SpaceTypes.O)
                { GameOver(SpaceTypes.O, null); return; }


            for (int i = 0; i < 3; i++)
                if (_fieldSpaces[0, i] == SpaceTypes.O && _fieldSpaces[1, i] == SpaceTypes.O && _fieldSpaces[2, i] == SpaceTypes.O)
                { GameOver(SpaceTypes.O, null); return; }


            if (_fieldSpaces[0, 0] == SpaceTypes.O && _fieldSpaces[1, 1] == SpaceTypes.O && _fieldSpaces[2, 2] == SpaceTypes.O)
            { GameOver(SpaceTypes.O, null); return; }

            if (_fieldSpaces[0, 2] == SpaceTypes.O && _fieldSpaces[1, 1] == SpaceTypes.O && _fieldSpaces[2, 0] == SpaceTypes.O)
            { GameOver(SpaceTypes.O, null); return; }
            #endregion
            #region X Check
            for (int i = 0; i < 3; i++)
                if (_fieldSpaces[i, 0] == SpaceTypes.X && _fieldSpaces[i, 1] == SpaceTypes.X && _fieldSpaces[i, 2] == SpaceTypes.X)
                { GameOver(SpaceTypes.X, null); return; }


            for (int i = 0; i < 3; i++)
                if (_fieldSpaces[0, i] == SpaceTypes.X && _fieldSpaces[1, i] == SpaceTypes.X && _fieldSpaces[2, i] == SpaceTypes.X)
                { GameOver(SpaceTypes.X, null); return; }


            if (_fieldSpaces[0, 0] == SpaceTypes.X && _fieldSpaces[1, 1] == SpaceTypes.X && _fieldSpaces[2, 2] == SpaceTypes.X)
            { GameOver(SpaceTypes.X, null); return; }

            if (_fieldSpaces[0, 2] == SpaceTypes.X && _fieldSpaces[1, 1] == SpaceTypes.X && _fieldSpaces[2, 0] == SpaceTypes.X)
            { GameOver(SpaceTypes.X, null); return; }
            #endregion

            if (_openFieldPlaces.Count == 0)
                GameOver(SpaceTypes.Open, null);
        }

    }
}
