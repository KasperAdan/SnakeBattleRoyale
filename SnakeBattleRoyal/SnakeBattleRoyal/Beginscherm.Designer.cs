﻿namespace SnakeBattleRoyal
{
    partial class Beginscherm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Beginscherm));
            this.namePlayer = new System.Windows.Forms.TextBox();
            this.ipHost = new System.Windows.Forms.TextBox();
            this.portHost = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // namePlayer
            // 
            this.namePlayer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.namePlayer.Location = new System.Drawing.Point(341, 219);
            this.namePlayer.Name = "namePlayer";
            this.namePlayer.Size = new System.Drawing.Size(128, 20);
            this.namePlayer.TabIndex = 0;
            this.namePlayer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ipHost
            // 
            this.ipHost.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ipHost.Location = new System.Drawing.Point(341, 245);
            this.ipHost.Name = "ipHost";
            this.ipHost.Size = new System.Drawing.Size(128, 20);
            this.ipHost.TabIndex = 1;
            this.ipHost.Text = "localhost";
            this.ipHost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // portHost
            // 
            this.portHost.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.portHost.Location = new System.Drawing.Point(341, 271);
            this.portHost.Name = "portHost";
            this.portHost.ReadOnly = true;
            this.portHost.Size = new System.Drawing.Size(128, 20);
            this.portHost.TabIndex = 2;
            this.portHost.Text = "7777";
            this.portHost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // connectButton
            // 
            this.connectButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.connectButton.Location = new System.Drawing.Point(341, 297);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(128, 23);
            this.connectButton.TabIndex = 3;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = false;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::SnakeBattleRoyal.Properties.Resources.snake_icon;
            this.pictureBox1.Location = new System.Drawing.Point(341, 85);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Beginscherm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.ipHost);
            this.Controls.Add(this.portHost);
            this.Controls.Add(this.namePlayer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Beginscherm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Beginscherm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox namePlayer;
        private System.Windows.Forms.TextBox ipHost;
        private System.Windows.Forms.TextBox portHost;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

