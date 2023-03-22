using System;
using System.Collections.Generic;

namespace WebAPI.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Blogs = new HashSet<Blog>();
            Carts = new HashSet<Cart>();
            Inventories = new HashSet<Inventory>();
            Orders = new HashSet<Order>();
            Reviews = new HashSet<Review>();
            Vouchers = new HashSet<Voucher>();
        }

        public int CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PassWord { get; set; }
        public string? Phone { get; set; }
        public string? Company { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public int Access { get; set; }
        public int Prohibit { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}
