using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeClient.Gui
{
    public partial class LoadingUI : Form
    {
        public LoadingUI()
        {
            InitializeComponent();
            CreateHandle();
        }

        protected override sealed void CreateHandle()
        {
            base.CreateHandle();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
