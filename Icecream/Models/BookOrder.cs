using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Icecream.Models
{
    public class BookOrder
    {
        public int order_id { get; set; }
        public System.DateTime order_date { get; set; }
        public int cus_id { get; set; }
        public string status { get; set; }
        public Nullable<int> paymentid { get; set; }
        public Nullable<System.DateTime> complete_date { get; set; }
        public Nullable<int> emp_id { get; set; }
    }
}