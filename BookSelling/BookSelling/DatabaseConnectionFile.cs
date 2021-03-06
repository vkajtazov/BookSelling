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
            try
            {
                connection.Open();
                adapter.Fill(ds, table);
                return ds.Tables[0];
            }
            catch (Exception)
            {
                return null;
            }
            finally { connection.Close(); }
        }

        public static DataTable getPromotions()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("Select * from Books WHERE Promotions>0", connection);
            command.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                adapter.Fill(ds, "Tabela");
                return ds.Tables[0];
            }
            catch (Exception)
            {
                return null;
            }
            finally { connection.Close(); }
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

        public static void insertBook(string title,string author, string genre,string price,
            string promotions,string count, string url)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("INSERT INTO Books "+ 
                "(Id, Title, Author, Genre, Price, Promotions, Count, Url) "+
                "VALUES(@id, @title, @author, @genre, @price, @promo, @count, @url)",
                connection);

            SqlCommand komanda = new SqlCommand("Select max(Id) from Books",connection);
            
            
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@author", author);
            command.Parameters.AddWithValue("@genre", genre);
            command.Parameters.AddWithValue("@price", price);
            command.Parameters.AddWithValue("@promo", promotions);
            command.Parameters.AddWithValue("@count", count);
            command.Parameters.AddWithValue("@url", url);
            try
            {
                connection.Open();
                int broj = Convert.ToInt32(komanda.ExecuteScalar());
                command.Parameters.AddWithValue("@id", broj+1);
                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
