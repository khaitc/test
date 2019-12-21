using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Icecream.Models
{
    public class BookOrderBLL
    {
        protected string strcnn = ConfigurationManager.ConnectionStrings["Icecream"].ConnectionString;

        public DataTable GetAllBookOrder()
        {
            SqlConnection cnn = new SqlConnection(strcnn);
            string Sql;
            Sql = "SELECT  [order_id], [order_date], [cus_id], status, paymentid, [complete_date], [emp_id] FROM BookOrder";
            SqlDataAdapter da = new SqlDataAdapter(Sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GetBookOrderByID(int id)
        {
            SqlConnection cnn = new SqlConnection(strcnn);
            string Sql;
            Sql = "SELECT  [order_id], [order_date], [cus_id], status, paymentid, [complete_date], [emp_id] FROM BookOrder WHERE [order_id]=" + id;
            SqlDataAdapter da = new SqlDataAdapter(Sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public List<BookOrder> AllBookOrderToList()
        {
            DataTable dt = GetAllBookOrder();
            List<BookOrder> listBookOrder = new List<BookOrder>();

            foreach (DataRow item in dt.Rows)
            {
                BookOrder obj = new BookOrder();
                obj.order_id = (int)item["order_id"];
                obj.order_date = (DateTime)item["order_date"];
                obj.cus_id = (int)item["cus_id"];
                obj.status = item["status"].ToString();
                obj.paymentid = (int)item["paymentid"];
                obj.complete_date = (DateTime)item["complete_date"];
                obj.emp_id = (int)item["emp_id"];
                listBookOrder.Add(obj);
            }

            return listBookOrder;
        }

        public int Add(BookOrder obj)
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
                Sql = @"INSERT INTO [BookOrder]([order_date],[cus_id],[status],[paymentid],[complete_date],[emp_id])
                        VALUES("+ obj.order_date +", "+ obj.cus_id +", '" + obj.status.Replace("'", "''") + "'," + obj.paymentid + ", "+ obj.complete_date +", "+ obj.emp_id +") ";
                cmd.CommandText = Sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                return -1;
            }
            return 0;
        }

        public int Update(BookOrder obj)
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
                Sql = @"UPDATE [BookOrder] SET [order_date]=" + obj.order_date + ",  [cus_id]=" + obj.cus_id + ", [status]='" + obj.status + "', [paymentid]=" + obj.paymentid + ", [complete_date]=" + obj.complete_date + ", [emp_id]=" + obj.emp_id + " WHERE order_id=" + obj.order_id;
                cmd.CommandText = Sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                return -1;
            }
            return 0;
        }

        public int Delete(BookOrder obj)
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
                Sql = @"DELETE FROM [BookOrder] WHERE [order_id]=" + obj.order_id;
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