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
    }
}
