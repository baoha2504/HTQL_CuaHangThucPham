using System;
using System.Collections.Generic;

namespace WebAPI.Entities
{
    public partial class Inventory
    {
        public int InventoryID { get; set; }
        public int? Quantity { get; set; }
        public int? InventoryNumber { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int? CustomerId { get; set; }
        public int? ProductId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Product? Product { get; set; }
    }
}
