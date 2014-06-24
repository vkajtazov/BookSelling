using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSelling
{
    public class DatabaseConnectionFile
    {
        private static string connectionString = BookSelling.Properties.Settings.Default.connectionString;

        public static DataTable getDataTable(string table) {

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("Select * from "+ table, connection);
            command.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataSet ds = new DataSet();
            adapter.Fill(ds, table);
            return ds.Tables[0];
        }

        public static bool isLogin(string username, string password, int authority) {
            
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("Select * from Users where username=@username and password=@password and Type=@authority", connection);
            
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@authority", authority);

            command.CommandType = CommandType.Text;
            SqlDataReader reader;
            try
            {
                connection.Open();
                reader = command.ExecuteReader();

                if (reader.Read()) { return true; }

            }

            catch (Exception err) { return false; }
            finally
            {
                connection.Close();
            }
            return false;
        }

        public static DataTable getCategoryTable(int cat)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SELECT * from Books WHERE Genre="+cat,connection);
            command.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataSet ds = new DataSet();
            adapter.Fill(ds, "Tabela");
            return ds.Tables[0];
        }
    }
}
