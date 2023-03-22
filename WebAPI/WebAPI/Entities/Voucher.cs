using System;
using System.Collections.Generic;

namespace WebAPI.Entities
{
    public partial class Voucher
    {
        public int VoucherId { get; set; }
        public string VoucherCode { get; set; } = null!;
        public int? CustomerId { get; set; }
        public int? SalePercent { get; set; }
        public int? MaximumDis { get; set; }
        public int? MiximunVal { get; set; }
        public DateTime? Expiry { get; set; }

        public virtual Customer? Customer { get; set; }
    }
}
