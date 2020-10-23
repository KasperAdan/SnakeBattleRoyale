using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeBattleRoyal
{
    public partial class Scorescherm : Form
    {
        public Scorescherm(string[] names, int[] scores, Color[] colors)
        {
            InitializeComponent();
            SortScores(names, scores, colors);
        }

        private void SortScores(string[] names, int[] scores, Color[] colors)
        {
            int[] Scores = scores;
            List<Label> labels = new List<Label>();
            for (int j = 0; j < names.Length; j++)
            {
                int highestScore = 0;
                int highestIndex = 0;
                for (int i = 0; i < names.Length; i++)
                {
                    if (highestScore < Scores[i])
                    {
                        highestScore = Scores[i];
                        highestIndex = i;
                    }
                } 
                Label label = new Label();
                label.Text = names[highestIndex] + " - " + Scores[highestIndex];
                label.Top = (labels.Count * 30) + 30;
                label.Left = 15;
                label.ForeColor = colors[highestIndex];
                labels.Add(label);
                Scores[highestIndex] = 0;
            }

            foreach (var item in labels)
            {
                System.Diagnostics.Debug.WriteLine(item.Text);
            }
        }
    }
}
