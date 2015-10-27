using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeClient.Gui
{
    public partial class Login : Form
    {
        private readonly Size _loginSize = new Size(250,190);
        private readonly Size _registerSize = new Size(280, 230);
        private readonly Size _forgotSize = new Size(280, 130);
        public Login()
        {
            InitializeComponent();
            SetVisiblePane("Login");
        }
        #region LoginUIMethods
        private void loginButton_Click(object sender, EventArgs e)
        {
            if (usernameBox.Text.Length > 3 && passwordBox.Text.Length > 3)
            {
                WaitForConnect();
                Enabled = false;
                //TODO: Send login Request
            }
            else
                MessageBox.Show(this, Properties.Resources.LoginCharacterTooFew,
                    Properties.Resources.LoginCharacterTooFewTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void forgotLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetVisiblePane("forgot");
        }

        private void registerLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetVisiblePane("register");
        }

        #endregion
        private void SetVisiblePane(string paneName)
        {
            switch (paneName.ToLower())
            {
                case "login":
                    Text = Properties.Resources.LoginTitle;
                    loginPanel.Visible = true;
                    registerPanel.Visible = false;
                    forgotPanel.Visible = false;
                    MaximumSize = _loginSize;
                    Size = _loginSize;
                    break;
                case "register":
                    Text = Properties.Resources.RegisterTitle;
                    loginPanel.Visible = false;
                    registerPanel.Visible = true;
                    forgotPanel.Visible = false;
                    MaximumSize = _registerSize;
                    Size = _registerSize;
                    break;
                case "forgot":
                    Text = Properties.Resources.PasswordRecoveryTitle;
                    loginPanel.Visible = false;
                    registerPanel.Visible = false;
                    forgotPanel.Visible = true;
                    MaximumSize = _forgotSize;
                    Size = _forgotSize;
                    break;
            }
        }

        private void RegSubmitButton_Click(object sender, EventArgs e)
        {
            if (regUsernameBox.Text.Length > 3 && regPasswordBox.Text.Length > 3 && regPasswordBox2.Text.Length > 3 &&
                regEmailBox.Text.Length > 3)
            {
                if(regPasswordBox.Text.Equals(regPasswordBox2.Text))
                    if (regEmailBox.Text.Contains("@") && regEmailBox.Text.Contains("."))
                    {
                        WaitForConnect();
                        Enabled = false;
                        //TODO: Submit register request.
                    }
                    else
                        MessageBox.Show(this, Properties.Resources.RegisterInvalidEmailTitle,
                    Properties.Resources.RegisterInvalidEmail, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(this, Properties.Resources.RegisterPasswordMismatch,
                    Properties.Resources.RegisterPasswordMismatchTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                MessageBox.Show(this, Properties.Resources.LoginCharacterTooFew,
                    Properties.Resources.LoginCharacterTooFewTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void regBackButton_Click(object sender, EventArgs e)
        {
            SetVisiblePane("login");
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void forgotSubmitButton_Click(object sender, EventArgs e)
        {
            if (forgotEmailBox.Text.Contains("@") && forgotEmailBox.Text.Contains("."))
            {
                WaitForConnect();
                Enabled = false;
                //TODO: Submit forgot request.
            }
            else
                MessageBox.Show(this, Properties.Resources.RegisterInvalidEmailTitle,
            Properties.Resources.RegisterInvalidEmail, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void WaitForConnect()
        {
            await Task.Delay(5000);
            Enabled = true;
            MessageBox.Show(this, Properties.Resources.RequestTimeOut,
            Properties.Resources.RequestTimeOutTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
