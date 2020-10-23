using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeBattleRoyal
{
    public partial class Scorescherm : Form
    {
        public Scorescherm(string[] names, int[] scores, Color[] colors)
        {
            InitializeComponent();
            List<Label> labels = SortScores(names, scores, colors);
            foreach (Label label in labels)
            {
                this.Controls.Add(label);
            }
            HighScores();
        }

        private List<Label> SortScores(string[] names, int[] scores, Color[] colors)
        {
            string path = @"c:\temp\MyTest.txt";
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

                if (j == 0)
                {
                    if (File.Exists(path))
                    {
                        using (StreamWriter sw = File.AppendText(path))
                        {
                            sw.WriteLine(label.Text);
                        }
                    }
                    else 
                    {
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            sw.WriteLine(label.Text);
                        }
                    }
                }
            }

            foreach (var item in labels)
            {
                System.Diagnostics.Debug.WriteLine(item.Text);
            }

            return labels;
        }

        private void HighScores()
        {
            List<KeyValuePair<string, int>> dict = new List<KeyValuePair<string, int>>();
            string path = @"c:\temp\MyTest.txt";
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    string[] read = Regex.Split(s, "-");
                    string name = read[0].Trim();
                    int score = int.Parse(read[1]);

                    dict.Add(new KeyValuePair<string,int>(name, score));
                }
                List<KeyValuePair<string,int>> sortedList = dict.OrderBy(x => x.Value).ToList();
                sortedList.Reverse();
                for (int i = 0; i < 10; i++)
                {
                    Label label = new Label();
                    label.Text = sortedList[i].Key + " " + sortedList[i].Value;
                    label.Top = (i * 30) + 75;
                    label.Left = 700;
                    this.Controls.Add(label);
                }
            }
        }
    }
}
