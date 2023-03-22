namespace CuaHangThucPham.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Blog")]
    public partial class Blog
    {
        public int BlogID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateAdded { get; set; }

        [StringLength(200)]
        public string Image { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(4000)]
        public string Content { get; set; }

        public int? CustomerID { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
