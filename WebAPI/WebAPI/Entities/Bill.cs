using System;
using System.Collections.Generic;

namespace WebAPI.Entities
{
    public partial class Bill
    {
        public Bill()
        {
            BillDetails = new HashSet<BillDetail>();
        }

        public int BillId { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? CustomerId { get; set; }
        public long? Total { get; set; }
        public int BillStatus { get; set; }// =0 là bán hàng; =1 là nhập hàng

        public virtual Customer? Customer { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
