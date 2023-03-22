﻿using System;
using System.Collections.Generic;

namespace WebAPI.Entities
{
    public partial class Payment
    {
        public Payment()
        {
            Orders = new HashSet<Order>();
        }

        public int PaymentId { get; set; }
        public string? PaymentName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
