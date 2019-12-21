using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Icecream.Models
{
    public class BookFeedbackBLL
    {
        protected string strcnn = ConfigurationManager.ConnectionStrings["Icecream"].ConnectionString;

        public DataTable GetAllBookFeedback()
        {
            SqlConnection cnn = new SqlConnection(strcnn);
            string Sql;
            Sql = "SELECT  email, name, [content], [book_feedback_id], [book_id] FROM BookFeedback";
            SqlDataAdapter da = new SqlDataAdapter(Sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GetBookFeedbackByID(int id)
        {
            SqlConnection cnn = new SqlConnection(strcnn);
            string Sql;
            Sql = "SELECT  email, name, [content], book_feedback_id, book_id FROM BookFeedback WHERE book_feedback_id=" + id;
            SqlDataAdapter da = new SqlDataAdapter(Sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public List<BookFeedback> AllBookFeedbackToList()
        {
            DataTable dt = GetAllBookFeedback();
            List<BookFeedback> listfeedback = new List<BookFeedback>();

            foreach (DataRow item in dt.Rows)
            {
                BookFeedback obj = new BookFeedback();
                obj.book_feedback_id = (int)item["book_feedback_id"];
                obj.email = item["email"].ToString();
                obj.name = item["name"].ToString();
                obj.content = item["content"].ToString();
                obj.book_id = (int)item["book_id"];
                listfeedback.Add(obj);
            }

            return listfeedback;
        }

        public int Add(BookFeedback obj)
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
                Sql = @"INSERT INTO [BookFeedback]([email],[name],[content],[book_id])
                        VALUES('"+ obj.email.Replace("'", "''") + "','"+ obj.name.Replace("'", "''") + "','"+ obj.content.Replace("'", "''") + "',"+ obj.book_id +") ";
                cmd.CommandText = Sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                return -1;
            }
            return 0;
        }

        public int Update(BookFeedback obj)
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
                Sql = @"UPDATE [BookFeedback] SET [email]='" + obj.email + "', [name]='" + obj.name + "', [content]='" + obj.content + "' WHERE [book_feedback_id]=" + obj.book_feedback_id;
                cmd.CommandText = Sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                return -1;
            }
            return 0;
        }

        public int Delete(BookFeedback obj)
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
                Sql = "DELETE FROM BookFeedback WHERE [book_feedback_id]=" + obj.book_feedback_id;
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