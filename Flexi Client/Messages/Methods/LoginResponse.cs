using System;
using System.Windows.Forms;

namespace Flexi_Client.Messages.Methods
{
    public static class LoginResponse
    {
        public static Action NextForm;

        public static void Execute(string MessageBody)
        {
            switch (MessageBody)
            {
                case "INVALID":
                    {
                        MessageBox.Show("Incorrect login details!");
                        break;
                    }

                case "BANNED":
                    {
                        MessageBox.Show("Sorry, you cannot login as you're banned!");
                        break;
                    }

                case "ALREADY":
                    {
                        MessageBox.Show("You are already logged in!");
                        break;
                    }

                case "SUCCESS":
                    {
                        NextForm.BeginInvoke(null, null);
                        break;
                    }
            }
        }
    }
}
