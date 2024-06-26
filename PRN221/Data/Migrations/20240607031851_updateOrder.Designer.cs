﻿// <auto-generated />
using System;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(PRNDbContext))]
    [Migration("20240607031851_updateOrder")]
    partial class updateOrder
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Data.Entities.Blog", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("Blog", (string)null);
                });

            modelBuilder.Entity("Data.Entities.Order", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("totalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("updatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("voucherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.HasIndex("voucherId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("Data.Entities.OrderXProduct", b =>
                {
                    b.Property<Guid>("orderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("productId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("orderId", "productId");

                    b.HasIndex("productId");

                    b.ToTable("OrderXProduct", (string)null);
                });

            modelBuilder.Entity("Data.Entities.Product", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("productTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("stockQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("updatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("productTypeId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("Data.Entities.ProductFeedback", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("productId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("rating")
                        .HasColumnType("int");

                    b.Property<DateTime>("updatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("productId");

                    b.HasIndex("userId");

                    b.ToTable("ProductFeedback", (string)null);
                });

            modelBuilder.Entity("Data.Entities.ProductType", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("productType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("ProductType", (string)null);
                });

            modelBuilder.Entity("Data.Entities.Role", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("roleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("roleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("roleId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Data.Entities.Voucher", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("updatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("voucherTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("voucherTypeId");

                    b.ToTable("Voucher", (string)null);
                });

            modelBuilder.Entity("Data.Entities.VoucherType", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("typeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("VoucherType", (string)null);
                });

            modelBuilder.Entity("Data.Entities.Blog", b =>
                {
                    b.HasOne("Data.Entities.User", "User")
                        .WithMany("Blogs")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Blog_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.Order", b =>
                {
                    b.HasOne("Data.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Order_User");

                    b.HasOne("Data.Entities.Voucher", "Voucher")
                        .WithMany("orders")
                        .HasForeignKey("voucherId")
                        .HasConstraintName("FK_Order_Voucher");

                    b.Navigation("User");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("Data.Entities.OrderXProduct", b =>
                {
                    b.HasOne("Data.Entities.Order", "Order")
                        .WithMany("OrderXProducts")
                        .HasForeignKey("orderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_OrderXProduct_Order");

                    b.HasOne("Data.Entities.Product", "Product")
                        .WithMany("OrderXProducts")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_OrderXProduct_Product");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Data.Entities.Product", b =>
                {
                    b.HasOne("Data.Entities.ProductType", "productType")
                        .WithMany("products")
                        .HasForeignKey("productTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Product_ProductType");

                    b.Navigation("productType");
                });

            modelBuilder.Entity("Data.Entities.ProductFeedback", b =>
                {
                    b.HasOne("Data.Entities.Product", "product")
                        .WithMany("ProductFeedbacks")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ProductFeedback_Product");

                    b.HasOne("Data.Entities.User", "user")
                        .WithMany("ProductFeedbacks")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ProductFeedback_User");

                    b.Navigation("product");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.HasOne("Data.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("roleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_User_Role");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Data.Entities.Voucher", b =>
                {
                    b.HasOne("Data.Entities.VoucherType", "voucherType")
                        .WithMany("Vouchers")
                        .HasForeignKey("voucherTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Voucher_VoucherType");

                    b.Navigation("voucherType");
                });

            modelBuilder.Entity("Data.Entities.Order", b =>
                {
                    b.Navigation("OrderXProducts");
                });

            modelBuilder.Entity("Data.Entities.Product", b =>
                {
                    b.Navigation("OrderXProducts");

                    b.Navigation("ProductFeedbacks");
                });

            modelBuilder.Entity("Data.Entities.ProductType", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("Data.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.Navigation("Blogs");

                    b.Navigation("Orders");

                    b.Navigation("ProductFeedbacks");
                });

            modelBuilder.Entity("Data.Entities.Voucher", b =>
                {
                    b.Navigation("orders");
                });

            modelBuilder.Entity("Data.Entities.VoucherType", b =>
                {
                    b.Navigation("Vouchers");
                });
#pragma warning restore 612, 618
        }
    }
}
