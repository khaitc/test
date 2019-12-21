using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Icecream.Models
{
    public class RecipeFeedback
    {
        public int recipe_feedback_id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string content { get; set; }
        public Nullable<int> recipe_id { get; set; }
    }
}