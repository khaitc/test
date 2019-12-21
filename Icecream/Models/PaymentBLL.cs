using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Icecream.Models
{
    public class PaymentBLL
    {
        protected string strcnn = ConfigurationManager.ConnectionStrings["Icecream"].ConnectionString;

        public DataTable GetAllPayment()
        {
            SqlConnection cnn = new SqlConnection(strcnn);
            string Sql;
            Sql = "SELECT [payment_id], [payment_status], [payment_type], [card_number], [card_name], [expiry_date], [card_code] FROM Payment";
            SqlDataAdapter da = new SqlDataAdapter(Sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GetPaymentByID(int id)
        {
            SqlConnection cnn = new SqlConnection(strcnn);
            string Sql;
            Sql = "SELECT [payment_id], [payment_status], [payment_type], [card_number], [card_name], [expiry_date], [card_code] FROM Payment WHERE payment_id=" + id;
            SqlDataAdapter da = new SqlDataAdapter(Sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public List<Payment> AllPaymentToList()
        {
            DataTable dt = GetAllPayment();
            List<Payment> listPay = new List<Payment>();

            foreach (DataRow item in dt.Rows)
            {
                Payment obj = new Payment();
                obj.payment_id = (int)item["payment_id"];
                obj.payment_status = item["payment_status"].ToString();
                obj.payment_type = item["payment_type"].ToString();
                obj.card_number = item["card_number"].ToString();
                obj.card_name = item["card_name"].ToString();
                obj.expiry_date = (DateTime)item["expiry_date"];
                obj.card_code = item["card_code"].ToString();
                listPay.Add(obj);
            }

            return listPay;
        }

        public int Add(Payment obj)
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
                Sql = @"INSERT INTO [Payment]([payment_status],[payment_type],[card_number],[card_name],[expiry_date],[card_code])
                        VALUES('" + obj.payment_status.Replace("'", "''") + "','" + obj.payment_type.Replace("'", "''") + "','" + obj.card_number.Replace("'", "''") + "'," +
                        " '"+ obj.card_name.Replace("'", "''") + "', "+ obj.expiry_date +", '"+ obj.card_code.Replace("'", "''") + "') ";
                cmd.CommandText = Sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                return -1;
            }
            return 0;
        }

        public int Update(Payment obj)
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
                Sql = @"UPDATE [Payment] SET [payment_status]= '" + obj.payment_status.Replace("'", "''") + "', [payment_type]='" + obj.payment_type.Replace("'", "''") + "' " +
                    ", [card_number]='" + obj.card_number.Replace("'", "''") + "', [card_name]='" + obj.card_name.Replace("'", "''") + "'" +
                    ", [expiry_date]=" + obj.expiry_date + ", [card_code]= '" + obj.card_code.Replace("'", "''") + "' " +
                    "WHERE payment_id=" + obj.payment_id;
                cmd.CommandText = Sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                return -1;
            }
            return 0;
        }

        public int Delete(Payment obj)
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
                Sql = @"Delelte FROM Payment WHERE [payment_id]=" + obj.payment_id;
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