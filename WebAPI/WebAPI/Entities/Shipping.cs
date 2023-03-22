using System;
using System.Collections.Generic;

namespace WebAPI.Entities
{
    public partial class Shipping
    {
        public Shipping()
        {
            Orders = new HashSet<Order>();
        }

        public int ShippingId { get; set; }
        public string? ShippingName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
