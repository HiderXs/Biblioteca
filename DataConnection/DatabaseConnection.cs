using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.DataConnection
{
    internal class DatabaseConnection
    {
        private string connectionString =
            "Server=localhost;Database=biblioteca;Uid=root;Pwd=;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
