﻿namespace PackManFormGame
{
    partial class frmPacmanGame
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblLScore = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblLVL = new System.Windows.Forms.Label();
            this.lblLVLValue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.pcrRedBox = new System.Windows.Forms.PictureBox();
            this.pcrBlueGhost = new System.Windows.Forms.PictureBox();
            this.pcrYellowGhost = new System.Windows.Forms.PictureBox();
            this.pcrRedGost = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDelay = new System.Windows.Forms.Label();
            this.pnlBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcrRedBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcrBlueGhost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcrYellowGhost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcrRedGost)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblPosition.ForeColor = System.Drawing.Color.White;
            this.lblPosition.Location = new System.Drawing.Point(12, 41);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(14, 13);
            this.lblPosition.TabIndex = 1;
            this.lblPosition.Text = "0";
            // 
            // lblLScore
            // 
            this.lblLScore.AutoSize = true;
            this.lblLScore.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblLScore.ForeColor = System.Drawing.Color.White;
            this.lblLScore.Location = new System.Drawing.Point(24, 9);
            this.lblLScore.Name = "lblLScore";
            this.lblLScore.Size = new System.Drawing.Size(70, 23);
            this.lblLScore.TabIndex = 2;
            this.lblLScore.Text = "Score";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblScore.ForeColor = System.Drawing.Color.White;
            this.lblScore.Location = new System.Drawing.Point(51, 34);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(22, 23);
            this.lblScore.TabIndex = 3;
            this.lblScore.Text = "0";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLVL
            // 
            this.lblLVL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLVL.AutoSize = true;
            this.lblLVL.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblLVL.ForeColor = System.Drawing.Color.White;
            this.lblLVL.Location = new System.Drawing.Point(308, 9);
            this.lblLVL.Name = "lblLVL";
            this.lblLVL.Size = new System.Drawing.Size(70, 23);
            this.lblLVL.TabIndex = 4;
            this.lblLVL.Text = "Level";
            // 
            // lblLVLValue
            // 
            this.lblLVLValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLVLValue.AutoSize = true;
            this.lblLVLValue.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblLVLValue.ForeColor = System.Drawing.Color.White;
            this.lblLVLValue.Location = new System.Drawing.Point(333, 34);
            this.lblLVLValue.Name = "lblLVLValue";
            this.lblLVLValue.Size = new System.Drawing.Size(22, 23);
            this.lblLVLValue.TabIndex = 5;
            this.lblLVLValue.Text = "1";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(9, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "High Score";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Courier New", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(39, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "99999";
            // 
            // pnlBoard
            // 
            this.pnlBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBoard.Controls.Add(this.pcrRedBox);
            this.pnlBoard.Controls.Add(this.pcrBlueGhost);
            this.pnlBoard.Controls.Add(this.pcrYellowGhost);
            this.pnlBoard.Controls.Add(this.pcrRedGost);
            this.pnlBoard.Location = new System.Drawing.Point(0, 61);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(697, 771);
            this.pnlBoard.TabIndex = 0;
            // 
            // pcrRedBox
            // 
            this.pcrRedBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pcrRedBox.BackgroundImage = global::PackManFormGame.Properties.Resources.RedGost;
            this.pcrRedBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcrRedBox.Location = new System.Drawing.Point(338, 328);
            this.pcrRedBox.Name = "pcrRedBox";
            this.pcrRedBox.Size = new System.Drawing.Size(30, 30);
            this.pcrRedBox.TabIndex = 11;
            this.pcrRedBox.TabStop = false;
            // 
            // pcrBlueGhost
            // 
            this.pcrBlueGhost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pcrBlueGhost.BackgroundImage = global::PackManFormGame.Properties.Resources.BlueGhost;
            this.pcrBlueGhost.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcrBlueGhost.Location = new System.Drawing.Point(302, 348);
            this.pcrBlueGhost.Name = "pcrBlueGhost";
            this.pcrBlueGhost.Size = new System.Drawing.Size(30, 30);
            this.pcrBlueGhost.TabIndex = 10;
            this.pcrBlueGhost.TabStop = false;
            // 
            // pcrYellowGhost
            // 
            this.pcrYellowGhost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pcrYellowGhost.BackgroundImage = global::PackManFormGame.Properties.Resources.YellowGost;
            this.pcrYellowGhost.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcrYellowGhost.Location = new System.Drawing.Point(338, 364);
            this.pcrYellowGhost.Name = "pcrYellowGhost";
            this.pcrYellowGhost.Size = new System.Drawing.Size(30, 30);
            this.pcrYellowGhost.TabIndex = 9;
            this.pcrYellowGhost.TabStop = false;
            // 
            // pcrRedGost
            // 
            this.pcrRedGost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pcrRedGost.BackgroundImage = global::PackManFormGame.Properties.Resources.PinkGost;
            this.pcrRedGost.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcrRedGost.Location = new System.Drawing.Point(374, 348);
            this.pcrRedGost.Name = "pcrRedGost";
            this.pcrRedGost.Size = new System.Drawing.Size(30, 30);
            this.pcrRedGost.TabIndex = 8;
            this.pcrRedGost.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblLScore);
            this.panel1.Controls.Add(this.lblScore);
            this.panel1.Location = new System.Drawing.Point(132, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(114, 59);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(436, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(148, 59);
            this.panel2.TabIndex = 13;
            // 
            // lblDelay
            // 
            this.lblDelay.AutoSize = true;
            this.lblDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDelay.ForeColor = System.Drawing.Color.White;
            this.lblDelay.Location = new System.Drawing.Point(12, 16);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(14, 13);
            this.lblDelay.TabIndex = 14;
            this.lblDelay.Text = "0";
            // 
            // frmPacmanGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(698, 831);
            this.Controls.Add(this.lblDelay);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblLVLValue);
            this.Controls.Add(this.lblLVL);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.pnlBoard);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPacmanGame";
            this.Text = "Pacman";
            this.Activated += new System.EventHandler(this.frmPacmanGame_Activated);
            this.Deactivate += new System.EventHandler(this.frmPacmanGame_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPacmanGame_FormClosing);
            this.Load += new System.EventHandler(this.frmPacmanGame_Load);
            this.Shown += new System.EventHandler(this.frmPacmanGame_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmPacmanGame_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPacmanGame_KeyDown);
            this.Resize += new System.EventHandler(this.frmPacmanGame_Resize);
            this.pnlBoard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcrRedBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcrBlueGhost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcrYellowGhost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcrRedGost)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblLScore;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblLVL;
        private System.Windows.Forms.Label lblLVLValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pcrRedGost;
        private System.Windows.Forms.PictureBox pcrRedBox;
        private System.Windows.Forms.PictureBox pcrBlueGhost;
        private System.Windows.Forms.PictureBox pcrYellowGhost;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblDelay;
    }
}
