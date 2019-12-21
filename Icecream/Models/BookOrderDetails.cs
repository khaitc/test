using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Icecream.Models
{
    public class BookOrderDetails
    {
        public int order_id { get; set; }
        public int book_id { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
    }
}