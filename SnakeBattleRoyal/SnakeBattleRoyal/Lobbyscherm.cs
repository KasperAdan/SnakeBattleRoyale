using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharedMap;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SnakeBattleRoyal
{
    public partial class Lobbyscherm : Form
    {
        private string username;
        private Color userColor = Color.Blue;

        private static TcpClient client;
        private static NetworkStream stream;
        private static byte[] buffer = new byte[1024];
        private static string totalBuffer;
        private static Gamescherm GameForm;

        public Lobbyscherm(string ip, string poort, string username)
        {
            InitializeComponent();
            this.username = username;
            client = new TcpClient();
            client.BeginConnect(ip, int.Parse(poort), new AsyncCallback(OnConnect), null);
        }

        private void OnConnect(IAsyncResult ar)
        {
            client.EndConnect(ar);
            stream = client.GetStream();
            stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);
            Write($"connect\r\n{username}\r\n{userColor.ToArgb()}");
        }

        private void OnRead(IAsyncResult ar)
        {
            int receivedBytes = stream.EndRead(ar);
            string receivedText = Encoding.ASCII.GetString(buffer, 0, receivedBytes);
            totalBuffer += receivedText;

            while (totalBuffer.Contains("\r\n\r\n"))
            {
                string packet = totalBuffer.Substring(0, totalBuffer.IndexOf("\r\n\r\n"));
                totalBuffer = totalBuffer.Substring(totalBuffer.IndexOf("\r\n\r\n") + 4);
                string[] packetData = Regex.Split(packet, "\r\n");
                HandleData(packetData);
            }
            stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);
        }

        public static void Write(string data)
        {
            var dataAsBytes = Encoding.ASCII.GetBytes(data + "\r\n\r\n");
            stream.Write(dataAsBytes, 0, dataAsBytes.Length);
            stream.Flush();
        }

        public void HandleData(string[] packetData)
        {
            Debug.WriteLine($"Packet ontvangen: {packetData[0]}");

            switch (packetData[0])
            {
                case "connect":
                    if (packetData[1] == "ok")
                    {
                        Debug.WriteLine("Connected");
                    }
                    else
                        Debug.WriteLine(packetData[1]);
                    break;
                case "users":
                    JObject json = JObject.Parse(packetData[1]);
                    int userAmount = (int)json["userAmount"];
                    string[] names = new string[userAmount];
                    Color[] colors = new Color[userAmount];
                    for (int i = 0; i < userAmount; i++)
                    {
                        string name = (string)json["data"][i]["username"];
                        Color color = Color.FromArgb((int)(json["data"][i]["color"]));
                        names[i] = name;
                        colors[i] = color;
                    }
                    if (this.InvokeRequired)
                    {
                        Invoke(new MethodInvoker(delegate ()
                        {
                            AddNewPlayerLabelDelegate(names, colors);
                        }));
                    }
                    else
                    {
                        AddNewPlayerLabelDelegate(names, colors);
                    }
                    break;
                //update users 
                case "gamestart":
                    if (this.InvokeRequired)
                    {
                        Invoke(new MethodInvoker(delegate ()
                        {
                            StartGame();
                        }));
                    }
                    else
                    {
                        StartGame();
                    }
                    
                    break;
                case "map":
                    string mapJson = packetData[1];
                    Tiles[,] map = JsonConvert.DeserializeObject<Tiles[,]>(packetData[1]);
                    if (GameForm.InvokeRequired)
                    {
                        Invoke(new MethodInvoker(delegate ()
                        {
                            GameForm.DrawMap(map);
                        }));
                    }
                    else
                    {
                        GameForm.DrawMap(map);
                    }
                    break;
                case "players":
                    string playerJson = packetData[1];
                    GameForm.UpdatePlayers(playerJson);
                    break;
                default:
                    Debug.WriteLine("Did not understand: " + packetData[0]);
                    break;
            }
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            Write("ready");
            playButton.Enabled = false;
        }

        private void StartGame()
        {
            this.Hide();
            GameForm = new Gamescherm(username, userColor/*, client, stream*/);
            GameForm.Closed += (s, args) => this.Close();
            GameForm.Show();
        }

        private void AddNewPlayerLabelDelegate(string[] names, Color[] colors)
        {
            this.Controls.RemoveByKey("playerName");
            int A = 1;
            for (int i = 0; i < names.Count(); i++)
            {
                Label playerName = new Label();
                playerName.Top = A * 28;
                playerName.Left = 15;
                playerName.Text = names[i];
                playerName.ForeColor = colors[i];
                A = A + 1;
                this.Controls.Add(playerName);
            }
        }
    }
}

