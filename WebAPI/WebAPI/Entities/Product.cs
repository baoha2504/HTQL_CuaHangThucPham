using System;
using System.Collections.Generic;

namespace WebAPI.Entities
{
    public partial class Product
    {
        public Product()
        {
            BillDetails = new HashSet<BillDetail>();
            Carts = new HashSet<Cart>();
            Inventories = new HashSet<Inventory>();
            OrderDetails = new HashSet<OrderDetail>();
            Reviews = new HashSet<Review>();
        }

        public int ProductId { get; set; }
        public int? SubCategoriesId { get; set; }
        public string? ProductName { get; set; }
        public string? Summary { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int? PriceNew { get; set; }
        public int? PriceOld { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Suppiler { get; set; }
        public int? Status { get; set; }
        public DateTime? DateAdded { get; set; }

        public virtual SubCategory? SubCategories { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
