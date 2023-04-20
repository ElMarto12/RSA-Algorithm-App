using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace RSA_Algorithm_App.Utility
{
    public static class DBConnection
    {
       
        private static MySqlConnection connection;
        private static string myConnectionString;
        private static MySqlCommand command;

        public static void MakeConnection()
        {
            myConnectionString = "Data Source=localhost;" + "Initial Catalog=cypher_dbn;" + "User id=root;" + "Password=admin;";
           
            try
            {
                connection = new MySqlConnection();
                connection.ConnectionString = myConnectionString;
                connection.Open();
            }
            catch (MySqlException ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static MySqlCommand Query(string query)
        {
            try { 

               connection.Open();
               command = connection.CreateCommand();
               command.CommandType = CommandType.Text;
               command.CommandText = query;
               connection.Close();
                
            }catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }

            return command;
        }
    }
}
