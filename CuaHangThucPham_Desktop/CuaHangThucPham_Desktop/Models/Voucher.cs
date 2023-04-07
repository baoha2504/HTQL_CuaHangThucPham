namespace CuaHangThucPham_Desktop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Voucher")]
    public partial class Voucher
    {
        [Key]
        [Column(Order = 0)]
        public int VoucherID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string VoucherCode { get; set; }

        public int? CustomerID { get; set; }

        public int? SalePercent { get; set; }

        public int? MaximumDis { get; set; }

        public int? MiximunVal { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Expiry { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
