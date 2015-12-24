using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToeClient.Enums;
using TicTacToeClient.Networking;
using TicTacToeClient.Networking.Packets;
using static System.String;

namespace TicTacToeClient.Gui
{

    public partial class Login : Form
    {
        #region Vars
        private readonly Size _loginSize = new Size(250,190);
        private readonly Size _registerSize = new Size(280, 230);
        private readonly Size _forgotSize = new Size(280, 130);
        private readonly ClientHandler _clientHandler;
        public LoadingUI Loading;
        private bool _connected, _logged;
#endregion

        /// <summary>
        /// Constructor called for starting the Login process.
        /// The client handler is sent so that the loginUi can be controlled with in the socket.
        /// </summary>
        /// <param name="client">The new or used client handler.</param>
        public Login(ClientHandler client)
        {
            InitializeComponent();
            SetVisiblePane("Login");
            _clientHandler = client;
            _clientHandler.LoginUi = this;
        }

        #region LoginUIMethods

        /// <summary>
        /// Determines if all of the fields have been filled out and if so starts the socket connection 
        /// and then sends the account information then begins to wait for a reply from the server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginButton_Click(object sender, EventArgs e)
        {
            if (usernameBox.Text.Length > 3 && passwordBox.Text.Length > 3)
            {
                var accInfo = new[] {usernameBox.Text, passwordBox.Text};
                var packet = new LoginRequest(PacketBuilder.SizeOfStringArray(accInfo)) {AccountInformation = accInfo};
                WaitForConnect();
                Enabled = false;
                _clientHandler.Connect();
                Thread.Sleep(50);
                _clientHandler.Send(packet);
            }
            else
                MessageBox.Show(this, Properties.Resources.LoginCharacterTooFew,
                    Properties.Resources.LoginCharacterTooFewTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Switches the active panel to the Forgot Password Panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void forgotLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetVisiblePane("forgot");
        }

        /// <summary>
        /// Switches the active panel to the Register Panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetVisiblePane("register");
        }

        #endregion

