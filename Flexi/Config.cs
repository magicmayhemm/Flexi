using System;
using System.IO;
using System.Collections.Generic;
using Flexi.Output;

namespace Flexi
{
    public class Config
    {
        public Config()
        {
            Global.Data = new Dictionary<string, string>();
        }

        public void GetAllData(string Path)
        {
            if (!File.Exists(Path))
                Logging.Exception(new FileNotFoundException(), "Failed to load config file");

            try
            {
                using (StreamReader FileReader = new StreamReader(Path))
                {
                    string TextOfLine;
                    while ((TextOfLine = FileReader.ReadLine()) != null)
                    {
                        if (TextOfLine.Length < 1 || TextOfLine.StartsWith("#"))
                            continue;

                        int KeyEnd = TextOfLine.IndexOf('=');

                        if (KeyEnd == -1)
                            continue;

                        string Key = TextOfLine.Substring(0, KeyEnd);
                        string Value = TextOfLine.Substring(KeyEnd + 1);
                        
                        Global.Data.Add(Key, Value);
                    }
                }
            }
            catch (Exception Ex)
            {
                Logging.Exception(Ex, "Error whilst loading config files");
            }
        }
    }
}
