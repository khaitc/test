using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Icecream.Models
{
    public class Payment
    {
        public int payment_id { get; set; }
        public string payment_status { get; set; }
        public string payment_type { get; set; }
        public string card_number { get; set; }
        public string card_name { get; set; }
        public Nullable<System.DateTime> expiry_date { get; set; }
        public string card_code { get; set; }
    }
}