using Newtonsoft.Json.Linq;
using SharedMap;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeBattleRoyal
{
    public partial class Gamescherm : Form
    {
        private int screenWidth;
        private int screenHeight;

        private string[] Names;
        private int[] Scores;
        private bool[] Alive;
        private Color[] Colors;
        private bool scoresShowed = false;

        public Gamescherm()
        {
            InitializeComponent();
            screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            this.Size = new Size(screenWidth, screenHeight);
        }

        internal void UpdatePlayers(string jsonString)
        {
            JObject json = JObject.Parse(jsonString);
            int snakeAmount = (int)json["amount"];

            Names = new string[snakeAmount];
            Scores = new int[snakeAmount];
            Alive = new bool[snakeAmount];
            Colors = new Color[snakeAmount];
            int playersAlive = 0;

            for (int i = 0; i < snakeAmount; i++)
            {
                string name = (string)json["players"][i]["username"];
                int score = (int)json["players"][i]["score"];
                bool alive = (bool)json["players"][i]["alive"];
                Color color = Color.FromArgb((int)(json["players"][i]["color"]));

                Names[i] = name;
                Scores[i] = score;
                Alive[i] = alive;
                Colors[i] = color;

                if (alive)
                {
                    playersAlive++;
                }
            }
            if (playersAlive < 2 && !scoresShowed)
            {
                scoresShowed = true;
                if (this.InvokeRequired)
                {
                    Invoke(new MethodInvoker(delegate ()
                    {
                        this.Hide();
                        Scorescherm scorescherm = new Scorescherm(Names, Scores, Colors);
                        scorescherm.Closed += (s, args) => this.Close();
                        scorescherm.Show();
                    }));
                }
                else
                {
                    this.Hide();
                    Scorescherm scorescherm = new Scorescherm(Names, Scores, Colors);
                    scorescherm.Closed += (s, args) => this.Close();
                    scorescherm.Show();
                }
                
            }
        }

        private void Gamescherm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'w')
            {
                Lobbyscherm.Write("keypress\r\nUP");
                Debug.WriteLine("W key pressed");
            }
            if (e.KeyChar == 'a')
            {
                Lobbyscherm.Write("keypress\r\nLEFT");
                Debug.WriteLine("A key pressed");
            }
            if (e.KeyChar == 's')
            {
                Lobbyscherm.Write("keypress\r\nDOWN");
                Debug.WriteLine("S key pressed");
            }
            if (e.KeyChar == 'd')
            {
                Lobbyscherm.Write("keypress\r\nRIGHT");
                Debug.WriteLine("D key pressed");
            }
        }

        internal void DrawMap(Tiles[,] Map)
        {
            this.Controls.Clear();
            int tileWidth = screenWidth / MapData.COLUMNS;
            int tileHeight = screenHeight / MapData.ROWS;
            for (int i = 0; i < MapData.ROWS; i++)
            {
                for (int j = 0; j < MapData.COLUMNS; j++)
                {
                    Tiles tile = Map[i, j];
                    if (tile == Tiles.Empty)
                    {
                        continue;
                    }
                    else if (tile.ToString().Contains("Head"))
                    {
                        CustomLabel piece = new CustomLabel(i * tileWidth, j * tileHeight, tileWidth, tileHeight, Color.Black, true);

                        switch (tile)
                        {
                            case Tiles.HeadPlayer1:
                                piece = new CustomLabel(i * tileWidth, j * tileHeight, tileWidth, tileHeight, Colors[0], true);
                                break;
                            case Tiles.HeadPlayer2:
                                piece = new CustomLabel(i * tileWidth, j * tileHeight, tileWidth, tileHeight, Colors[1], true);
                                break;
                            case Tiles.HeadPlayer3:
                                piece = new CustomLabel(i * tileWidth, j * tileHeight, tileWidth, tileHeight, Colors[2], true);
                                break;
                            case Tiles.HeadPlayer4:
                                piece = new CustomLabel(i * tileWidth, j * tileHeight, tileWidth, tileHeight, Colors[3], true);
                                break;
                            case Tiles.HeadPlayer5:
                                piece = new CustomLabel(i * tileWidth, j * tileHeight, tileWidth, tileHeight, Colors[4], true);
                                break;
                            case Tiles.HeadPlayer6:
                                piece = new CustomLabel(i * tileWidth, j * tileHeight, tileWidth, tileHeight, Colors[5], true);
                                break;
                            case Tiles.HeadPlayer7:
                                piece = new CustomLabel(i * tileWidth, j * tileHeight, tileWidth, tileHeight, Colors[6], true);
                                break;
                            case Tiles.HeadPlayer8:
                                piece = new CustomLabel(i * tileWidth, j * tileHeight, tileWidth, tileHeight, Colors[7], true);
                                break;
                        }
                        this.Controls.Add(piece);
                    }
                    else if (tile.ToString().Contains("Body"))
                    {
                        CustomLabel piece = new CustomLabel(i * tileWidth, j * tileHeight, tileWidth, tileHeight, Color.Black, false);

                        switch (tile)
                        {
                            case Tiles.BodyPlayer1:
                                piece = new CustomLabel(i * tileWidth, j * tileHeight, tileWidth, tileHeight, Colors[0], false);
                                break;
                            case Tiles.BodyPlayer2:
                                piece = new CustomLabel(i * tileWidth, j * tileHeight, tileWidth, tileHeight, Colors[1], false);
                                break;
                            case Tiles.BodyPlayer3:
                                piece = new CustomLabel(i * tileWidth, j * tileHeight, tileWidth, tileHeight, Colors[2], false);
                                break;
                            case Tiles.BodyPlayer4:
                                piece = new CustomLabel(i * tileWidth, j * tileHeight, tileWidth, tileHeight, Colors[3], false);
                                break;
                            case Tiles.BodyPlayer5:
                                piece = new CustomLabel(i * tileWidth, j * tileHeight, tileWidth, tileHeight, Colors[4], false);
                                break;
                            case Tiles.BodyPlayer6:
                                piece = new CustomLabel(i * tileWidth, j * tileHeight, tileWidth, tileHeight, Colors[5], false);
                                break;
                            case Tiles.BodyPlayer7:
                                piece = new CustomLabel(i * tileWidth, j * tileHeight, tileWidth, tileHeight, Colors[6], false);
                                break;
                            case Tiles.BodyPlayer8:
                                piece = new CustomLabel(i * tileWidth, j * tileHeight, tileWidth, tileHeight, Colors[7], false);
                                break;
                        }
                        this.Controls.Add(piece);
                    }
                    else if (tile == Tiles.Apple)
                    {
                        CustomLabel piece = new CustomLabel(i * tileWidth, j *tileHeight, tileWidth, tileHeight, Color.Red, true);
                        this.Controls.Add(piece);
                    }
                }
            }
        }
    }
}
