namespace SnakeBattleRoyal
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
            this.namePlayer = new System.Windows.Forms.TextBox();
            this.ipHost = new System.Windows.Forms.TextBox();
            this.portHost = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // namePlayer
            // 
            this.namePlayer.Location = new System.Drawing.Point(327, 150);
            this.namePlayer.Name = "namePlayer";
            this.namePlayer.Size = new System.Drawing.Size(100, 20);
            this.namePlayer.TabIndex = 0;
            this.namePlayer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ipHost
            // 
            this.ipHost.Location = new System.Drawing.Point(327, 176);
            this.ipHost.Name = "ipHost";
            this.ipHost.Size = new System.Drawing.Size(100, 20);
            this.ipHost.TabIndex = 1;
            this.ipHost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // portHost
            // 
            this.portHost.Location = new System.Drawing.Point(327, 202);
            this.portHost.Name = "portHost";
            this.portHost.Size = new System.Drawing.Size(100, 20);
            this.portHost.TabIndex = 2;
            this.portHost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(340, 228);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 3;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // Beginscherm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.ipHost);
            this.Controls.Add(this.portHost);
            this.Controls.Add(this.namePlayer);
            this.Name = "Beginscherm";
            this.Text = "Beginscherm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox namePlayer;
        private System.Windows.Forms.TextBox ipHost;
        private System.Windows.Forms.TextBox portHost;
        private System.Windows.Forms.Button connectButton;
    }
}

