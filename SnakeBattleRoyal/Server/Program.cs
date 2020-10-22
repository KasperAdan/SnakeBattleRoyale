using Newtonsoft.Json.Linq;
using SharedMap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        
        private static TcpListener listener;
        private static EventList<Client> clients = new EventList<Client>();
        private static MapData Map;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Server!");
            listener = new TcpListener(IPAddress.Any, 7777);
            clients.OnChange += new EventHandler(Clients_OnChange);
            listener.Start();
            listener.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);

            InitilizeGame();

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
                    new JProperty("userAmount", clients.Count()),
                    new JProperty("data", 
                        new JArray(from c in clients select 
                                   new JObject(
                                       new JProperty("username", c.UserName), 
                                       new JProperty("color", c.UserColor.ToArgb())))));
            string jsonString = json.ToString(Newtonsoft.Json.Formatting.None);
            Broadcast(packet + jsonString);
        }

        private static void Clients_OnChange(object sender, EventArgs e)
        {
            WriteUsernames();
        }

        internal static void InitilizeGame()
        {
            //string[] names = new string[clients.Count];
            //for (int i = 0; i < clients.Count; i++)
            //{
            //    names[i] = clients[i].UserName;
            //}
            //Color[] colors = new Color[clients.Count];
            //for (int i = 0; i < clients.Count; i++)
            //{
            //    colors[i] = clients[i].UserColor;
            //}
            string[] names = new string[] { "Kasper", "Daphne", "Lucas", "Leslie"};
            Color[] colors = new Color[] { Color.Blue, Color.Gold, Color.Gold, Color.Gold };
            Map = new MapData(names, colors);

            Map = new MapData(Map.GetMapJson());
            Map.PrintMap();
        }
    }
    #region Class EventList
    class EventList<T> : List<T>
    {
        public event EventHandler OnChange;

        public new void Add(T item)
        {
            base.Add(item);
            if (null != OnChange)
            {
                OnChange(this, null);
            }
        }

        public new void Remove(T item)
        {
            base.Remove(item);
            if (null != OnChange)
            {
                OnChange(this, null);
            }
        }
    }
    #endregion
}
