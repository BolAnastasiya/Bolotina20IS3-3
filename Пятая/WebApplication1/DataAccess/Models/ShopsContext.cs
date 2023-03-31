using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Models
{
    public partial class ShopsContext : DbContext
    {
        public ShopsContext()
        {
        }

        public ShopsContext(DbContextOptions<ShopsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<DeliveryType> DeliveryTypes { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductOrder> ProductOrders { get; set; } = null!;
        public virtual DbSet<ProductSpecification> ProductSpecifications { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Specification> Specifications { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.DateCart)
                    .HasColumnType("date")
                    .HasColumnName("date_cart");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Cart__deleted__52593CB8");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Cart__userID__534D60F1");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<DeliveryType>(entity =>
            {
                entity.ToTable("DeliveryType");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.DeliveryType1)
                    .HasMaxLength(20)
                    .HasColumnName("delivery_type");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.DateOrder)
                    .HasColumnType("date")
                    .HasColumnName("date_order");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.DeliveryTypeId).HasColumnName("delivery_typeID");

                entity.Property(e => e.StatusId).HasColumnName("statusID");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.DeliveryType)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DeliveryTypeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Orders__delivery__4CA06362");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK__Orders__statusID__4BAC3F29");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Orders__deleted__4AB81AF0");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("categoryID");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Product__categor__44FF419A");
            });

            modelBuilder.Entity<ProductOrder>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ProductOrder");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__ProductOr__produ__4F7CD00D");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__ProductOr__value__4E88ABD4");
            });

            modelBuilder.Entity<ProductSpecification>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ProductSpecification");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.Property(e => e.SpecificationId).HasColumnName("specificationID");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ProductSp__value__46E78A0C");

                entity.HasOne(d => d.Specification)
                    .WithMany()
                    .HasForeignKey(d => d.SpecificationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__ProductSp__speci__47DBAE45");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Role1)
                    .HasMaxLength(20)
                    .HasColumnName("role");
            });

            modelBuilder.Entity<Specification>(entity =>
            {
                entity.ToTable("Specification");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("categoryID");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Specifications)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Specifica__categ__4222D4EF");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Status1).HasColumnName("status");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Login)
                    .HasMaxLength(20)
                    .HasColumnName("login");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .HasColumnName("password");

                entity.Property(e => e.RoleId).HasColumnName("roleID");

                entity.Property(e => e.Surname)
                    .HasMaxLength(20)
                    .HasColumnName("surname");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Users__roleID__3D5E1FD2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
