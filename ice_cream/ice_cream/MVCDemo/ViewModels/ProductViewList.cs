using ice_cream.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ice_cream.ViewModels
{
    public class ProductViewList
    {
        public ProductViewList()
        {
            this.Products = new List<Product>();
            this.Categories = new List<Category>();
        }

        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
    }
}