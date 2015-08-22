using System;
using System.Data;
using MySql.Data.MySqlClient;
using Flexi.Output;

namespace Flexi.SQL
{
    public class DatabaseConnection : IDisposable
    {
        MySqlConnection SQLConnection;
        string Query = string.Empty;
        MySqlCommand SQLCommand;

        public DatabaseConnection()
        {
            try
            {
                string Host = Global.Data["MySQL.Host"];
                string Username = Global.Data["MySQL.Username"];
                string Password = Global.Data["MySQL.Password"];
                string Database = Global.Data["MySQL.Database"];

                string MinPoolSize = Global.Data["MySQL.Pool.Min"];
                string MaxPoolSize = Global.Data["MySQL.Pool.Max"];

                SQLConnection = new MySqlConnection("Server="+ Host +";Database="+ Database +
                                        ";Uid="+ Username +";Pwd="+ Password +
                                        ";max pool size="+ MaxPoolSize +";min pool size="+ MinPoolSize +";");
                SQLConnection.Open();
            }
            catch(Exception Ex) 
            {
                Logging.MySQL(Ex, "Could not open a connection with MySQL");
            }

        }

        public void SetQuery(string Query)
        {
            this.Query = Query;

            if (SQLCommand != null)
            {
                SQLCommand.Dispose();
                SQLCommand = null;
            }

            SQLCommand = new MySqlCommand(Query, SQLConnection);
        }

        public void AddParam(string Key, object Value)
        {
            try
            {
                SQLCommand.Parameters.AddWithValue("@" + Key, Value.ToString());
            }
            catch (Exception Ex)
            {
                Logging.MySQL(Ex, "Failed to add parameter");
            }
        }

        public DataRow GetRow()
        {
            try
            {
                Query = Query + " LIMIT 1";
                using (SQLCommand)
                {
                    using (MySqlDataReader DataReader = SQLCommand.ExecuteReader())
                    {
                        DataTable Table = new DataTable();
                        Table.Load(DataReader);

                        if (Table.Rows.Count > 0)
                            return Table.Rows[0];

                        return null;
                    }
                }
            }
            catch (Exception Ex)
            {
                Logging.MySQL(Ex, "Error in query");
                return null;
            }
        }

        public DataTable GetTable()
        {
            try
            {
                using (SQLCommand)
                {
                    using (MySqlDataReader DataReader = SQLCommand.ExecuteReader())
                    {
                        DataTable TableToReturn = new DataTable();
                        TableToReturn.Load(DataReader);

                        return TableToReturn;
                    }
                }
            }
            catch (Exception Ex)
            {
                Logging.MySQL(Ex, "Error in query");
                return null;
            }
        }

        public void ExecuteQuery()
        {
            try
            {
                using (SQLCommand)
                {
                    SQLCommand.ExecuteNonQuery();
                }
            }
            catch(Exception Ex) 
            {
                Logging.MySQL(Ex, "Error in query");
            }
        }

        public virtual void Dispose()
        {
            if (SQLConnection == null)
                return;
            SQLConnection.Close();
            SQLConnection.Dispose();
            SQLConnection = null;

            if (SQLCommand == null)
                return;
            SQLCommand.Dispose();
            SQLCommand = null;
        }
    }
}
