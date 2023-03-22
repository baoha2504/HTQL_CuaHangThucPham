namespace CuaHangThucPham.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Inventory")]
    public partial class Inventory
    {
        public int InventoryID { get; set; }

        public int? Quantity { get; set; }

        public int? InventoryNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateAdded { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpirationDate { get; set; }

        public int? CustomerID { get; set; }

        public int? ProductID { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Product Product { get; set; }
    }
}
