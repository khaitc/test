using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Icecream.Models
{
    public class RecipeFeedbackBLL
    {
        protected string strcnn = ConfigurationManager.ConnectionStrings["Icecream"].ConnectionString;

        public DataTable GetAllRecipeFeedback()
        {
            SqlConnection cnn = new SqlConnection(strcnn);
            string Sql;
            Sql = "SELECT  email, name, [content], [recipe_feedback_id], [recipe_id] FROM RecipeFeedback";
            SqlDataAdapter da = new SqlDataAdapter(Sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GetRecipeFeedbackByID(int id)
        {
            SqlConnection cnn = new SqlConnection(strcnn);
            string Sql;
            Sql = "SELECT  email, name, [content], [recipe_feedback_id], [recipe_id] FROM RecipeFeedback WHERE recipe_feedback_id=" + id;
            SqlDataAdapter da = new SqlDataAdapter(Sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public List<RecipeFeedback> AllRecipeFeedbackToList()
        {
            DataTable dt = GetAllRecipeFeedback();
            List<RecipeFeedback> listfeedback = new List<RecipeFeedback>();

            foreach (DataRow item in dt.Rows)
            {
                RecipeFeedback obj = new RecipeFeedback();
                obj.recipe_feedback_id = (int)item["recipe_feedback_id"];
                obj.email = item["email"].ToString();
                obj.name = item["name"].ToString();
                obj.content = item["content"].ToString();
                obj.recipe_id = (int)item["recipe_id"];
                listfeedback.Add(obj);
            }

            return listfeedback;
        }

        public int Add(RecipeFeedback obj)
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
                Sql = @"INSERT INTO [RecipeFeedback]([email],[name],[content],[recipe_id])
                        VALUES('" + obj.email.Replace("'", "''") + "','" + obj.name.Replace("'", "''") + "','" + obj.content.Replace("'", "''") + "'," + obj.recipe_id + ") ";
                cmd.CommandText = Sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                return -1;
            }
            return 0;
        }

        public int Update(RecipeFeedback obj)
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
                Sql = @"UPDATE [RecipeFeedback] SET [email]='" + obj.email + "', [name]='" + obj.name + "', [content]='" + obj.content + "' WHERE [recipe_feedback_id]=" + obj.recipe_feedback_id;
                cmd.CommandText = Sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                return -1;
            }
            return 0;
        }

        public int Delete(RecipeFeedback obj)
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
                Sql = "DELETE FROM RecipeFeedback WHERE [recipe_feedback_id]=" + obj.recipe_feedback_id;
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