using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace BooksManager.Models
{
    public class MySQLconn
    {
        public static void ConnectMySQL()
        {
            string connStr = "server=localhost;user=root;database=Books;port=3306;password=12345678";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                // Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                // Perform database operations
            }
            catch (Exception ex)
            {

                // Console.WriteLine(ex.ToString());
            }
            conn.Close();
            // Console.WriteLine("Done.");
        }
    }
}
