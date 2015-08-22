using System;
using System.Collections.Generic;
using System.Text;
using Flexi_Client.Messages.Methods;

namespace Flexi_Client.Messages
{
    public static class MessageHandler
    {
        public static Dictionary<string, Action<string>> Messages;

        public static void RegisterMessages()
        {
            Messages = new Dictionary<string, Action<string>>();

            Messages.Add("LOGIN", LoginResponse.Execute);
            Messages.Add("CHAT", Chat.Execute);
            Messages.Add("NEWUSR", NewUser.Execute);
            Messages.Add("USRLEFT", UserLeft.Execute);
            Messages.Add("SHWALERT", ShowAlert.Execute);
        }

        public static void Parse(byte[] DataBuffer)
        {
                string Data = FormatData(Encoding.ASCII.GetString(DataBuffer));

                if (Data == string.Empty)
                    return;

                string Header = Data.Split(';')[0];
                string Body = Data.Split(';')[1];

                if (Messages.ContainsKey(Header))
                {
                    Action<string> MethodToInvoke = Messages[Header];
                    MethodToInvoke.BeginInvoke(Body, null, null);
                }
        }

        private static string FormatData(string Data)
        {
            try
            {
                int IndexOfStart = Data.IndexOf("<START>") + "<START>".Length;
                int IndexOfEnd = Data.IndexOf("<END>");

                string FormattedData = Data.Substring(IndexOfStart, IndexOfEnd - IndexOfStart);
                return FormattedData;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
