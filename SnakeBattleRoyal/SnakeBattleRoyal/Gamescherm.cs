using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeBattleRoyal
{
    public partial class Gamescherm : Form
    {
        private string Username;
        private Color UserColor;
        private TcpClient Client;
        private NetworkStream Stream;
        private byte[] buffer = new byte[1024];
        private string totalBuffer;
        public Gamescherm(string username, Color userColor, TcpClient client)
        {
            InitializeComponent();

            Username = username;
            UserColor = userColor;
            Client = client;

            Stream = client.GetStream();
            Stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);

            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            this.Size = new Size(screenWidth, screenHeight);
        }

        private void OnRead(IAsyncResult ar)
        {
            int receivedBytes = Stream.EndRead(ar);
            string receivedText = Encoding.ASCII.GetString(buffer, 0, receivedBytes);
            this.totalBuffer += receivedText;

            while (totalBuffer.Contains("\r\n\r\n"))
            {
                string packet = totalBuffer.Substring(0, totalBuffer.IndexOf("\r\n\r\n"));
                totalBuffer = totalBuffer.Substring(totalBuffer.IndexOf("\r\n\r\n") + 4);
                string[] packetData = Regex.Split(packet, "\r\n");
                HandleData(packetData);
            }
            Stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);
        }

        private void Write(string data)
        {
            var dataAsBytes = Encoding.ASCII.GetBytes(data + "\r\n\r\n");
            Stream.Write(dataAsBytes, 0, dataAsBytes.Length);
            Stream.Flush();
        }

        private void HandleData(string[] packetData)
        {
            Debug.WriteLine($"Packet ontvangen: {packetData[0]}");

            switch (packetData[0])
            {
                case "map":
                    string mapJson = packetData[1];
                    break;
                case "players":
                    string playerJson = packetData[1];
                    break;
                default:
                    Debug.WriteLine("Did not understand: " + packetData[0]);
                    break;
            }
        }
    }
}
