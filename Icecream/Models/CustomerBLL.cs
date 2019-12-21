using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Icecream.Models
{
    public class CustomerBLL
    {
        protected string strcnn = ConfigurationManager.ConnectionStrings["Icecream"].ConnectionString;

        public Customer Login(string username, string password)
        {
            SqlConnection cnn = new SqlConnection(strcnn);
            string Sql;
            Sql = "SELECT * FROM Customer WHERE customername ='" + username + "' AND password=" + password;
            SqlDataAdapter da = new SqlDataAdapter(Sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Customer cus = new Customer();
            if (dt.Rows.Count > 0)
            {
                cus.customer_id = (int)dt.Rows[0]["customer_id"];
                cus.customername = username;
                cus.password = password;
                cus.customer_type = dt.Rows[0]["customer_type"].ToString();
                return cus;
            }

            return null;
        }

        public bool CheckExistUserName(string username)
        {
            SqlConnection cnn = new SqlConnection(strcnn);
            string Sql;
            Sql = "SELECT customername FROM Customer WHERE customername=" + username;
            SqlDataAdapter da = new SqlDataAdapter(Sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count>0)
            {
                return false;
            }
            return true;
        }

        public bool CheckExistEmail(string email)
        {
            SqlConnection cnn = new SqlConnection(strcnn);
            string Sql;
            Sql = "SELECT email FROM Customer WHERE email=" + email;
            SqlDataAdapter da = new SqlDataAdapter(Sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return false;
            }
            return true;
        }

        public DataTable GetAllCustomer()
        {
            SqlConnection cnn = new SqlConnection(strcnn);
            string Sql;
            Sql = "SELECT customername, password, email, phone, address, is_active, customer_id, customer_type, from_date, to_date FROM Customer";
            SqlDataAdapter da = new SqlDataAdapter(Sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GetCustomerByID(int id)
        {
            SqlConnection cnn = new SqlConnection(strcnn);
            string Sql;
            Sql = "SELECT customername, password, email, phone, address, is_active, customer_id, customer_type, from_date, to_date FROM Customer WHERE customer_id=" + id;
            SqlDataAdapter da = new SqlDataAdapter(Sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public List<Customer> AllCustomerToList()
        {
            DataTable dt = GetAllCustomer();
            List<Customer> listCustomer = new List<Customer>();

            foreach (DataRow item in dt.Rows)
            {
                Customer obj = new Customer();
                obj.customer_id = (int)item["customer_id"];
                obj.customername = item["customername"].ToString();
                obj.password = item["password"].ToString();
                obj.email = item["email"].ToString();
                obj.phone = item["phone"].ToString();
                obj.address = item["address"].ToString();
                obj.is_active = (int)item["is_active"];
                obj.customer_type = item["customer_type"].ToString();
                obj.from_date = (DateTime)item["from_date"];
                obj.to_date = (DateTime)item["to_date"];
                listCustomer.Add(obj);
            }

            return listCustomer;
        }

        public int Add(Customer obj)
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
                Sql = @"INSERT INTO Customer([customername],[password],[email],[address],[is_active],[customer_type],[from_date],[to_date])VALUES('" + obj.customername.Replace("'", "''") + "','" + obj.password.Replace("'", "''") + "', '" + obj.email.Replace("'", "''") + "'" +
                        ", '" + obj.address.Replace("'", "''") + "', '" + obj.is_active + "', '" + obj.customer_type.Replace("'", "''") + "', "+ obj.from_date +", "+ obj.to_date +")";
                cmd.CommandText = Sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                return -1;
            }
            return 0;
        }

        public int Update(Customer obj)
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
                Sql = @"UPDATE Customer SET password='" + obj.password.Replace("'", "''") + "', email='" + obj.email.Replace("'", "''") + "'," +
                    " address='" + obj.address.Replace("'", "''") + "', [is_active]='" + obj.is_active + "'," +
                    " [customer_type]='" + obj.customer_type.Replace("'", "''") + "', [from_date]=" + obj.from_date + "," +
                    " [to_date]= " + obj.to_date + " WHERE [customer_id]=" + obj.customer_id;
                cmd.CommandText = Sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                return -1;
            }
            return 0;
        }

        public int Delete(Customer obj)
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
                Sql = "DELETE FROM Customer WHERE [customer_id]=" + obj.customer_id;
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