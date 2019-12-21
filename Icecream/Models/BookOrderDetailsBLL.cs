using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Icecream.Models
{
    public class BookOrderDetailsBLL
    {
        protected string strcnn = ConfigurationManager.ConnectionStrings["Icecream"].ConnectionString;

        public DataTable GetAllOrderDetail()
        {
            SqlConnection cnn = new SqlConnection(strcnn);
            string Sql;
            Sql = "SELECT  [order_id], [book_id], price, quantity FROM BookOrderDetails";
            SqlDataAdapter da = new SqlDataAdapter(Sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public List<BookOrderDetails> AllOrderDetailToList()
        {
            DataTable dt = GetAllOrderDetail();
            List<BookOrderDetails> listOrderDetail = new List<BookOrderDetails>();

            foreach (DataRow item in dt.Rows)
            {
                BookOrderDetails obj = new BookOrderDetails();
                obj.order_id = (int)item["order_id"];
                obj.book_id = (int)item["book_id"];
                obj.quantity = (int)item["quantity"];
                obj.price = (decimal)item["price"];
                listOrderDetail.Add(obj);
            }

            return listOrderDetail;
        }

        public int Add(BookOrderDetails obj)
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
                Sql = @"INSERT INTO [BookOrderDetails]([book_id],[price],[quantity])
                        VALUES(" + obj.book_id +", "+ obj.price +"," + obj.quantity + ") ";
                cmd.CommandText = Sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                return -1;
            }
            return 0;
        }

        public int Update(BookOrderDetails obj)
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
                Sql = @"UPDATE FROM BookOrderDetails SET [book_id]= " + obj.book_id + ", [price]= " + obj.price + ", [quantity]=" + obj.quantity + " WHERE order_id=" + obj.order_id;
                cmd.CommandText = Sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                return -1;
            }
            return 0;
        }

        public int Delete(BookOrderDetails obj)
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
                Sql = @"DELETE FROM BookOrderDetails WHERE order_id=" + obj.order_id;
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