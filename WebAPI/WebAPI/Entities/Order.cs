using System;
using System.Collections.Generic;

namespace WebAPI.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
            OrderStatusHistories = new HashSet<OrderStatusHistory>();
        }

        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? DateAdd { get; set; }
        public int? PaymentId { get; set; }
        public int? ShippingId { get; set; }
        public string? ShippingAddress { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Note { get; set; }
        public int? ShippingFee { get; set; }
        public int? Discount { get; set; }
        public int? Total { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Payment? Payment { get; set; }
        public virtual Shipping? Shipping { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<OrderStatusHistory> OrderStatusHistories { get; set; }
    }
}
