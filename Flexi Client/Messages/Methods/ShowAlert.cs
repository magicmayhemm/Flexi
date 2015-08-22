using System;
using System.Windows.Forms;

namespace Flexi_Client.Messages.Methods
{
    public static class ShowAlert
    {
        public static void Execute(string MessageBody)
        {
            MessageBox.Show(MessageBody);
        }
    }
}
