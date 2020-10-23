using Newtonsoft.Json.Linq;
using SharedMap;
using System.Diagnostics;
using System.Drawing;
using System.Net.Sockets;
using System.Windows.Forms;

namespace SnakeBattleRoyal
{
    public partial class Gamescherm : Form
    {
        private string Username;
        private Color UserColor;
        //private TcpClient Client;
        //private NetworkStream Stream;
        //private byte[] buffer = new byte[1024];
        //private string totalBuffer;
        private int screenWidth;
        private int screenHeight;

        private string[] Names;
        private int[] Scores;
        private bool[] Alive;
        private Color[] Colors;

        public Gamescherm(string username, Color userColor/*, TcpClient client, NetworkStream stream*/)
        {
            InitializeComponent();

            Username = username;
            UserColor = userColor;
            //Client = client;
            //Stream = stream;

            //Stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);

            screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            this.Size = new Size(screenWidth, screenHeight);
            //if ()
            //{
            //    this.Hide();
            //    var form2 = new Scorescherm();
            //    form2.Closed += (s, args) => this.Close();
            //    form2.Show();
            //}
        }

        internal void UpdatePlayers(string jsonString)
        {
            JObject json = JObject.Parse(jsonString);
            int snakeAmount = (int)json["amount"];

            Names = new string[snakeAmount];
            Scores = new int[snakeAmount];
            Alive = new bool[snakeAmount];
            Colors = new Color[snakeAmount];

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
            }
        }

        //private void OnRead(IAsyncResult ar)
        //{
        //    int receivedBytes = Stream.EndRead(ar);
        //    string receivedText = Encoding.ASCII.GetString(buffer, 0, receivedBytes);
        //    this.totalBuffer += receivedText;

        //    while (totalBuffer.Contains("\r\n\r\n"))
        //    {
        //        string packet = totalBuffer.Substring(0, totalBuffer.IndexOf("\r\n\r\n"));
        //        totalBuffer = totalBuffer.Substring(totalBuffer.IndexOf("\r\n\r\n") + 4);
        //        string[] packetData = Regex.Split(packet, "\r\n");
        //        HandleData(packetData);
        //    }
        //    Stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);
        //}

        //private void Write(string data)
        //{
        //    var dataAsBytes = Encoding.ASCII.GetBytes(data + "\r\n\r\n");
        //    Stream.Write(dataAsBytes, 0, dataAsBytes.Length);
        //    Stream.Flush();
        //}

        //private void HandleData(string[] packetData)
        //{
        //    Debug.WriteLine($"Packet ontvangen: {packetData[0]}");

        //    switch (packetData[0])
        //    {

        //        default:
        //            Debug.WriteLine("Did not understand: " + packetData[0]);
        //            break;
        //    }
        //}

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
