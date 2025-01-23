using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using tovar.Models;

namespace tovar.Context;

public partial class User11028Context : DbContext
{
    public User11028Context()
    {
    }

    public User11028Context(DbContextOptions<User11028Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorytovar> Categorytovars { get; set; }

    public virtual DbSet<Manufacture> Manufactures { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=192.168.7.159;Database=user11028;Username=user11028;password=58271");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorytovar>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("categorytovar_pk");

            entity.ToTable("categorytovar", "tovar");

            entity.Property(e => e.CategoryId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("category_id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Manufacture>(entity =>
        {
            entity.HasKey(e => e.ManufactureId).HasName("manufacture_pk");

            entity.ToTable("manufacture", "tovar");

            entity.Property(e => e.ManufactureId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("manufacture_id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.PeoductId).HasName("product_pk");

            entity.ToTable("product", "tovar");

            entity.Property(e => e.PeoductId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("peoduct_id");
            entity.Property(e => e.Articul)
                .HasColumnType("character varying")
                .HasColumnName("articul");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Cost)
                .HasColumnType("money")
                .HasColumnName("cost");
            entity.Property(e => e.CurrentDiscount).HasColumnName("current_discount");
            entity.Property(e => e.Desc)
                .HasColumnType("character varying")
                .HasColumnName("desc");
            entity.Property(e => e.Edinicaizm)
                .HasColumnType("character varying")
                .HasColumnName("edinicaizm");
            entity.Property(e => e.ManufactureId).HasColumnName("manufacture_id");
            entity.Property(e => e.MaxDiscount).HasColumnName("max_discount");
            entity.Property(e => e.NameProduct)
                .HasColumnType("character varying")
                .HasColumnName("name_product");
            entity.Property(e => e.Photo)
                .HasColumnType("character varying")
                .HasColumnName("photo");
            entity.Property(e => e.Quantytu).HasColumnName("quantytu");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("product_categorytovar_fk");

            entity.HasOne(d => d.Manufacture).WithMany(p => p.Products)
                .HasForeignKey(d => d.ManufactureId)
                .HasConstraintName("product_manufacture_fk");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("product_supplier_fk");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("role_pk");

            entity.ToTable("role", "tovar");

            entity.Property(e => e.RoleId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasColumnType("character varying")
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SuplierId).HasName("supplier_pk");

            entity.ToTable("supplier", "tovar");

            entity.Property(e => e.SuplierId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("suplier_id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("user_pk");

            entity.ToTable("user", "tovar");

            entity.Property(e => e.UserId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("user_id");
            entity.Property(e => e.Login)
                .HasColumnType("character varying")
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.Patronomic)
                .HasColumnType("character varying")
                .HasColumnName("patronomic");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Surname)
                .HasColumnType("character varying")
                .HasColumnName("surname");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("user_role_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
