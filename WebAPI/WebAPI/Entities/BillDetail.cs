using System;
using System.Collections.Generic;

namespace WebAPI.Entities
{
    public partial class BillDetail
    {
        public int BillDetail1 { get; set; }
        public int? Quantity { get; set; }
        public long? Price { get; set; }
        public int? BillId { get; set; }
        public int? ProductId { get; set; }

        public virtual Bill? Bill { get; set; }
        public virtual Product? Product { get; set; }
    }
}
