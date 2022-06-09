namespace Durak
{
    partial class frmMainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainMenu));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblHowToPlay = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.lblRules = new System.Windows.Forms.Label();
            this.ttpMainMenu = new System.Windows.Forms.ToolTip(this.components);
            this.rad36Cards = new System.Windows.Forms.RadioButton();
            this.rad20Cards = new System.Windows.Forms.RadioButton();
            this.rad52Cards = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblStandard = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.chkRestart = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("A Love of Thunder", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(175, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(82, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Durak";
            // 
            // lblHowToPlay
            // 
            this.lblHowToPlay.Location = new System.Drawing.Point(283, 72);
            this.lblHowToPlay.Name = "lblHowToPlay";
            this.lblHowToPlay.Size = new System.Drawing.Size(167, 40);
            this.lblHowToPlay.TabIndex = 4;
            this.lblHowToPlay.Text = "How many cards would you like to play with?";
            // 
            // btnPlay
            // 
            this.btnPlay.Font = new System.Drawing.Font("A Love of Thunder", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.Location = new System.Drawing.Point(286, 267);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(145, 49);
            this.btnPlay.TabIndex = 5;
            this.btnPlay.Text = "Play";
            this.ttpMainMenu.SetToolTip(this.btnPlay, "Play to play the game!");
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // lblRules
            // 
            this.lblRules.AutoSize = true;
            this.lblRules.Location = new System.Drawing.Point(28, 72);
            this.lblRules.Name = "lblRules";
            this.lblRules.Size = new System.Drawing.Size(120, 17);
            this.lblRules.TabIndex = 6;
            this.lblRules.Text = "You VS Computer";
            // 
            // rad36Cards
            // 
            this.rad36Cards.AutoSize = true;
            this.rad36Cards.Location = new System.Drawing.Point(286, 125);
            this.rad36Cards.Name = "rad36Cards";
            this.rad36Cards.Size = new System.Drawing.Size(86, 21);
            this.rad36Cards.TabIndex = 8;
            this.rad36Cards.TabStop = true;
            this.rad36Cards.Text = "36 Cards";
            this.ttpMainMenu.SetToolTip(this.rad36Cards, "Every suit from six to ace is played");
            this.rad36Cards.UseVisualStyleBackColor = true;
            // 
            // rad20Cards
            // 
            this.rad20Cards.AutoSize = true;
            this.rad20Cards.Location = new System.Drawing.Point(286, 152);
            this.rad20Cards.Name = "rad20Cards";
            this.rad20Cards.Size = new System.Drawing.Size(86, 21);
            this.rad20Cards.TabIndex = 9;
            this.rad20Cards.TabStop = true;
            this.rad20Cards.Text = "20 Cards";
            this.ttpMainMenu.SetToolTip(this.rad20Cards, "Every suit from ten to ace is used");
            this.rad20Cards.UseVisualStyleBackColor = true;
            // 
            // rad52Cards
            // 
            this.rad52Cards.AutoSize = true;
            this.rad52Cards.Location = new System.Drawing.Point(286, 179);
            this.rad52Cards.Name = "rad52Cards";
            this.rad52Cards.Size = new System.Drawing.Size(86, 21);
            this.rad52Cards.TabIndex = 10;
            this.rad52Cards.TabStop = true;
            this.rad52Cards.Text = "52 Cards";
            this.ttpMainMenu.SetToolTip(this.rad52Cards, "Game is played with 52 cards");
            this.rad52Cards.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(482, 28);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // lblStandard
            // 
            this.lblStandard.AutoSize = true;
            this.lblStandard.ForeColor = System.Drawing.Color.DarkGray;
            this.lblStandard.Location = new System.Drawing.Point(390, 125);
            this.lblStandard.Name = "lblStandard";
            this.lblStandard.Size = new System.Drawing.Size(66, 17);
            this.lblStandard.TabIndex = 11;
            this.lblStandard.Text = "Standard";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(286, 206);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(145, 22);
            this.txtName.TabIndex = 12;
            this.txtName.Text = "Player";
            // 
            // chkRestart
            // 
            this.chkRestart.AutoSize = true;
            this.chkRestart.Location = new System.Drawing.Point(286, 235);
            this.chkRestart.Name = "chkRestart";
            this.chkRestart.Size = new System.Drawing.Size(166, 21);
            this.chkRestart.TabIndex = 13;
            this.chkRestart.Text = "Restart Name && Stats";
            this.chkRestart.UseVisualStyleBackColor = true;
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 328);
            this.Controls.Add(this.chkRestart);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblStandard);
            this.Controls.Add(this.rad52Cards);
            this.Controls.Add(this.rad20Cards);
            this.Controls.Add(this.rad36Cards);
            this.Controls.Add(this.lblRules);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.lblHowToPlay);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Durak";
            this.Load += new System.EventHandler(this.frmMainMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblHowToPlay;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label lblRules;
        private System.Windows.Forms.ToolTip ttpMainMenu;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label lblStandard;
        public System.Windows.Forms.RadioButton rad36Cards;
        public System.Windows.Forms.RadioButton rad20Cards;
        public System.Windows.Forms.RadioButton rad52Cards;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.CheckBox chkRestart;
    }
}

