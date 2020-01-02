using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ice_cream.Models
{

    [Table("map_rrt")]
    public class Map
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string ten_kv { get; set; }
        public string dia_chi { get; set; }
        public string vi_do { get; set; }
        public string kinh_do { get; set; }
       
    }

}
