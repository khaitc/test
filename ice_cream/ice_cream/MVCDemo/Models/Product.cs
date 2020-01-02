using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ice_cream.Models
{

    [Table("Products")]
    public class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [ForeignKey("Suppliers")]
        public int SupplierID { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm!")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Mục này không được để trống !")]
        public string QuantityPerUnit { get; set; }
        [Required(ErrorMessage = "Mục này không được để trống !")]
        public float UnitPrice { get; set; }
        [Required(ErrorMessage = "Mục này không được để trống !")]
        public int UnitsInStock { get; set; }
        public bool Discontinued { get; set; }


        [NotMapped]
        public virtual Category Category { get; set; }
        [NotMapped]
        public virtual Suppliers Suppliers { get; set; }
    }

}