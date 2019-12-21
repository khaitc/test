using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Icecream.Models
{
    public class Book
    {
        public int book_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public decimal price { get; set; }
    }
}