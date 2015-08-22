using System;
using System.Collections.Generic;
using System.Text;
using Flexi.Messages.Methods;
using Flexi.Output;

namespace Flexi.Messages
{
    public static class MessageHandler
    {
        public static Dictionary<string, Action<string, object[]>> Messages;

        public static void RegisterMessages()
        {
            Messages = new Dictionary<string, Action<string, object[]>>();

            Messages.Add("LOGIN", Login.Execute);;
            Messages.Add("CHAT", Chat.Execute);
            Messages.Add("USRLISTREQ", UsersRequestList.Execute);

            Logging.Message("Successfully registered {0} messages!", Messages.Count);
        }

        public static void Parse(byte[] DataBuffer, params object[] Objects)
        {
            string Data = FormatData(Encoding.ASCII.GetString(DataBuffer));

            if (Data == string.Empty)
                return;

            string Header = Data.Split(';')[0];
            string Body = Data.Split(';')[1];

            if (Messages.ContainsKey(Header))
            {
                Action<string, object[]> MethodToInvoke = Messages[Header];
                MethodToInvoke.BeginInvoke(Body, Objects, null, null);
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
            catch(Exception Ex)
            {
                Logging.Exception(Ex, "Invalid message (Possible scripter)");
                return string.Empty;
            }
        }
    }
}
