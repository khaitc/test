using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Icecream.Models
{
    public class RecipeBLL
    {
        protected string strcnn = ConfigurationManager.ConnectionStrings["Icecream"].ConnectionString;

        public DataTable GetAllRecipe()
        {
            SqlConnection cnn = new SqlConnection(strcnn);
            string Sql;
            Sql = "SELECT recipe_id, title, description, detail, recipe_type, image, author FROM Recipe";
            SqlDataAdapter da = new SqlDataAdapter(Sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GetRecipeByID(int id)
        {
            SqlConnection cnn = new SqlConnection(strcnn);
            string Sql;
            Sql = "SELECT recipe_id, title, description, detail, recipe_type, image, author FROM Recipe WHERE [recipe_id]=" + id;
            SqlDataAdapter da = new SqlDataAdapter(Sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public List<Recipe> AllRecipeToList()
        {
            DataTable dt = GetAllRecipe();
            List<Recipe> listRecipe = new List<Recipe>();
            
            foreach (DataRow item in dt.Rows)
            {
                Recipe obj = new Recipe();
                obj.recipe_id = (int)item["recipe_id"];
                obj.title = item["title"].ToString();
                obj.description = item["description"].ToString();
                obj.detail = item["detail"].ToString();
                obj.recipe_type = item["recipe_type"].ToString();
                obj.image = item["image"].ToString();
                obj.author = item["author"].ToString();
                listRecipe.Add(obj);
            }

            return listRecipe;
        }

        public DataTable GetAllFreeOrFeeRecipe(string recipe_type)
        {
            SqlConnection cnn = new SqlConnection(strcnn);
            string Sql;
            Sql = "SELECT [recipe_id], title, description, detail, [recipe_type], image, author FROM Recipe WHERE [recipe_type]=" + recipe_type;
            SqlDataAdapter da = new SqlDataAdapter(Sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public List<Recipe> FreeOrFeeToList(string recipe_type)
        {
            DataTable dt = GetAllFreeOrFeeRecipe(recipe_type);
            List<Recipe> listRecipe = new List<Recipe>();

            foreach (DataRow item in dt.Rows)
            {
                Recipe obj = new Recipe();
                obj.recipe_id = (int)item["recipe_id"];
                obj.title = item["title"].ToString();
                obj.description = item["description"].ToString();
                obj.detail = item["detail"].ToString();
                obj.recipe_type = item["recipe_type"].ToString();
                obj.image = item["image"].ToString();
                obj.author = item["author"].ToString();
                listRecipe.Add(obj);
            }

            return listRecipe;
        }


        public int Add(Recipe obj)
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
                Sql = "INSERT INTO Recipe([title],[description],[detail],[recipe_type],[image],[author]) VALUES('" + obj.title.Replace("'", "''") + "','" + obj.description.Replace("'", "''") + "', '" + obj.description.Replace("'", "''") + "', '" + obj.recipe_type.Replace("'", "''") + "', '" + obj.image.Replace("'", "''") + "', '" + obj.author.Replace("'", "''") + "')";
                cmd.CommandText = Sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                return -1;
            }
            return 0;
        }

        public int Update(Recipe obj)
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
                Sql = @"UPDATE [Recipe] SET [title]='" + obj.title.Replace("'", "''") + "',[description]='" + obj.description.Replace("'", "''") + "', [detail]='" + obj.detail.Replace("'", "''") + "'" +
                    ",[recipe_type]='" + obj.recipe_type.Replace("'", "''") + "' , [image]='" + obj.image.Replace("'", "''") + "', [author]='" + obj.author.Replace("'", "''") + "' WHERE [recipe_id]=" + obj.recipe_id;
                cmd.CommandText = Sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                return -1;
            }
            return 0;
        }

        public int Delete(Recipe obj)
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
                Sql = "DELETE FROM Recipe WHERE [recipe_id]=" + obj.recipe_id;
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