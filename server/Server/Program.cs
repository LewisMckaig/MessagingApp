using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Program p = new Program();
            Console.WriteLine();
            Console.WriteLine("Press enter to close program.");
            Console.ReadLine();
        }

        public IPAddress ip = IPAddress.Parse("127.0.0.1");
        public int port = 2000;
        public bool running = true;
        public TcpListener server;  // TCP server

        public X509Certificate2 cert = new X509Certificate2("server.pfx", "instant");


        public Dictionary<string, User> users = new Dictionary<string, User>(); // Stores all user information


        public Program()
        {
            
            Console.Title = "InstantMessenger Server";
            Console.WriteLine("[" + DateTime.Now + "]" + "----- InstantMessenger Server -----");
            Console.WriteLine("Press 1 to see chat logs, press any key to start server.");
            String input = Console.ReadLine();
            if (input == "1")
            {
                MessageList ms = new MessageList();
                ms.displayMessages();
                Console.ReadLine();
            }
            Console.WriteLine("[" + DateTime.Now + "]" + "-----      loading Users      -----");
            LoadUsers();

            server = new TcpListener(ip, port);
            server.Start();
            Console.WriteLine("[" + DateTime.Now + "]" + "-----      Server Started     -----");

            Listen();
        }

        void Listen()  // Listen to incoming connections.
        {
            while (running)
            {
                TcpClient tcpClient = server.AcceptTcpClient();
                Client client = new Client(this, tcpClient);     // Handle in another thread.
            }
        }

        string usersFileName = Environment.CurrentDirectory + "\\users.dat";
        public void SaveUsers()  // Save users data
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = new FileStream(usersFileName, FileMode.Create, FileAccess.Write);
                bf.Serialize(file, users.Values.ToArray());  // Serialize UserInfo array
                file.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public void LoadUsers()  // Load users data
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = new FileStream(usersFileName, FileMode.Open, FileAccess.Read);
                User[] infos = (User[])bf.Deserialize(file);      // Deserialize UserInfo array
                file.Close();
                users = infos.ToDictionary((u) => u.UserName, (u) => u);  // Convert UserInfo array to Dictionary
                Console.WriteLine("[" + DateTime.Now + "]" + "-----     Loaded " + users.Count + " Users     -----");
            }
            catch { }
        }

    }
}