        #region RegisterUIMethods
        /// <summary>
        /// Checks if all of the fields are valid and the password matches and the email is valid. If so it will create a socket connection with
        /// the account server and then send the register information and begin to wait for a reply.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegSubmitButton_Click(object sender, EventArgs e)
        {
            if (regUsernameBox.Text.Length > 3 && regPasswordBox.Text.Length > 3 && regPasswordBox2.Text.Length > 3 &&
                regEmailBox.Text.Length > 3)
            {
                if (regPasswordBox.Text.Equals(regPasswordBox2.Text))
                    if (regEmailBox.Text.Contains("@") && regEmailBox.Text.Contains("."))
                    {
                        var registerInfo = new[] { regUsernameBox.Text, regPasswordBox.Text, regEmailBox.Text };
                        var packet = new RegisterRequest(PacketBuilder.SizeOfStringArray(registerInfo));
                        packet.RegisterInformation = registerInfo;
                        WaitForConnect();
                        Enabled = false;
                        _clientHandler.Connect();
                        Thread.Sleep(50);
                        _clientHandler.Send(packet);
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

        /// <summary>
        /// Switches the active panel to the main Login Panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void regBackButton_Click(object sender, EventArgs e)
        {
            SetVisiblePane("login");
        }

        /// <summary>
        /// Closes the current form, usually will trigger the main menu to re-show up.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region ForgotUIMethods
        /// <summary>
        /// Checks if the email is a valid email and if so will send the information and then wait for a reply.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void forgotSubmitButton_Click(object sender, EventArgs e)
        {
            if (forgotEmailBox.Text.Contains("@") && forgotEmailBox.Text.Contains("."))
            {
                var packet = new ForgotPasswordRequest(forgotEmailBox.Text.Length + 1) { Email = forgotEmailBox.Text };
                WaitForConnect();
                Enabled = false;
                _clientHandler.Connect();
                Thread.Sleep(50);
                _clientHandler.Send(packet);
            }
            else
                MessageBox.Show(this, Properties.Resources.RegisterInvalidEmailTitle,
            Properties.Resources.RegisterInvalidEmail, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region MiscMethods

        /// <summary>
        /// Changes from one panel to another.
        /// </summary>
        /// <param name="paneName">The desired panel requested.</param>
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

        /// <summary>
        /// Called from the client handler once it revives a LoginResponse.
        /// </summary>
        /// <param name="reply">The LoginResponse from the server.</param>
        public void ReciveResponse(LoginResponse reply)
        {
            _connected = true;
            switch (reply.ResponseTypeType)
            {
                case LoginResponseType.InvalidMac:
                    EndLoadingWithMessage("Invalid server connection, No identifier.", "Invalid Connection", MessageBoxIcon.Error);
                    break;
                case LoginResponseType.TooManyTries:
                    EndLoadingWithMessage($"Please try again after {reply.AccountId} minutes, Connections blocked till then.", "Connection Blocked.", MessageBoxIcon.Error);
                    break;
                case LoginResponseType.Correct:
                    _logged = true;
                    Loading.Invoke((MethodInvoker)(() => Loading.statusLabel.Text = @"Gather Account Info"));
                    break;
                case LoginResponseType.AccountLocked:
                    EndLoadingWithMessage(
                        "For security reasons your account is locked. Please look at your email for instructions on how to unlock your account.",
                        "Account Locked", MessageBoxIcon.Error);
                    break;
                case LoginResponseType.AccountVerified:
                    EndLoadingWithMessage("Congratulations your account has been verified, please login normally. ", "Account Verified", MessageBoxIcon.Information);
                    break;
                case LoginResponseType.DatabaseError:
                    EndLoadingWithMessage("The server seems to be having a problem, if this continues please contact Michael", "Server Error", MessageBoxIcon.Error);
                    break;
                case LoginResponseType.EmailInUse:
                    EndLoadingWithMessage("The E-Mail you are tying to register under is already in use.", "E-Mail In Use", MessageBoxIcon.Error);
                    break;
                case LoginResponseType.UsernameInUse:
                    EndLoadingWithMessage("The username you have choose is already taken, please choose another one.", "Username Taken", MessageBoxIcon.Error);
                    break;
                case LoginResponseType.InvalidPassword:
                    EndLoadingWithMessage("Invalid username or password.", "Invalid Credentials", MessageBoxIcon.Error);
                    break;
                case LoginResponseType.AccountCreated:
                    EndLoadingWithMessage("Account created please verify your E-Mail address.", "Account Created", MessageBoxIcon.Information);
                    break;
                case LoginResponseType.ResetInvalid:
                    EndLoadingWithMessage("We do not have that email registered with us.", "Invalid Account", MessageBoxIcon.Error);
                    break;
                case LoginResponseType.ResetLocked:
                    EndLoadingWithMessage("That account you are trying to reset is locked.", "Account Locked", MessageBoxIcon.Error);
                    break;
                case LoginResponseType.ResetSent:
                    EndLoadingWithMessage("The reset email has been sent please follow the instructions in the email that was sent.", "Account Created", MessageBoxIcon.Information);
                    break;
                case LoginResponseType.ResetVerified:
                    EndLoadingWithMessage("Your account password has been changed, please login again normally.", "Password Changed", MessageBoxIcon.Information);
                    break;
                case LoginResponseType.AccountNotVerified:
                    Enabled = true;
                    Loading.Invoke((MethodInvoker)(() => Loading.Close()));
                    var mbReply = MessageBox.Show(this,
                        @"Your account is not verified would you like to resend the verification code?",
                        @"Account Not Verified", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (mbReply == DialogResult.Yes)
                        _clientHandler.Send(reply);
                    break;
                default:
                    EndLoadingWithMessage("This program was not ready for the reply it got: "+ reply.ResponseTypeType, "Invalid Reply", MessageBoxIcon.Error);
                    break;
            }
        }

        /// <summary>
        /// Stop the loading form and shows a message box.
        /// </summary>
        /// <param name="message">Message box body.</param>
        /// <param name="title">Message box title.</param>
        /// <param name="icon">Message box icon.</param>
        private void EndLoadingWithMessage(string message, string title, MessageBoxIcon icon)
        {
            Enabled = true;
            Loading.Invoke((MethodInvoker)(() => Loading.Close()));
            Task.Run(
                new Action(
                    () =>

                        Invoke(
                            (MethodInvoker)
                                (() =>
                                    MessageBox.Show(this, message, title,
                                        MessageBoxButtons.OK,
                                        icon)))));
        }

        /// <summary>
        /// Forces the connection form to show and then time out in 6 seconds if not handled from the outside.
        /// </summary>
        private async void WaitForConnect()
        {
            Loading = new LoadingUI();
            Task.Run(new Action(() => Loading.Invoke((MethodInvoker)(() => Loading.ShowDialog(this)))));
            await Task.Delay(5000);
            if (_connected)  return;
            Loading.Invoke((MethodInvoker) (() => Loading.statusLabel.Text = "Connection Failed\nShutting Down"));
            await Task.Delay(1000);
            Enabled = true;
            Loading.Close();
        }
        #endregion
    }
}
