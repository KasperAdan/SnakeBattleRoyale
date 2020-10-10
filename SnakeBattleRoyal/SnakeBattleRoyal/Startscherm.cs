using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeBattleRoyal
{
    public partial class Startscherm : Form
    {
        private string username;

        private TcpClient client;
        private NetworkStream stream;
        private byte[] buffer = new byte[1024];
        private string totalBuffer;

        public Startscherm(string ip, string poort, string username)
        {
            InitializeComponent();
            this.username = username;
            this.client = new TcpClient();
            client.BeginConnect(ip, int.Parse(poort), new AsyncCallback(OnConnect), null);

        }


        private void OnConnect(IAsyncResult ar)
        {
            client.EndConnect(ar);
            stream = client.GetStream();
            stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);
            Write($"connect\r\n{username}");

        }

        private void OnRead(IAsyncResult ar)
        {
            int receivedBytes = stream.EndRead(ar);
            string receivedText = Encoding.ASCII.GetString(buffer, 0, receivedBytes);
            this.totalBuffer += receivedText;

            while (totalBuffer.Contains("\r\n\r\n"))
            {
                string packet = totalBuffer.Substring(0, totalBuffer.IndexOf("\r\n\r\n"));
                totalBuffer = totalBuffer.Substring(totalBuffer.IndexOf("\r\n\r\n") + 4);
                string[] packetData = Regex.Split(packet, "\r\n");
                HandleData(packetData);
            }
            stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);
        }

        private void Write(string data)
        {
            var dataAsBytes = Encoding.ASCII.GetBytes(data + "\r\n\r\n");
            stream.Write(dataAsBytes, 0, dataAsBytes.Length);
            stream.Flush();
        }

        private static void HandleData(string[] packetData)
        {
            //Console.WriteLine($"Packet ontvangen: {packetData[0]}");

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
                default:
                    Debug.WriteLine("Did not understand: " + packetData[0]);
                    break;
            }
        }
    }
}
