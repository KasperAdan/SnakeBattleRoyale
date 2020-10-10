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
            this.Hide();
            var form2 = new Startscherm(ipHost.Text, portHost.Text, namePlayer.Text);
            form2.Closed += (s, args) => this.Close();
            form2.Show();

        }
    }
}
