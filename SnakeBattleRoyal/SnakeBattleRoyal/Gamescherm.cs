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
                        CustomLabel piece = new CustomLabel(i*tileWidth, j*tileHeight, tileWidth, tileHeight, Color.Pink);
                        this.Controls.Add(piece);
                    }
                    else if (tile.ToString().Contains("Body"))
                    {
                        CustomLabel piece = new CustomLabel(i * tileWidth, j * tileHeight, tileWidth, tileHeight, Color.Purple); 
                        this.Controls.Add(piece);
                    }
                }
                
            }
        }
    }
}
