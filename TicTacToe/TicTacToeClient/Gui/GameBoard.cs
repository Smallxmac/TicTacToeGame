using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Xsl;

namespace TicTacToeClient.Gui
{
    public partial class GameBoard : Form
    {

        private Graphics _graphics;
        private Pen _pen = new Pen(Color.Black);
        private Brush _brush = new SolidBrush(Color.Black);
        private SpaceTypes[,] _fieldSpaces = new SpaceTypes[3,3];

        public GameBoard()
        {
            InitializeComponent();
        }

        private void GameBoard_Load(object sender, EventArgs e)
        {
            ClearField();
        }

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
                            _graphics.FillRectangle(new SolidBrush(Color.Gold), x, y, 190, 190);
                            break;
                        case SpaceTypes.O:
                            _graphics.FillRectangle(new SolidBrush(Color.Red), x, y, 190, 190);
                            break;

                    }
                }
            }


            #endregion

            _graphics.FillRectangles(_brush, allRectangles);

        }

        private void ClearField()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    _fieldSpaces[i,j] = SpaceTypes.Open;
        }

        private void gamePanel_Paint(object sender, PaintEventArgs e)
        {
            _graphics = gamePanel.CreateGraphics();
            DrawField();
        }

        enum SpaceTypes
        {
            Open,
            X,
            O,
            Error
        }

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

            if (row != 4 && column != 4)
            {
                _fieldSpaces[row, column] = SpaceTypes.O;
                DrawField();
            }
        }
    }
}
