using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMApp
{
    public partial class Login : Form
    {
        Client client = new Client();
        public Login()
        {
            InitializeComponent();
            client.LoginOK += new EventHandler(im_LoginOK);
            client.RegisterOK += new EventHandler(im_RegisterOK);
            client.LoginFailed += new IMErrorEventHandler(im_LoginFailed);
            client.RegisterFailed += new IMErrorEventHandler(im_RegisterFailed);
            client.Disconnected += new EventHandler(im_Disconnected);
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            String uname, pword;
            uname = uTxtBox.Text;
            pword = pTxtBox.Text;

            client.Login(uname, pword);
            status.Text = "Login...";
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            String uname, pword;
            uname = uTxtBox.Text;
            pword = pTxtBox.Text;

            client.Register(uname, pword);
            status.Text = "Registering...";
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            client.Disconnect();
        }

        private void talkBtn_Click(object sender, EventArgs e)
        {
            Form1 chatWin = new Form1(client, toTxtBox.Text);
            toTxtBox.Text = "";
            users.Add(chatWin);
            chatWin.Show();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.Disconnect();
        }

        void im_LoginOK(object sender, EventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {
                status.Text = "Logged in!";
                createBtn.Enabled = false;
                loginBtn.Enabled = false;
                logoutBtn.Enabled = true;
                talkBtn.Enabled = true;
            }));
        }
        void im_RegisterOK(object sender, EventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {
                status.Text = "Registered!";
                createBtn.Enabled = false;
                loginBtn.Enabled = false;
                logoutBtn.Enabled = true;
                talkBtn.Enabled = true;
            }));
        }
        void im_LoginFailed(object sender, IMErrorEventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {
                status.Text = "Login failed!";
            }));
        }
        void im_RegisterFailed(object sender, IMErrorEventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {
                status.Text = "Register failed!";
            }));
        }
        void im_Disconnected(object sender, EventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {
                status.Text = "Disconnected!";
                createBtn.Enabled = true;
                loginBtn.Enabled = true;
                logoutBtn.Enabled = false;
                talkBtn.Enabled = false;

                foreach (Form1 u in users)
                    u.Close();
            }));
        }

        List<Form1> users = new List<Form1>();
    }
}
