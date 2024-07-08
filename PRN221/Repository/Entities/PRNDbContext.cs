using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class PRNDbContext: DbContext
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
                e.HasKey(e => e.id);
                e.Property(x => x.id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWId()");

                e.Property(e => e.roleName).IsRequired();
            });

            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("User");
                e.HasKey(e => e.id);
                e.Property(x => x.id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWId()");

                e.Property(e => e.fullName);
                e.Property(e => e.email);
                e.Property(e => e.password);
                e.Property(e => e.telephone);
                e.Property(e => e.DOB);
                e.Property(e => e.gender);
                e.Property(e => e.address);
                e.Property(e => e.isDeleted);
                e.Property(e => e.createdDate);
                e.Property(e => e.updatedDate);

                e.HasOne(e => e.Role)
                .WithMany(e => e.Users)
                .HasForeignKey(e => e.roleId)
                .HasConstraintName("FK_User_Role");
            });

            modelBuilder.Entity<Blog>(e =>
            {
                e.ToTable("Blog");
                e.HasKey(x => x.id);
                e.Property(x => x.id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWId()");

                e.Property(x => x.title).IsRequired();
                e.Property(x => x.content).IsRequired();
                e.Property(x => x.isDeleted);
                e.Property(x => x.createdDate);
                e.Property(x => x.updatedDate);

                e.HasOne(x => x.User)
                .WithMany(x => x.Blogs)
                .HasForeignKey(x => x.userId)
                .HasConstraintName("FK_Blog_User");
            });

            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Order");
                e.HasKey(x => x.id);
                e.Property(x => x.id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWId()");

                e.Property(x => x.description);
                e.Property(x => x.totalPrice).IsRequired();
                e.Property(x => x.status);
                e.Property(x => x.createdDate);
                e.Property(x => x.updatedDate);

                e.HasOne(x => x.User)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.userId)
                .HasConstraintName("FK_Order_User");

                e.HasOne(x => x.Voucher)
                .WithMany(x => x.orders)
                .HasForeignKey(x => x.voucherId)
                .HasConstraintName("FK_Order_Voucher");
            });

            modelBuilder.Entity<Product>(e =>
            {
                e.ToTable("Product");
                e.HasKey(x => x.id);
                e.Property(x => x.id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWId()");

                e.Property(x => x.name).IsRequired();
                e.Property(x => x.description);
                e.Property(x => x.stockQuantity).IsRequired();
                e.Property(x => x.price).IsRequired();
                e.Property(x => x.isDeleted);
                e.Property(x => x.createdDate);
                e.Property(x => x.updatedDate);

                e.HasOne(x => x.productType)
                .WithMany(x => x.products)
                .HasForeignKey(x => x.productTypeId)
                .HasConstraintName("FK_Product_ProductType");
            });

            modelBuilder.Entity<ProductType>(e =>
            {
                e.ToTable("ProductType");
                e.HasKey(x => x.id);
                e.Property(x => x.id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWId()");

                e.Property(x => x.productType).IsRequired();
            });

            modelBuilder.Entity<OrderXProduct>(e =>
            {
                e.ToTable("OrderXProduct");
                e.Property(x => x.quantity).IsRequired();
                e.HasKey(x => new
                {
                    x.orderId, x.productId
                });

                e.HasOne(x => x.Order)
                .WithMany(o => o.OrderXProducts)
                .HasForeignKey(o => o.orderId)
                .HasConstraintName("FK_OrderXProduct_Order");

                e.HasOne(x => x.Product)
                .WithMany(p => p.OrderXProducts)
                .HasForeignKey(p => p.productId)
                .HasConstraintName("FK_OrderXProduct_Product");

            });

            modelBuilder.Entity<ProductFeedback>(e =>
            {
                e.ToTable("ProductFeedback");
                e.HasKey(e => e.id);
                e.Property(x => x.id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWId()");

                e.Property(e => e.rating).IsRequired();
                e.Property(e => e.comment);
                e.Property(e => e.isDeleted);
                e.Property(e => e.createdDate);
                e.Property(e => e.updatedDate);

                e.HasOne(e => e.user)
                .WithMany(e => e.ProductFeedbacks)
                .HasForeignKey(e => e.userId)
                .HasConstraintName("FK_ProductFeedback_User");


                e.HasOne(e => e.product)
                .WithMany(e => e.ProductFeedbacks)
                .HasForeignKey(e => e.productId)
                .HasConstraintName("FK_ProductFeedback_Product");
            });

            modelBuilder.Entity<Voucher>(e =>
            {
                e.ToTable("Voucher");
                e.HasKey(e => e.id);
                e.Property(x => x.id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWId()");
                e.Property(e => e.vouchername).IsRequired();
                e.Property(e => e.content).IsRequired();
                e.Property(e => e.isDeleted);
                e.Property(e => e.condition);
                e.Property(e => e.StartDate);
                e.Property(e => e.EndDate);
                e.Property(e => e.createdDate);
                e.Property(e => e.updatedDate);

                e.HasOne(e => e.voucherType)
                .WithMany(e => e.Vouchers)
                .HasForeignKey(e => e.voucherTypeId)
                .HasConstraintName("FK_Voucher_VoucherType");
            });

            modelBuilder.Entity<VoucherType>(e =>
            {
                e.ToTable("VoucherType");
                e.HasKey(e => e.id);
                e.Property(x => x.id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWId()");

                e.Property(e => e.typeName).IsRequired();
            });

        }


    }
}

