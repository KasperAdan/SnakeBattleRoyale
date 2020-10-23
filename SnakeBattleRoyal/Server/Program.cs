using Newtonsoft.Json.Linq;
using SharedMap;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Timers;

namespace Server
{
    class Program
    {
        
        private static TcpListener Listener;
        private static EventList<Client> Clients = new EventList<Client>();
        public static MapData Map;
        private static Timer GameTimer;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Server!");
            Listener = new TcpListener(IPAddress.Any, 7777);
            Clients.OnChange += new EventHandler(Clients_OnChange);
            Listener.Start();
            Listener.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);

            GameTimer = new Timer();
            GameTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            // Set the Interval to 500 millisecond. (Time is set in Milliseconds)
            GameTimer.Interval = 500;
            GameTimer.Enabled = false;

            Console.ReadLine();

            while (true)
            {

            }
        }

        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            bool playerDied = Map.UpdateSnakes();
            if (playerDied)
            {
                string playerJson = Map.GetPlayerJson();
                Broadcast($"players\r\n{playerJson}");
            }
            Map.UpdateMap();
            string mapJson = Map.GetMapJson();
            Broadcast($"map\r\n{mapJson}");
            //Map.PrintMap();
        }

        private static void OnConnect(IAsyncResult ar)
        {
            var tcpClient = Listener.EndAcceptTcpClient(ar);
            Console.WriteLine($"Client connected from {tcpClient.Client.RemoteEndPoint}");
            //check if the client already excists
            Clients.Add(new Client(tcpClient));
            Listener.BeginAcceptTcpClient(new AsyncCallback(OnConnect), null);
        }

        internal static void Disconnect(Client client)
        {
            Clients.Remove(client);
            Console.WriteLine("Client disconnected");
        }

        internal static void Broadcast(string packet)
        {
            foreach (var client in Clients)
            {
                client.Write(packet);
            }
        }

        internal static void WriteUsernames()
        {
            string packet = "users\r\n";
            JObject json =
                new JObject(
                    new JProperty("userAmount", Clients.Count()),
                    new JProperty("data", 
                        new JArray(from c in Clients select 
                                   new JObject(
                                       new JProperty("username", c.UserName), 
                                       new JProperty("color", c.UserColor.ToArgb())))));
            string jsonString = json.ToString(Newtonsoft.Json.Formatting.None);
            Broadcast(packet + jsonString);
        }

        internal static void WriteGameStart()
        {
            Broadcast("gamestart");
        }

        private static void Clients_OnChange(object sender, EventArgs e)
        {
            WriteUsernames();
        }

        internal static void InitilizeGame()
        {
            if (Clients.Count < 2)
            {
                return;
            }
            foreach (var client in Clients)
            {
                if (!client.ready)
                {
                    return;
                }
            }

            WriteGameStart();

            string[] names = new string[Clients.Count];
            for (int i = 0; i < Clients.Count; i++)
            {
                names[i] = Clients[i].UserName;
            }
            Color[] colors = new Color[Clients.Count];
            for (int i = 0; i < Clients.Count; i++)
            {
                colors[i] = Clients[i].UserColor;
            }
            Map = new MapData(names, colors);
            GameTimer.Start();
            string playerJson = Map.GetPlayerJson();
            Broadcast($"players\r\n{playerJson}");
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
