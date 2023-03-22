using System;
using System.Collections.Generic;

namespace WebAPI.Entities
{
    public partial class OrderStatusHistory
    {
        public int OrderStatusId { get; set; }
        public string? OrderStatusName { get; set; }
        public DateTime? DateAdd { get; set; }
        public int? OrderId { get; set; }
        public string? CanceledBy { get; set; }

        public virtual Order? Order { get; set; }
    }
}
