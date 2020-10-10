using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        
        private static TcpListener listener;
        private static EventList<Client> clients = new EventList<Client>();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Server!");
            listener = new TcpListener(IPAddress.Any, 7777);
            clients.OnChange += new EventHandler(Clients_OnChange);
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
            Broadcast(packet + json.ToString());
        }

        private static void Clients_OnChange(object sender, EventArgs e)
        {
            WriteUsernames();
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
