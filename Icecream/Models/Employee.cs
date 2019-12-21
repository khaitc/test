using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Icecream.Models
{
    public class Employee
    {
        public int employee_id { get; set; }
        public string employee_name { get; set; }
        public string role { get; set; }
        public string employee_password { get; set; }
    }
}