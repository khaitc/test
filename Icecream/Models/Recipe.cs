using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Icecream.Models
{
    public class Recipe
    {
        public int recipe_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string detail { get; set; }
        public string recipe_type { get; set; }
        public string image { get; set; }
        public string author { get; set; }
    }
}