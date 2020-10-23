    using SharedMap;
using System;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace Server
{
    class Client
    {
        public string UserName { get; set; }

        public Color UserColor { get; set; }

        public bool ready = false;
        private TcpClient tcpClient;
        private NetworkStream stream;
        private byte[] buffer = new byte[1024];
        private string totalBuffer = "";

        public Client(TcpClient tcpClient, Color color)
        {
            this.tcpClient = tcpClient;
            this.stream = this.tcpClient.GetStream();
            UserColor = color;
            this.stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);
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
            this.stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);
        }

        private void HandleData(string[] packetData)
        {
            Console.WriteLine($"{UserName}: {packetData[0]}");
            switch (packetData[0])
            {
                case "connect":
                    this.UserName = packetData[1];
                    Console.WriteLine($"User {this.UserName} is connected");
                    Write("connect\r\nok");
                    break;
                case "ready":
                    this.ready = true;
                    Program.InitilizeGame();
                    break;
                case "keypress":
                    Program.Map.UpdateDirection(UserName, (Direction)Enum.Parse(typeof(Direction), packetData[1]));
                    break;
                default:
                    Console.WriteLine("Did not understand: " + packetData[0]);
                    break;
            }
        }

        public void Write(string data)
        {
            var dataAsBytes = Encoding.ASCII.GetBytes(data + "\r\n\r\n");
            stream.Write(dataAsBytes, 0, dataAsBytes.Length);
            stream.Flush();
        }
    }
}