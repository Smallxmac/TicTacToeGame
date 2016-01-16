namespace TicTacToeClient.Gui
{
    partial class OnlineMenu
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Online Friends", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Offline Friends", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Pending Friends", System.Windows.Forms.HorizontalAlignment.Left);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Send_Button = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.friendList = new System.Windows.Forms.ListView();
            this.addFriend = new System.Windows.Forms.Button();
            this.friendsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.privateMessageMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFriendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inviteToGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requestOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.approveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.denyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.friendsMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabPage1);
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(561, 457);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.textBox1);
            this.TabPage1.Controls.Add(this.Send_Button);
            this.TabPage1.Controls.Add(this.richTextBox1);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(553, 431);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "SYSTEM";
            this.TabPage1.ToolTipText = "0";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 405);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(455, 20);
            this.textBox1.TabIndex = 2;
            // 
            // Send_Button
            // 
            this.Send_Button.Location = new System.Drawing.Point(468, 402);
            this.Send_Button.Name = "Send_Button";
            this.Send_Button.Size = new System.Drawing.Size(75, 23);
            this.Send_Button.TabIndex = 1;
            this.Send_Button.Text = "Send";
            this.Send_Button.UseVisualStyleBackColor = true;
            this.Send_Button.Click += new System.EventHandler(this.SendButtonClick);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(7, 7);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(536, 389);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // friendList
            // 
            listViewGroup1.Header = "Online Friends";
            listViewGroup1.Name = "onlineFriends";
            listViewGroup2.Header = "Offline Friends";
            listViewGroup2.Name = "offlineFriends";
            listViewGroup3.Header = "Pending Friends";
            listViewGroup3.Name = "pendingFriends";
            this.friendList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.friendList.Location = new System.Drawing.Point(6, 22);
            this.friendList.Name = "friendList";
            this.friendList.Size = new System.Drawing.Size(256, 409);
            this.friendList.TabIndex = 1;
            this.friendList.UseCompatibleStateImageBehavior = false;
            this.friendList.View = System.Windows.Forms.View.SmallIcon;
            this.friendList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.friendList_MouseClick);
            // 
            // addFriend
            // 
            this.addFriend.Location = new System.Drawing.Point(187, 437);
            this.addFriend.Name = "addFriend";
            this.addFriend.Size = new System.Drawing.Size(75, 20);
            this.addFriend.TabIndex = 2;
            this.addFriend.Text = "Add Friend";
            this.addFriend.UseVisualStyleBackColor = true;
            this.addFriend.Click += new System.EventHandler(this.addFriend_Click);
            // 
            // friendsMenu
            // 
            this.friendsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.privateMessageMenu,
            this.removeFriendToolStripMenuItem,
            this.inviteToGameToolStripMenuItem,
            this.requestOptions});
            this.friendsMenu.Name = "friendsMenu";
            this.friendsMenu.Size = new System.Drawing.Size(162, 92);
            // 
            // privateMessageMenu
            // 
            this.privateMessageMenu.Name = "privateMessageMenu";
            this.privateMessageMenu.Size = new System.Drawing.Size(161, 22);
            this.privateMessageMenu.Text = "Message";
            this.privateMessageMenu.Click += new System.EventHandler(this.privateMessageMenu_Click);
            // 
            // removeFriendToolStripMenuItem
            // 
            this.removeFriendToolStripMenuItem.Name = "removeFriendToolStripMenuItem";
            this.removeFriendToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.removeFriendToolStripMenuItem.Text = "Remove Friend";
            // 
            // inviteToGameToolStripMenuItem
            // 
            this.inviteToGameToolStripMenuItem.Name = "inviteToGameToolStripMenuItem";
            this.inviteToGameToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.inviteToGameToolStripMenuItem.Text = "Invite To Game";
            this.inviteToGameToolStripMenuItem.Click += new System.EventHandler(this.inviteToGameToolStripMenuItem_Click);
            // 
            // requestOptions
            // 
            this.requestOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.approveToolStripMenuItem,
            this.denyToolStripMenuItem});
            this.requestOptions.Name = "requestOptions";
            this.requestOptions.Size = new System.Drawing.Size(161, 22);
            this.requestOptions.Text = "Request Options";
            this.requestOptions.Visible = false;
            // 
            // approveToolStripMenuItem
            // 
            this.approveToolStripMenuItem.Name = "approveToolStripMenuItem";
            this.approveToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.approveToolStripMenuItem.Text = "Approve";
            this.approveToolStripMenuItem.Click += new System.EventHandler(this.approveToolStripMenuItem_Click);
            // 
            // denyToolStripMenuItem
            // 
            this.denyToolStripMenuItem.Name = "denyToolStripMenuItem";
            this.denyToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.denyToolStripMenuItem.Text = "Deny";
            this.denyToolStripMenuItem.Click += new System.EventHandler(this.denyToolStripMenuItem_Click);
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(6, 437);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(175, 20);
            this.usernameBox.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.friendList);
            this.groupBox1.Controls.Add(this.addFriend);
            this.groupBox1.Controls.Add(this.usernameBox);
            this.groupBox1.Location = new System.Drawing.Point(628, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 466);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Friends";
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Location = new System.Drawing.Point(12, 559);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(131, 13);
            this.welcomeLabel.TabIndex = 5;
            this.welcomeLabel.Text = "Welcome back, username";
            // 
            // OnlineMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 584);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Name = "OnlineMenu";
            this.Text = "OnlineMenu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnlineMenu_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnlineMenu_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.friendsMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabPage1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Send_Button;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ListView friendList;
        private System.Windows.Forms.Button addFriend;
        private System.Windows.Forms.ContextMenuStrip friendsMenu;
        private System.Windows.Forms.ToolStripMenuItem privateMessageMenu;
        private System.Windows.Forms.ToolStripMenuItem removeFriendToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inviteToGameToolStripMenuItem;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.ToolStripMenuItem requestOptions;
        private System.Windows.Forms.ToolStripMenuItem approveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem denyToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label welcomeLabel;
    }
}