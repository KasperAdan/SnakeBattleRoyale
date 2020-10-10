using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeBattleRoyal
{
    public partial class Beginscherm : Form
    {
        public Beginscherm()
        {
            InitializeComponent();
        }
        private void connectButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(namePlayer.Text) || string.IsNullOrEmpty(ipHost.Text) || string.IsNullOrEmpty(portHost.Text))
            {
                MessageBox.Show("Zorg ervoor dat je alle gegevens invuld", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Hide();
                var form2 = new Lobbyscherm(ipHost.Text, portHost.Text, namePlayer.Text);
                form2.Closed += (s, args) => this.Close();
                form2.Show();
            }
        }

        private void connectButton_mouseenter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.FlatAppearance.BorderColor = Color.Green;
        }
        private void connectButton_mouseleave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.FlatAppearance.BorderColor = Color.Empty;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var form3 = new Settingscherm();
            form3.Show(this);
        }

        private void Label_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                connectButton_Click(sender, e);
            }
        }
    }
}
