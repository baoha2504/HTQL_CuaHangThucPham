using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPI.Entities
{
    public partial class GroceryStoreContext : DbContext
    {
        public GroceryStoreContext()
        {
        }

        public GroceryStoreContext(DbContextOptions<GroceryStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bill> Bills { get; set; } = null!;
        public virtual DbSet<BillDetail> BillDetails { get; set; } = null!;
        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Inventory> Inventories { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<OrderStatusHistory> OrderStatusHistories { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Shipping> Shippings { get; set; } = null!;
        public virtual DbSet<SubCategory> SubCategories { get; set; } = null!;
        public virtual DbSet<Voucher> Vouchers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=GroceryStore;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>(entity =>
            {
                entity.ToTable("Bill");

                entity.Property(e => e.BillId).HasColumnName("BillID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_Bill_Customer");
            });

            modelBuilder.Entity<BillDetail>(entity =>
            {
                entity.HasKey(e => e.BillDetail1)
                    .HasName("PK__BillDeta__2678F7C4401C4C24");

                entity.ToTable("BillDetail");

                entity.Property(e => e.BillDetail1).HasColumnName("BillDetail");

                entity.Property(e => e.BillId).HasColumnName("BillID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Bill)
                    .WithMany(p => p.BillDetails)
                    .HasForeignKey(d => d.BillId)
                    .HasConstraintName("fk_BillDetail_Bill");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.BillDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_BillDetail_Product");
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog");

                entity.Property(e => e.BlogId).HasColumnName("BlogID");

                entity.Property(e => e.Content).HasMaxLength(4000);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DateAdded).HasColumnType("date");

                entity.Property(e => e.Image)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("Blog_Customer");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.CartId).HasColumnName("CartID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Cart_Customer");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Cart_Product");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoriesId);

                entity.Property(e => e.CategoriesId).HasColumnName("CategoriesID");

                entity.Property(e => e.CategoriesName).HasMaxLength(50);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Address1).HasMaxLength(200);

                entity.Property(e => e.Address2).HasMaxLength(200);

                entity.Property(e => e.City).HasMaxLength(200);

                entity.Property(e => e.Company).HasMaxLength(200);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PassWord)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory");

                entity.Property(e => e.InventoryID).HasColumnName("InventoryID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DateAdded).HasColumnType("date");

                entity.Property(e => e.ExpirationDate).HasColumnType("date");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("Inventory_Customer");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("Inventory_Product");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DateAdd).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Note).HasMaxLength(1000);

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.Phone).HasMaxLength(10);

                entity.Property(e => e.ShippingAddress).HasMaxLength(200);

                entity.Property(e => e.ShippingId).HasColumnName("ShippingID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Order_Customer");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK_Order_Payment");

                entity.HasOne(d => d.Shipping)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShippingId)
                    .HasConstraintName("FK_Order_Shipping");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");

                entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderDetail_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_OrderDetail_Product");
            });

            modelBuilder.Entity<OrderStatusHistory>(entity =>
            {
                entity.HasKey(e => e.OrderStatusId);

                entity.ToTable("OrderStatusHistory");

                entity.Property(e => e.OrderStatusId).HasColumnName("OrderStatusID");

                entity.Property(e => e.CanceledBy).HasMaxLength(50);

                entity.Property(e => e.DateAdd).HasColumnType("datetime");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.OrderStatusName).HasMaxLength(50);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderStatusHistories)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderStatusHistory_Order");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.PaymentName).HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Brand).HasMaxLength(200);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.Image).HasMaxLength(200);

                entity.Property(e => e.Model).HasMaxLength(200);

                entity.Property(e => e.ProductName).HasMaxLength(200);

                entity.Property(e => e.SubCategoriesId).HasColumnName("SubCategoriesID");

                entity.Property(e => e.Summary).HasMaxLength(200);

                entity.Property(e => e.Suppiler).HasMaxLength(200);

                entity.HasOne(d => d.SubCategories)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SubCategoriesId)
                    .HasConstraintName("FK_Product_SubCategories");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Review");

                entity.Property(e => e.ReviewId).HasColumnName("ReviewID");

                entity.Property(e => e.Comment).HasMaxLength(200);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Review_Customer");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Review_Product");
            });

            modelBuilder.Entity<Shipping>(entity =>
            {
                entity.ToTable("Shipping");

                entity.Property(e => e.ShippingId).HasColumnName("ShippingID");

                entity.Property(e => e.ShippingName).HasMaxLength(50);
            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.HasKey(e => e.SubCategoriesId);

                entity.Property(e => e.SubCategoriesId).HasColumnName("SubCategoriesID");

                entity.Property(e => e.CategoriesId).HasColumnName("CategoriesID");

                entity.Property(e => e.SubCategoriesName).HasMaxLength(50);

                entity.HasOne(d => d.Categories)
                    .WithMany(p => p.SubCategories)
                    .HasForeignKey(d => d.CategoriesId)
                    .HasConstraintName("FK_SubCategories_Categories");
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.HasKey(e => new { e.VoucherId, e.VoucherCode })
                    .HasName("PK__Voucher__AD1ED20B8EFF76E3");

                entity.ToTable("Voucher");

                entity.Property(e => e.VoucherId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("VoucherID");

                entity.Property(e => e.VoucherCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Expiry).HasColumnType("date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Vouchers)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Voucher_Customer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
