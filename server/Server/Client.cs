using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Text;
using System.Threading;

/**
* 
* name         :   Client.cs
* author       :   Lewis Mckaig
* version      :   1.0
* date         :   23rd November 2019
* description  :   Client class that handles interaction with users and connections
* 
*
* */

namespace Server
{
    class Client
    {
        User user;
        public Client(Program p, TcpClient c)
        {
            prog = p;
            client = c;

            (new Thread(new ThreadStart(SetupConn))).Start();
        }

        Program prog;
        public TcpClient client;
        public NetworkStream netStream;  // Raw-data stream of connection.
        public SslStream ssl;            // Encrypts connection using SSL.
        public BinaryReader br;          // Read simple data
        public BinaryWriter bw;          // Write simple data

        void SetupConn()  // Setup connection
        {
            try
            {
                Console.WriteLine("[{0}] New connection!", DateTime.Now);
                netStream = client.GetStream();
                ssl = new SslStream(netStream, false);
                ssl.AuthenticateAsServer(prog.cert, false, SslProtocols.Tls, true);
                Console.WriteLine("[{0}] Connection authenticated!", DateTime.Now);

                br = new BinaryReader(ssl, Encoding.UTF8);
                bw = new BinaryWriter(ssl, Encoding.UTF8);

                bw.Write(IM_Hello);
                bw.Flush();  // Clears buffer - sends all data to client.

                int hello = br.ReadInt32();
                if (hello == IM_Hello)// If the hello is correct, continue into if
                {
                    byte logMode = br.ReadByte();
                    string userName = br.ReadString();
                    string password = br.ReadString();
                    if (userName.Length < 10)
                    {
                        if (password.Length < 20)
                        {
                            if (logMode == IM_Register)  // Register mode
                            {
                                if (!prog.users.ContainsKey(userName))
                                {
                                    // Register OK
                                    user = new User(userName, password, this);
                                    prog.users.Add(userName, user);
                                    bw.Write(IM_OK);
                                    bw.Flush();
                                    Console.WriteLine("[{0}] ({1}) Registered a new user", DateTime.Now, userName);
                                    prog.SaveUsers();
                                    Receiver();
                                }
                                else
                                    bw.Write(IM_Exists);  // Already exists
                            }
                            else if (logMode == IM_Login)  // Login mode
                            {
                                if (prog.users.TryGetValue(userName, out user))
                                {
                                    if (password == user.Password)
                                    {
                                        // Password is OK.
                                        if (user.LoggedIn)
                                            user.Connection.CloseConn(); // disconnects anyone logged in to the same account

                                        // Associate connection
                                        user.Connection = this;
                                        bw.Write(IM_OK);
                                        bw.Flush();
                                        Receiver();
                                    }
                                    else
                                        bw.Write(IM_WrongPass);  // Wrong password
                                }
                                else
                                    bw.Write(IM_NoExists);  // Doesn't exist
                            }
                        }
                        else
                            bw.Write(IM_TooPassword);
                    }
                    else
                        bw.Write(IM_TooUsername);
                }
                CloseConn();
            }
            catch { CloseConn(); }
        }

        void CloseConn() // Close connection
        {
            try
            {
                user.LoggedIn = false;
                br.Close();
                bw.Close();
                ssl.Close();
                netStream.Close();
                client.Close();
                Console.WriteLine("[{0}] End of connection!", DateTime.Now);
            }
            catch { }
        }

        void Receiver()  // Receive all incoming packets.
        {
            Console.WriteLine("[{0}] ({1}) User logged in", DateTime.Now, user.UserName);
            user.LoggedIn = true;
            MessageList ms = new MessageList();

            try
            {
                while (client.Connected)  // While we are connected.
                {
                    byte type = br.ReadByte();  // Get incoming packet type.

                    if (type == IM_IsAvailable)
                    {
                        string who = br.ReadString();
                        bw.Write(IM_IsAvailable);  // Checks if the user is online
                        bw.Write(who);             // What user is being contacted

                        User user;
                        if (prog.users.TryGetValue(who, out user))
                        {
                            if (user.LoggedIn)
                                bw.Write(true);   // Available
                            else
                                bw.Write(false);  // Unavailable
                        }
                        else
                            bw.Write(false);  // Unavailable
                        bw.Flush();
                    }
                    else if (type == IM_Send)
                    {
                        string to = br.ReadString();
                        string msg = br.ReadString();

                        User recipient;
                        if (prog.users.TryGetValue(to, out recipient))
                        {
                            if (recipient.LoggedIn)
                            {
                                recipient.Connection.bw.Write(IM_Received);
                                recipient.Connection.bw.Write(user.UserName);  // From
                                recipient.Connection.bw.Write(msg); // Message
                                ms.addMessage(user.UserName, msg, recipient.UserName , DateTime.Now);
                                recipient.Connection.bw.Flush();
                                Console.WriteLine(user.UserName + " Sent message to " + recipient.UserName + " at " + DateTime.Now);
                            }
                        }
                    }

                }
            }
            catch (IOException) { } // Thrown, when reading from closed connection.

            user.LoggedIn = false;
            Console.WriteLine("[{0}] ({1}) User logged out", DateTime.Now, user.UserName);
        }

        // Packet types, used to identify messages
        public const int IM_Hello = 2012;      // Hello
        public const byte IM_OK = 0;           // OK
        public const byte IM_Login = 1;        // Login
        public const byte IM_Register = 2;     // Register
        public const byte IM_TooUsername = 3;  // Too long username
        public const byte IM_TooPassword = 4;  // Too long password
        public const byte IM_Exists = 5;       // Already exists
        public const byte IM_NoExists = 6;     // Doesn't exist
        public const byte IM_WrongPass = 7;    // Wrong password
        public const byte IM_IsAvailable = 8;  // Is user available?
        public const byte IM_Send = 9;         // Send message
        public const byte IM_Received = 10;    // Message received
    }
}
