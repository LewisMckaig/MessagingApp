using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MMApp
{
    public class Client
    {
        Thread tcpThread;      // Connection thread
        bool _conn = false;    // Is connected/connecting?
        bool _logged = false;  // Is logged in?
        string _user;          // Username
        string _pass;          // Password
        bool reg;              // Register mode

        /**
        In production versions the server string will be set to the IP of the computer running the server, however I cannot guarantee the IP of the computer during testing 
        */
        public string Server { get { return "localhost"; } } 
        public int Port { get { return 2000; } }

        public bool IsLoggedIn { get { return _logged; } }
        public string UserName { get { return _user; } }
        public string Password { get { return _pass; } }

        // Events
        public event EventHandler LoginOK;
        public event EventHandler RegisterOK;
        public event IMErrorEventHandler LoginFailed;
        public event IMErrorEventHandler RegisterFailed;
        public event EventHandler Disconnected;
        public event IMAvailEventHandler UserAvailable;
        public event IMReceivedEventHandler MessageReceived;

        void SetupConn()  // Setup connection and login
        {
            client = new TcpClient(Server, Port);
            netStream = client.GetStream();
            ssl = new SslStream(netStream, false, new RemoteCertificateValidationCallback(ValidateCert));
            ssl.AuthenticateAsClient("Server");

            br = new BinaryReader(ssl, Encoding.UTF8);
            bw = new BinaryWriter(ssl, Encoding.UTF8);
            int hello = br.ReadInt32();
            if (hello == IM_Hello)// If the hello is correct, continue into if
            {
                bw.Write(IM_Hello);
                bw.Flush();

                bw.Write(reg ? IM_Register : IM_Login);
                bw.Write(UserName);
                bw.Write(Password);
                bw.Flush();

                byte ans = br.ReadByte(); 
                if (ans == IM_OK)
                {
                    if (reg)
                    OnRegisterOK();  
                    OnLoginOK();
                    Receiver();
                }
                else  // Login/register failed
                {
                    IMErrorEventArgs err = new IMErrorEventArgs((IMError)ans);
                    if (reg)
                    OnRegisterFailed(err);
                    else
                        OnLoginFailed(err);
                }

            }
        }
        void CloseConn() // Close connection.
        {
            br.Close();
            bw.Close();
            ssl.Close();
            netStream.Close();
            client.Close();
            OnDisconnected();
            _conn = false;
        }

        // Start connection thread and login or register.
        void connect(string user, string password, bool register)
        {
            if (!_conn)
            {
                _conn = true;
                _user = user;
                _pass = password;
                reg = register;

                // Connect and communicate to server in another thread.
                tcpThread = new Thread(new ThreadStart(SetupConn));
                tcpThread.Start();
            }
        }

        void Receiver()  // Receive all incoming packets.
        {
            _logged = true;

            try
            {
                while (client.Connected)  // While we are connected.
                {
                    byte type = br.ReadByte();  // Get incoming packet type.

                    if (type == IM_IsAvailable)
                    {
                        string user = br.ReadString();
                        bool isAvail = br.ReadBoolean();
                        OnUserAvail(new IMAvailEventArgs(user, isAvail));
                    }
                    else if (type == IM_Received)
                    {
                        string from = br.ReadString();
                        string msg = br.ReadString();
                        OnMessageReceived(new IMReceivedEventArgs(from, msg));
                    }
                }
            }
            catch (IOException) { } // Thrown, when reading from closed connection.

            _logged = false;
        }


        public void Login(string user, string password)
        {
            connect(user, password, false);
        }
        public void Register(string user, string password)
        {
            connect(user, password, true);
        }
        public void Disconnect()
        {
            if (_conn)
                CloseConn();
        }

        TcpClient client;
        NetworkStream netStream;  // Raw-data stream of connection.
        SslStream ssl;            // Encrypts connection using SSL.
        BinaryReader br;          // Read simple data
        BinaryWriter bw;          // Write simple data

        public static bool ValidateCert(object sender, X509Certificate certificate,
              X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true; // Allow untrusted certificates.
        }

        // Packet types
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

        virtual protected void OnLoginOK()
        {
            if (LoginOK != null)
                LoginOK(this, EventArgs.Empty);
        }
        virtual protected void OnRegisterOK()
        {
            if (RegisterOK != null)
                RegisterOK(this, EventArgs.Empty);
        }
        virtual protected void OnLoginFailed(IMErrorEventArgs e)
        {
            if (LoginFailed != null)
                LoginFailed(this, e);
        }
        virtual protected void OnRegisterFailed(IMErrorEventArgs e)
        {
            if (RegisterFailed != null)
                RegisterFailed(this, e);
        }
        virtual protected void OnDisconnected()
        {
            if (Disconnected != null)
                Disconnected(this, EventArgs.Empty);
        }
        virtual protected void OnUserAvail(IMAvailEventArgs e)
        {
            if (UserAvailable != null)
                UserAvailable(this, e);
        }
        virtual protected void OnMessageReceived(IMReceivedEventArgs e)
        {
            if (MessageReceived != null)
                MessageReceived(this, e);
            
        }

        public void IsAvailable(string user)
        {
            if (_conn)
            {
                bw.Write(IM_IsAvailable);
                bw.Write(user);
                bw.Flush();
            }
        }

        public void SendMessage(string to, string msg)
        {
            if (_conn)
            {
                bw.Write(IM_Send);
                bw.Write(to);
                bw.Write(msg);
                bw.Flush();
            }
        }

    }
}
