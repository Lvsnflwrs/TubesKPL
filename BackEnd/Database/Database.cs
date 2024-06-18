using MySql.Data.MySqlClient;
using System;

namespace DatabaseLibrary
{
    public class Database : IDisposable
    {
        private static readonly string connectionString = "server=127.0.0.1; user=root ; database=tubes;  password=";
        private MySqlConnection connection;
        private MySqlCommand command;
        private MySqlDataReader reader;

        public void Connect()
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                command = connection.CreateCommand();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Query(string sql)
        {
            try
            {
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public MySqlDataReader View(string sql)
        {
            try
            {
                command.CommandText = sql;
                reader = command.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return reader;
        }

        public void Disconnect()
        {
            try
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Dispose()
        {
            Disconnect();
            if (command != null)
            {
                command.Dispose();
            }
            if (connection != null)
            {
                connection.Dispose();
            }
        }
    }
}
