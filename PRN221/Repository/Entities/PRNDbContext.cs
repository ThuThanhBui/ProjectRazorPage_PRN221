using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class PRNDbContext : DbContext
    {
        public PRNDbContext() { }

        public PRNDbContext(DbContextOptions<PRNDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            var strConn = config.GetConnectionString("MyDB");
            return strConn;
        }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductFeedback> ProductFeedbacks { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }
        public virtual DbSet<VoucherType> VoucherTypes { get; set; }
        public virtual DbSet<OrderXProduct> OrderXProducts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>(e =>
            {
                e.ToTable("Role");
                e.HasKey(e => e.Id);
                e.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWId()");

                e.Property(e => e.RoleName).IsRequired();
            });

            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("User");
                e.HasKey(e => e.Id);
                e.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");

                e.Property(e => e.FullName);
                e.Property(e => e.Image);
                e.Property(e => e.Email);
                e.Property(e => e.Password);
                e.Property(e => e.Telephone);
                e.Property(e => e.Dob);
                e.Property(e => e.Gender);
                e.Property(e => e.Address);
                e.Property(e => e.IsDeleted);
                e.Property(e => e.CreatedDate);
                e.Property(e => e.LastUpdatedDate);

                e.HasOne(e => e.Role)
                    .WithMany(e => e.Users)
                    .HasForeignKey(e => e.RoleId)
                    .HasConstraintName("FK_User_Role");
            });


            modelBuilder.Entity<Blog>(e =>
            {
                e.ToTable("Blog");
                e.HasKey(e => e.Id);
                e.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");

                e.Property(e => e.Image);

                e.Property(e => e.Title).IsRequired();
                e.Property(e => e.Content).IsRequired();
                e.Property(e => e.IsDeleted);
                e.Property(e => e.CreatedDate);
                e.Property(e => e.LastUpdatedDate);

                e.HasOne(e => e.User)
                    .WithMany(e => e.Blogs)
                    .HasForeignKey(e => e.UserId)
                    .HasConstraintName("FK_Blog_User");
            });


            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Order");
                e.HasKey(e => e.Id);
                e.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");

                e.Property(e => e.Description);
                e.Property(e => e.TotalPrice).IsRequired();
                e.Property(e => e.Status);
                e.Property(e => e.IsDeleted);
                e.Property(e => e.CreatedDate);
                e.Property(e => e.LastUpdatedDate);

                e.HasOne(e => e.User)
                    .WithMany(e => e.Orders)
                    .HasForeignKey(e => e.UserId)
                    .HasConstraintName("FK_Order_User");

                e.HasOne(e => e.Voucher)
                    .WithMany(e => e.Orders)
                    .HasForeignKey(e => e.VoucherId)
                    .HasConstraintName("FK_Order_Voucher");
            });

            modelBuilder.Entity<Product>(e =>
            {
                e.ToTable("Product");
                e.HasKey(e => e.Id);
                e.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");

                e.Property(e => e.Brand);
                e.Property(e => e.AverageRating);
                e.Property(e => e.Image);
                e.Property(e => e.ProductName).IsRequired();
                e.Property(e => e.Description);
                e.Property(e => e.StockQuantity).IsRequired();
                e.Property(e => e.Price).IsRequired();
                e.Property(e => e.IsDeleted);
                e.Property(e => e.CreatedDate);
                e.Property(e => e.LastUpdatedDate);

                e.HasOne(e => e.ProductType)
                    .WithMany(e => e.Products)
                    .HasForeignKey(e => e.ProductTypeId)
                    .HasConstraintName("FK_Product_ProductType");
            });


            modelBuilder.Entity<ProductType>(e =>
            {
                e.ToTable("ProductType");
                e.HasKey(e => e.Id);
                e.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");

                e.Property(e => e.ProductTypeName).IsRequired();
            });

            modelBuilder.Entity<OrderXProduct>(e =>
            {
                e.ToTable("OrderXProduct");
                e.HasKey(e => e.Id);
                e.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
                e.Property(e => e.Quantity).IsRequired();

                e.Property(e => e.IsDeleted);
                e.Property(e => e.CreatedDate);
                e.Property(e => e.LastUpdatedDate);

                e.HasOne(e => e.Order)
                    .WithMany(o => o.OrderXProducts)
                    .HasForeignKey(o => o.OrderId)
                    .HasConstraintName("FK_OrderXProduct_Order");

                e.HasOne(e => e.Product)
                    .WithMany(p => p.OrderXProducts)
                    .HasForeignKey(p => p.ProductId)
                    .HasConstraintName("FK_OrderXProduct_Product");
            });


            modelBuilder.Entity<ProductFeedback>(e =>
            {
                e.ToTable("ProductFeedback");
                e.HasKey(e => e.Id);
                e.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");

                e.Property(e => e.Rating).IsRequired();
                e.Property(e => e.Comment);
                e.Property(e => e.IsDeleted);
                e.Property(e => e.CreatedDate);
                e.Property(e => e.LastUpdatedDate);

                e.HasOne(e => e.User)
                    .WithMany(u => u.ProductFeedbacks)
                    .HasForeignKey(e => e.UserId)
                    .HasConstraintName("FK_ProductFeedback_User");

                e.HasOne(e => e.Product)
                    .WithMany(p => p.ProductFeedbacks)
                    .HasForeignKey(e => e.ProductId)
                    .HasConstraintName("FK_ProductFeedback_Product");
            });

            modelBuilder.Entity<Voucher>(e =>
            {
                e.ToTable("Voucher");
                e.HasKey(e => e.Id);
                e.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
                e.Property(e => e.VoucherName).IsRequired();
                e.Property(e => e.Content).IsRequired();
                e.Property(e => e.IsDeleted);
                e.Property(e => e.Condition);
                e.Property(e => e.StartDate);
                e.Property(e => e.EndDate);
                e.Property(e => e.CreatedDate);
                e.Property(e => e.LastUpdatedDate);

                e.HasOne(e => e.VoucherType)
                    .WithMany(vt => vt.Vouchers)
                    .HasForeignKey(e => e.VoucherTypeId)
                    .HasConstraintName("FK_Voucher_VoucherType");
            });

            modelBuilder.Entity<VoucherType>(e =>
            {
                e.ToTable("VoucherType");
                e.HasKey(e => e.Id);
                e.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");

                e.Property(e => e.VoucherTypeName).IsRequired();
            });


        }


    }
}

