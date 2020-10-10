using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        private static TcpListener listener;
        private static List<Client> clients = new List<Client>();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Server!");
            listener = new TcpListener(IPAddress.Any, 7777);
            listener.Start();
            listener.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);

            Console.ReadLine();

            while (true)
            {

            }
        }

        private static void OnConnect(IAsyncResult ar)
        {
            var tcpClient = listener.EndAcceptTcpClient(ar);
            Console.WriteLine($"Client connected from {tcpClient.Client.RemoteEndPoint}");
            //check if the client already excists
            clients.Add(new Client(tcpClient));
            listener.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);
        }

        internal static void Disconnect(Client client)
        {
            clients.Remove(client);
            Console.WriteLine("Client disconnected");
        }

        internal static void Broadcast(string packet)
        {
            foreach (var client in clients)
            {
                client.Write(packet);
            }
        }

        internal static void WriteUsernames()
        {
            string packet = "users\r\n";
            JObject json =
                new JObject(
                    new JProperty("data", 
                        new JArray(from c in clients select 
                                   new JObject(
                                       new JProperty("username", c.UserName), 
                                       new JProperty("color", c.UserColor.ToArgb())))));
            Console.WriteLine(json.ToString());
            Broadcast(packet + json.ToString());
        }
    }
}
