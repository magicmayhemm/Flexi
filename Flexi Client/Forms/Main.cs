using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flexi_Client.Messages.Methods;

namespace Flexi_Client
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            Chat.AddMessage = AddMessage;
            NewUser.AddUser = AddUser;
            UserLeft.RemoveUser = RemoveUser;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Global.LoggedIn = true;
            Connection.Connection.SendData("USRLISTREQ;hello");
        }

        public void AddMessage(string Message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(AddMessage), Message);
                return;
            }
            ChatAreaRTB.Text = ChatAreaRTB.Text + "\n" + Message;

            ChatAreaRTB.SelectionStart = ChatAreaRTB.TextLength;
            ChatAreaRTB.ScrollToCaret();

            ChatAreaRTB.Focus();

            MessageTXT.SelectionStart = MessageTXT.TextLength;
            MessageTXT.Focus();
        }

        public void AddUser(string Username)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(AddUser), Username);
                return;
            }

            UsersConnected.Items.Add(Username);
        }

        public void RemoveUser(string Username)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(RemoveUser), Username);
                return;
            }

            UsersConnected.Items.Remove(Username);
        }

        private void SendMessageBTN_Click(object sender, EventArgs e)
        {
            SendMSG();
        }

        private void SendMSG()
        {
            Connection.Connection.SendData("CHAT;" + MessageTXT.Text);
            MessageTXT.Clear();

            MessageTXT.SelectionStart = MessageTXT.TextLength;
            MessageTXT.Focus();
        }

        private void MessageTXT_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendMSG();
            }
        }
    }
}
