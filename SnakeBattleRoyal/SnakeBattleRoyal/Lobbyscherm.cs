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
    public partial class Lobbyscherm : Form
    {
        public Lobbyscherm()
        {
            InitializeComponent();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new Gamescherm();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
    }
}
