using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ice_cream.Models
{

    [Table("Book")]
    public class Book
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int book_id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên danh mục")]
        public string title { get; set; }

        public string description { get; set; }
        public string image { get; set; }
        public float price { get; set; }
    }

}