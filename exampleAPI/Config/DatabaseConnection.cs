using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using exampleAPI.Config;
using MySql.Data.MySqlClient;

namespace exampleAPI.Config
{
    public class DatabaseConnection
    {
        private MySqlConnection connection;

        //Constructor
        public DatabaseConnection()
        {
            Initialize();
        }

        public void Initialize()
        {  

            string connectionString;
            connectionString = "SERVER=" + Config.host + ";" + "DATABASE=" +
            Config.database + ";" + "UID=" + Config.uid + ";" + "PASSWORD=" + Config.password + ";";

            connection = new MySqlConnection(connectionString);
        }

        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        public MySqlCommand command(string strCommand)
        {
            
            MySqlCommand cmd = new MySqlCommand(strCommand, connection);
            return cmd;
             
        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}