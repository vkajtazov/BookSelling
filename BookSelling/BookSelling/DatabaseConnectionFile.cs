﻿using System;
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

        public static DataTable getCategoryTable(int cat)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SELECT * from Books WHERE Genre="+cat,
                connection);
            command.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Tabela");
            return ds.Tables[0];
        }

        public static void insertBook(string title,string author, string genre,string price,
            string promotions,string count, string url)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("INSERT INTO Books from Books "+ 
                "(Id, Title, Author, Genre, Price, Promotions, Count, Url) "+
                "VALUES(@id, @author, @genre, @price, @promo, @count, @url)",
                connection);
            int id=Properties.Settings.Default.ID;
            Properties.Settings.Default.ID = id + 1;
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@author", author);
            command.Parameters.AddWithValue("@genre", genre);
            command.Parameters.AddWithValue("@price", price);
            command.Parameters.AddWithValue("@promo", promotions);
            command.Parameters.AddWithValue("@count", count);
            command.Parameters.AddWithValue("@url", url);
        }
    }
}
