using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flexi_Client.Messages;

namespace Flexi_Client
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            Connection.Connection.Connect();
            MessageHandler.RegisterMessages();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Messages.Methods.LoginResponse.NextForm = NextForm;
        }

        private void LoginBTN_Click(object sender, EventArgs e)
        {
            Connection.Connection.SendData("LOGIN;" + UsernameTXT.Text + "@" + PasswordTXT.Text);
        }

        public void NextForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(NextForm));
                    return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
