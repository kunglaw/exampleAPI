using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data;
using MySql.Data.MySqlClient;

using exampleAPI.Config;

namespace exampleAPI.Config
{
    public class DBConnection
    {
        private DBConnection()
        {
        }

        public string Password { get; set; }
        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        private static DBConnection _instance = null;
        public static DBConnection Instance()
        {
            if (_instance == null)
                _instance = new DBConnection();
            return _instance;
        }

        public bool IsConnect()
        {
            var databaseName = Config.database;

            if (Connection == null)
            {
                if (String.IsNullOrEmpty(databaseName))
                    return false;
                string connstring = string.Format("Server=localhost; database={0}; UID={1}; password={2}", databaseName, Config.uid, Config.password);
                connection = new MySqlConnection(connstring);
                connection.Open();
            }

            return true;
        }

        public void Close()
        {
            connection.Close();
        }
    }
}



    
