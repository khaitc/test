using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Icecream.Models
{
    public class BookBLL
    {
        protected string strcnn = ConfigurationManager.ConnectionStrings["Icecream"].ConnectionString;

        public DataTable GetAllBook()
        {
            SqlConnection cnn = new SqlConnection(strcnn);
            string Sql;
            Sql = "SELECT  [book_id], title, description, image, price FROM Book";
            SqlDataAdapter da = new SqlDataAdapter(Sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GetBookByID(int id)
        {
            SqlConnection cnn = new SqlConnection(strcnn);
            string Sql;
            Sql = "SELECT  [book_id], title, description, image, price FROM Book WHERE [book_id]=" + id;
            SqlDataAdapter da = new SqlDataAdapter(Sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public List<Book> AllBookToList()
        {
            DataTable dt = GetAllBook();
            List<Book> listbook = new List<Book>();

            foreach (DataRow item in dt.Rows)
            {
                Book obj = new Book();
                obj.book_id = (int)item["book_id"];
                obj.title = item["title"].ToString();
                obj.description = item["description"].ToString();
                obj.image = item["image"].ToString();
                obj.price = (decimal)item["price"];
                listbook.Add(obj);
            }

            return listbook;
        }

        public int Add(Book obj)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(strcnn);
                SqlCommand cmd = new SqlCommand();
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                string Sql;
                Sql = @"INSERT INTO [Book]([title],[description],[image],[price])
                        VALUES('" + obj.title.Replace("'", "''") + "','" + obj.description.Replace("'", "''") + "','" + obj.image.Replace("'", "''") + "'," + obj.price + ") ";
                cmd.CommandText = Sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                return -1;
            }
            return 0;
        }

        public int Update(Book obj)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(strcnn);
                SqlCommand cmd = new SqlCommand();
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                string Sql;
                Sql = @"UPDATE [Book] SET [title]='" + obj.title.Replace("'", "''") + "', [description]='" + obj.description.Replace("'", "''") + "',[image]='" + obj.image.Replace("'", "''") + "' ,[price]=" + obj.price + " WHERE [book_id]=" + obj.book_id;
                cmd.CommandText = Sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                return -1;
            }
            return 0;
        }

        public int Delete(Book obj)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(strcnn);
                SqlCommand cmd = new SqlCommand();
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                string Sql;
                Sql = @"Delelte FROM Book WHERE [book_id]=" + obj.book_id;
                cmd.CommandText = Sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                return -1;
            }
            return 0;
        }
    }
}