namespace TicTacToeClient.Gui
{
    partial class GameBoard
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
            this.gamePanel = new System.Windows.Forms.Panel();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.startButton = new System.Windows.Forms.Button();
            this.firstTurn = new System.Windows.Forms.CheckBox();
            this.botDifficulty = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.playerSpaceType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.roundCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.roundLable = new System.Windows.Forms.Label();
            this.turnLable = new System.Windows.Forms.Label();
            this.menuPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roundCount)).BeginInit();
            this.SuspendLayout();
            // 
            // gamePanel
            // 
            this.gamePanel.BackColor = System.Drawing.SystemColors.Control;
            this.gamePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gamePanel.Location = new System.Drawing.Point(12, 12);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(600, 600);
            this.gamePanel.TabIndex = 0;
            this.gamePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.gamePanel_Paint);
            this.gamePanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gamePanel_MouseClick);
            // 
            // menuPanel
            // 
            this.menuPanel.Controls.Add(this.groupBox1);
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(512, 171);
            this.menuPanel.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.startButton);
            this.groupBox1.Controls.Add(this.firstTurn);
            this.groupBox1.Controls.Add(this.botDifficulty);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.playerSpaceType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.roundCount);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.typeBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(17, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(477, 136);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game Settings";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(270, 88);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(190, 23);
            this.startButton.TabIndex = 9;
            this.startButton.Text = "Begin";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.BeginButtonClick);
            // 
            // firstTurn
            // 
            this.firstTurn.AutoSize = true;
            this.firstTurn.Location = new System.Drawing.Point(270, 54);
            this.firstTurn.Name = "firstTurn";
            this.firstTurn.Size = new System.Drawing.Size(131, 17);
            this.firstTurn.TabIndex = 8;
            this.firstTurn.Text = "Player One First Turn?";
            this.firstTurn.UseVisualStyleBackColor = true;
            // 
            // botDifficulty
            // 
            this.botDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.botDifficulty.FormattingEnabled = true;
            this.botDifficulty.Items.AddRange(new object[] {
            "Easy",
            "Normal",
            "Hard"});
            this.botDifficulty.Location = new System.Drawing.Point(339, 17);
            this.botDifficulty.Name = "botDifficulty";
            this.botDifficulty.Size = new System.Drawing.Size(121, 21);
            this.botDifficulty.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(267, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Bot Difficulty";
            // 
            // playerSpaceType
            // 
            this.playerSpaceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.playerSpaceType.FormattingEnabled = true;
            this.playerSpaceType.Items.AddRange(new object[] {
            "X",
            "O"});
            this.playerSpaceType.Location = new System.Drawing.Point(86, 90);
            this.playerSpaceType.Name = "playerSpaceType";
            this.playerSpaceType.Size = new System.Drawing.Size(121, 21);
            this.playerSpaceType.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Player 1 Type";
            // 
            // roundCount
            // 
            this.roundCount.Location = new System.Drawing.Point(86, 53);
            this.roundCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.roundCount.Name = "roundCount";
            this.roundCount.Size = new System.Drawing.Size(120, 20);
            this.roundCount.TabIndex = 3;
            this.roundCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Round Count";
            // 
            // typeBox
            // 
            this.typeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeBox.Items.AddRange(new object[] {
            "Player Vs Bot",
            "Player Vs Player"});
            this.typeBox.Location = new System.Drawing.Point(86, 17);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(121, 21);
            this.typeBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Game Type";
            // 
            // roundLable
            // 
            this.roundLable.AutoSize = true;
            this.roundLable.Location = new System.Drawing.Point(9, 619);
            this.roundLable.Name = "roundLable";
            this.roundLable.Size = new System.Drawing.Size(62, 13);
            this.roundLable.TabIndex = 1;
            this.roundLable.Text = "Round: 1/1";
            // 
            // turnLable
            // 
            this.turnLable.AutoSize = true;
            this.turnLable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.turnLable.Location = new System.Drawing.Point(502, 619);
            this.turnLable.Name = "turnLable";
            this.turnLable.Size = new System.Drawing.Size(110, 13);
            this.turnLable.TabIndex = 2;
            this.turnLable.Text = "Current Turn: Player 1";
            this.turnLable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 641);
            this.Controls.Add(this.turnLable);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.roundLable);
            this.Controls.Add(this.gamePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(640, 680);
            this.Name = "GameBoard";
            this.Text = "TicTacToe GameBoard";
            this.menuPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roundCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox typeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown roundCount;
        private System.Windows.Forms.ComboBox botDifficulty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox playerSpaceType;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.CheckBox firstTurn;
        private System.Windows.Forms.Label turnLable;
        private System.Windows.Forms.Label roundLable;
    }
}