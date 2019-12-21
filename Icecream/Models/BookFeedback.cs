using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Icecream.Models
{
    public class BookFeedback
    {
        public int book_feedback_id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string content { get; set; }
        public int book_id { get; set; }

    }
}