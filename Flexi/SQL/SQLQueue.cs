using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Flexi.Output;

namespace Flexi.SQL
{
    public static class SQLQueue
    {
        public static ConcurrentDictionary<Dictionary<string, string>, string> QueryStack = 
            new ConcurrentDictionary<Dictionary<string, string>, string>();

        public static void ExecutePendingQueries()
        {
            int TotalQueries = QueryStack.Count;

            if (TotalQueries > 1500000)
                Logging.Message("Executing {0} queries, this may take a while...", TotalQueries);
            else
                Logging.Message("Executing {0} queries..", TotalQueries);

            using (DatabaseConnection DB = new DatabaseConnection())
            {
                foreach (KeyValuePair<Dictionary<string, string>, string> KvP in QueryStack)
	            {
                    DB.SetQuery(KvP.Value);

                    foreach (KeyValuePair<string, string> KvPParams in KvP.Key)
                    {
                        DB.AddParam(KvPParams.Key, KvPParams.Value);
                    }

                    DB.ExecuteQuery();
                }
	        }

            QueryStack.Clear();
            Logging.Message("Successfully executed {0} queries from the stack! Stack cleared!", TotalQueries);
        }

        private static void InsertParams(string[] Params)
        {
        }
    }
}
