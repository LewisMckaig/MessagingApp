using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMApp
{
    public partial class Form1 : Form
    {
        public Form1(Client client, string user)
        {
            
            InitializeComponent();
            this.client= client;
            this.sendTo = user;
            
        }

        public Client client;
        public string sendTo;

        IMAvailEventHandler availHandler;
        IMReceivedEventHandler receivedHandler;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = sendTo;
            availHandler = new IMAvailEventHandler(client_UserAvailable);
            receivedHandler = new IMReceivedEventHandler(client_MessageReceived);
            client.UserAvailable += availHandler;
            client.MessageReceived += receivedHandler;
            client.IsAvailable(sendTo);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.UserAvailable -= availHandler;
            client.MessageReceived -= receivedHandler;
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            String message;
            bool imp = important.Checked;
            if (imp == true)
            {
                message = txtEntry.Text + " <I>"; //marks the message as important
            }
            else
            {
                message = txtEntry.Text;
            }
            
            client.SendMessage(sendTo, message);

            messageList.Text += String.Format("[{0}] {1} \r\n", client.UserName, txtEntry.Text);
            
            txtEntry.Text = "";
        }

        bool lastAvail = false;

        void client_UserAvailable(object sender, IMAvailEventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {
                if (e.UserName == sendTo)
                {
                    if (lastAvail != e.IsAvailable)
                    {
                        lastAvail = e.IsAvailable;
                        string avail = (e.IsAvailable ? "available" : "unavailable");
                        this.Text = String.Format("{0} - {1}", sendTo, avail);
                        messageList.Text += String.Format("[{0} is {1}]\r\n", sendTo, avail);
                    }
                }
            }));
        }

        void client_MessageReceived(object sender, IMReceivedEventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {
                if (e.From == sendTo)
                {
                    if (e.Message.Contains("<I>"))
                    {
                        SystemSounds.Exclamation.Play();
                        String message = e.Message.Substring(0, e.Message.Length - 3);
                        messageList.Text += String.Format("[{0}] {1}\r\n", e.From, message);
                    }
                    else
                    {
                        messageList.Text += String.Format("[{0}] {1}\r\n", e.From, e.Message);
                    }
                }
            }));
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            client.IsAvailable(sendTo);
        }
    }
}
