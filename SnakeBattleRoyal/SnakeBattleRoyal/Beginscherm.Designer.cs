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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Beginscherm));
            this.namePlayer = new System.Windows.Forms.TextBox();
            this.ipHost = new System.Windows.Forms.TextBox();
            this.portHost = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // namePlayer
            // 
            this.namePlayer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.namePlayer.BackColor = System.Drawing.SystemColors.Control;
            this.namePlayer.Location = new System.Drawing.Point(341, 219);
            this.namePlayer.Name = "namePlayer";
            this.namePlayer.Size = new System.Drawing.Size(169, 22);
            this.namePlayer.TabIndex = 0;
            this.namePlayer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.namePlayer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Label_KeyDown);
            // 
            // ipHost
            // 
            this.ipHost.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ipHost.BackColor = System.Drawing.SystemColors.Control;
            this.ipHost.Location = new System.Drawing.Point(341, 245);
            this.ipHost.Name = "ipHost";
            this.ipHost.Size = new System.Drawing.Size(169, 22);
            this.ipHost.TabIndex = 1;
            this.ipHost.Text = "localhost";
            this.ipHost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ipHost.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Label_KeyDown);
            // 
            // portHost
            // 
            this.portHost.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.portHost.Location = new System.Drawing.Point(455, 334);
            this.portHost.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.portHost.Name = "portHost";
            this.portHost.ReadOnly = true;
            this.portHost.Size = new System.Drawing.Size(169, 22);
            this.portHost.TabIndex = 2;
            this.portHost.Text = "7777";
            this.portHost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.portHost.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Label_KeyDown);
            // 
            // connectButton
            // 
            this.connectButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.connectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.connectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectButton.Location = new System.Drawing.Point(341, 297);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(171, 28);
            this.connectButton.TabIndex = 3;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = false;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            this.connectButton.MouseEnter += new System.EventHandler(this.connectButton_mouseenter);
            this.connectButton.MouseLeave+= new System.EventHandler(this.connectButton_mouseleave);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(295, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Naam:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(285, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "IP Host:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(304, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Port:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox2.Image = global::SnakeBattleRoyal.Properties.Resources.settings;
            this.pictureBox2.Location = new System.Drawing.Point(734, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::SnakeBattleRoyal.Properties.Resources.snake_icon;
            this.pictureBox1.Location = new System.Drawing.Point(455, 105);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(171, 158);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Beginscherm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.ipHost);
            this.Controls.Add(this.portHost);
            this.Controls.Add(this.namePlayer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Beginscherm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Beginscherm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

