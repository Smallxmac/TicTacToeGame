namespace TicTacToeClient.Gui
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loginPanel = new System.Windows.Forms.Panel();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.registerLink = new System.Windows.Forms.LinkLabel();
            this.forgotLink = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.registerPanel = new System.Windows.Forms.Panel();
            this.regBackButton = new System.Windows.Forms.Button();
            this.RegSubmitButton = new System.Windows.Forms.Button();
            this.regEmailBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.regPasswordBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.regPasswordBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.regUsernameBox = new System.Windows.Forms.TextBox();
            this.Register = new System.Windows.Forms.Label();
            this.forgotPanel = new System.Windows.Forms.Panel();
            this.forgotBackButton = new System.Windows.Forms.Button();
            this.forgotSubmitButton = new System.Windows.Forms.Button();
            this.forgotEmailBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.loginPanel.SuspendLayout();
            this.registerPanel.SuspendLayout();
            this.forgotPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginPanel
            // 
            this.loginPanel.Controls.Add(this.passwordBox);
            this.loginPanel.Controls.Add(this.usernameBox);
            this.loginPanel.Controls.Add(this.cancelButton);
            this.loginPanel.Controls.Add(this.loginButton);
            this.loginPanel.Controls.Add(this.registerLink);
            this.loginPanel.Controls.Add(this.forgotLink);
            this.loginPanel.Controls.Add(this.label2);
            this.loginPanel.Controls.Add(this.label1);
            this.loginPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginPanel.Location = new System.Drawing.Point(0, 0);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(232, 150);
            this.loginPanel.TabIndex = 0;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(76, 49);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(141, 20);
            this.passwordBox.TabIndex = 8;
            this.passwordBox.UseSystemPasswordChar = true;
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(76, 16);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(141, 20);
            this.usernameBox.TabIndex = 7;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(142, 116);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(12, 116);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 5;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // registerLink
            // 
            this.registerLink.AutoSize = true;
            this.registerLink.Location = new System.Drawing.Point(171, 89);
            this.registerLink.Name = "registerLink";
            this.registerLink.Size = new System.Drawing.Size(46, 13);
            this.registerLink.TabIndex = 3;
            this.registerLink.TabStop = true;
            this.registerLink.Text = "Register";
            this.registerLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.registerLink_LinkClicked);
            // 
            // forgotLink
            // 
            this.forgotLink.AutoSize = true;
            this.forgotLink.Location = new System.Drawing.Point(12, 89);
            this.forgotLink.Name = "forgotLink";
            this.forgotLink.Size = new System.Drawing.Size(86, 13);
            this.forgotLink.TabIndex = 2;
            this.forgotLink.TabStop = true;
            this.forgotLink.Text = "Forgot Password";
            this.forgotLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.forgotLink_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // registerPanel
            // 
            this.registerPanel.Controls.Add(this.regBackButton);
            this.registerPanel.Controls.Add(this.RegSubmitButton);
            this.registerPanel.Controls.Add(this.regEmailBox);
            this.registerPanel.Controls.Add(this.label6);
            this.registerPanel.Controls.Add(this.regPasswordBox2);
            this.registerPanel.Controls.Add(this.label5);
            this.registerPanel.Controls.Add(this.regPasswordBox);
            this.registerPanel.Controls.Add(this.label4);
            this.registerPanel.Controls.Add(this.regUsernameBox);
            this.registerPanel.Controls.Add(this.Register);
            this.registerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.registerPanel.Location = new System.Drawing.Point(0, 0);
            this.registerPanel.Name = "registerPanel";
            this.registerPanel.Size = new System.Drawing.Size(232, 150);
            this.registerPanel.TabIndex = 1;
            // 
            // regBackButton
            // 
            this.regBackButton.Location = new System.Drawing.Point(175, 145);
            this.regBackButton.Name = "regBackButton";
            this.regBackButton.Size = new System.Drawing.Size(75, 23);
            this.regBackButton.TabIndex = 9;
            this.regBackButton.Text = "Back";
            this.regBackButton.UseVisualStyleBackColor = true;
            this.regBackButton.Click += new System.EventHandler(this.regBackButton_Click);
            // 
            // RegSubmitButton
            // 
            this.RegSubmitButton.Location = new System.Drawing.Point(15, 145);
            this.RegSubmitButton.Name = "RegSubmitButton";
            this.RegSubmitButton.Size = new System.Drawing.Size(75, 23);
            this.RegSubmitButton.TabIndex = 8;
            this.RegSubmitButton.Text = "Submit";
            this.RegSubmitButton.UseVisualStyleBackColor = true;
            this.RegSubmitButton.Click += new System.EventHandler(this.RegSubmitButton_Click);
            // 
            // regEmailBox
            // 
            this.regEmailBox.Location = new System.Drawing.Point(76, 105);
            this.regEmailBox.Name = "regEmailBox";
            this.regEmailBox.Size = new System.Drawing.Size(174, 20);
            this.regEmailBox.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "E-Mail:";
            // 
            // regPasswordBox2
            // 
            this.regPasswordBox2.Location = new System.Drawing.Point(76, 75);
            this.regPasswordBox2.Name = "regPasswordBox2";
            this.regPasswordBox2.Size = new System.Drawing.Size(174, 20);
            this.regPasswordBox2.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Password:";
            // 
            // regPasswordBox
            // 
            this.regPasswordBox.Location = new System.Drawing.Point(76, 45);
            this.regPasswordBox.Name = "regPasswordBox";
            this.regPasswordBox.Size = new System.Drawing.Size(174, 20);
            this.regPasswordBox.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Password:";
            // 
            // regUsernameBox
            // 
            this.regUsernameBox.Location = new System.Drawing.Point(76, 16);
            this.regUsernameBox.Name = "regUsernameBox";
            this.regUsernameBox.Size = new System.Drawing.Size(174, 20);
            this.regUsernameBox.TabIndex = 1;
            // 
            // Register
            // 
            this.Register.AutoSize = true;
            this.Register.Location = new System.Drawing.Point(12, 19);
            this.Register.Name = "Register";
            this.Register.Size = new System.Drawing.Size(58, 13);
            this.Register.TabIndex = 0;
            this.Register.Text = "Username:";
            // 
            // forgotPanel
            // 
            this.forgotPanel.Controls.Add(this.forgotBackButton);
            this.forgotPanel.Controls.Add(this.forgotSubmitButton);
            this.forgotPanel.Controls.Add(this.forgotEmailBox);
            this.forgotPanel.Controls.Add(this.label3);
            this.forgotPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.forgotPanel.Location = new System.Drawing.Point(0, 0);
            this.forgotPanel.Name = "forgotPanel";
            this.forgotPanel.Size = new System.Drawing.Size(232, 150);
            this.forgotPanel.TabIndex = 2;
            // 
            // forgotBackButton
            // 
            this.forgotBackButton.Location = new System.Drawing.Point(175, 56);
            this.forgotBackButton.Name = "forgotBackButton";
            this.forgotBackButton.Size = new System.Drawing.Size(75, 23);
            this.forgotBackButton.TabIndex = 3;
            this.forgotBackButton.Text = "Back";
            this.forgotBackButton.UseVisualStyleBackColor = true;
            this.forgotBackButton.Click += new System.EventHandler(this.regBackButton_Click);
            // 
            // forgotSubmitButton
            // 
            this.forgotSubmitButton.Location = new System.Drawing.Point(15, 56);
            this.forgotSubmitButton.Name = "forgotSubmitButton";
            this.forgotSubmitButton.Size = new System.Drawing.Size(75, 23);
            this.forgotSubmitButton.TabIndex = 2;
            this.forgotSubmitButton.Text = "Submit";
            this.forgotSubmitButton.UseVisualStyleBackColor = true;
            this.forgotSubmitButton.Click += new System.EventHandler(this.forgotSubmitButton_Click);
            // 
            // forgotEmailBox
            // 
            this.forgotEmailBox.Location = new System.Drawing.Point(61, 16);
            this.forgotEmailBox.Name = "forgotEmailBox";
            this.forgotEmailBox.Size = new System.Drawing.Size(189, 20);
            this.forgotEmailBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "E-Mail: ";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 150);
            this.Controls.Add(this.loginPanel);
            this.Controls.Add(this.registerPanel);
            this.Controls.Add(this.forgotPanel);
            this.Name = "Login";
            this.Text = "Login";
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            this.registerPanel.ResumeLayout(false);
            this.registerPanel.PerformLayout();
            this.forgotPanel.ResumeLayout(false);
            this.forgotPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.LinkLabel registerLink;
        private System.Windows.Forms.LinkLabel forgotLink;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel registerPanel;
        private System.Windows.Forms.Panel forgotPanel;
        private System.Windows.Forms.Label Register;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button regBackButton;
        private System.Windows.Forms.Button RegSubmitButton;
        private System.Windows.Forms.TextBox regEmailBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox regPasswordBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox regPasswordBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox regUsernameBox;
        private System.Windows.Forms.Button forgotBackButton;
        private System.Windows.Forms.Button forgotSubmitButton;
        private System.Windows.Forms.TextBox forgotEmailBox;
    }
}