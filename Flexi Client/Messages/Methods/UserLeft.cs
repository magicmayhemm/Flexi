using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexi_Client.Messages.Methods
{
    public static class UserLeft
    {
        public static Action<string> RemoveUser;

        public static void Execute(string MessageBody)
        {
            RemoveUser.BeginInvoke(MessageBody, null, null);
        }
    }
}