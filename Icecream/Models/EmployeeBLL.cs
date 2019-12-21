using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Icecream.Models
{
    public class EmployeeBLL
    {
        protected string strcnn = ConfigurationManager.ConnectionStrings["Icecream"].ConnectionString;

        public DataTable GetAllEmployee()
        {
            SqlConnection cnn = new SqlConnection(strcnn);
            string Sql;
            Sql = "SELECT  [employee_id], [employee_name], role, [employee_password] FROM Employee";
            SqlDataAdapter da = new SqlDataAdapter(Sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GetEmployeeByID(int id)
        {
            SqlConnection cnn = new SqlConnection(strcnn);
            string Sql;
            Sql = "SELECT  [employee_id], [employee_name], role, [employee_password] FROM Employee WHERE [employee_id]=" + id;
            SqlDataAdapter da = new SqlDataAdapter(Sql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public List<Employee> AllEmployeeToList()
        {
            DataTable dt = GetAllEmployee();
            List<Employee> listEmp = new List<Employee>();

            foreach (DataRow item in dt.Rows)
            {
                Employee obj = new Employee();
                obj.employee_id = (int)item["employee_id"];
                obj.employee_name = item["employee_name"].ToString();
                obj.employee_password = item["employee_password"].ToString();
                obj.role = item["role"].ToString();
                listEmp.Add(obj);
            }

            return listEmp;
        }

        public int Add(Employee obj)
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
                Sql = @"INSERT INTO [Employee]([employee_name],[role],[employee_password])
                        VALUES('" + obj.employee_name.Replace("'", "''") + "','" + obj.role.Replace("'", "''") + "','" + obj.employee_password.Replace("'", "''") + "') ";
                cmd.CommandText = Sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                return -1;
            }
            return 0;
        }

        public int Update(Employee obj)
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
                Sql = @"UPDATE [Employee] SET [employee_name]='" + obj.employee_name.Replace("'", "''") + "', [role]='" + obj.role.Replace("'", "''") + "',[employee_password]='" + obj.employee_password.Replace("'", "''") + "'  WHERE [employee_id]=" + obj.employee_id;
                cmd.CommandText = Sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                return -1;
            }
            return 0;
        }

        public int Delete(Employee obj)
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
                Sql = @"Delelte FROM Employee WHERE [employee_id]=" + obj.employee_id;
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