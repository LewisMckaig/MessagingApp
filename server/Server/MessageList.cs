using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Server
{
    class MessageList
    {
        private String path;
        public MessageList()
        {
            path = @"Assembly.GetExecutingAssembly().Location";

        }

        public void addMessage(String sender, String message, String recipient, DateTime date)
        {
            bool imp = false;
            if (message.Contains("<I>"))
            {
                message = message.Substring(0, message.Length - 3);
                imp = true;
            }
            if (!File.Exists(path + @"\msgs.txt"))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path + @"\msgs.txt"))
                {
                    sw.WriteLine("Sender:   Message:    Recipient:  Date:   Important:");
                }
            }
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(sender +"  "+ message + "  " +recipient + "  " +date+ "  " + imp);
            }
        }

        public void displayMessages()
        {
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
                Console.WriteLine(line);
        }
    }
}
