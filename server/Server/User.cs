using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    [Serializable]
    class User
    {
        public string UserName;
        public string Password;
        [NonSerialized] public bool LoggedIn;      // Is logged in and connected?
        [NonSerialized]public Client Connection;  // Connection info

        
        public User(string user, string pass)
        {
            this.UserName = user;
            this.Password = pass;
            this.LoggedIn = false;
        }
        public User(string user, string pass, Client conn)
        {
            this.UserName = user;
            this.Password = pass;
            this.LoggedIn = true;
            this.Connection = conn;
        }
    }
}
