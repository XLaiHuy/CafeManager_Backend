using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CafeManager.DAL.Models;

public partial class CafeContext : DbContext
{
    public CafeContext()
    {
    }

    public CafeContext(DbContextOptions<CafeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<Billinfo> Billinfos { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<Productcategory> Productcategories { get; set; }

    public virtual DbSet<Tablefood> Tablefoods { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("account_pkey");

            entity.ToTable("account");

            entity.HasIndex(e => e.Username, "account_username_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Displayname)
                .HasMaxLength(100)
                .HasColumnName("displayname");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.Type)
                .HasDefaultValue(0)
                .HasColumnName("type");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("bill_pkey");

            entity.ToTable("bill");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Datecheckin)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datecheckin");
            entity.Property(e => e.Discount)
                .HasDefaultValue(0)
                .HasColumnName("discount");
            entity.Property(e => e.Idaccount).HasColumnName("idaccount");
            entity.Property(e => e.Idcustomer).HasColumnName("idcustomer");
            entity.Property(e => e.Idtable).HasColumnName("idtable");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Status)
                .HasDefaultValue(0)
                .HasColumnName("status");

            entity.HasOne(d => d.IdaccountNavigation).WithMany(p => p.Bills)
                .HasForeignKey(d => d.Idaccount)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bill_idaccount_fkey");

            entity.HasOne(d => d.IdcustomerNavigation).WithMany(p => p.Bills)
                .HasForeignKey(d => d.Idcustomer)
                .HasConstraintName("bill_idcustomer_fkey");

            entity.HasOne(d => d.IdtableNavigation).WithMany(p => p.Bills)
                .HasForeignKey(d => d.Idtable)
                .HasConstraintName("bill_idtable_fkey");
        });

        modelBuilder.Entity<Billinfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("billinfo_pkey");

            entity.ToTable("billinfo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Count)
                .HasDefaultValue(0)
                .HasColumnName("count");
            entity.Property(e => e.Idbill).HasColumnName("idbill");
            entity.Property(e => e.Idfood).HasColumnName("idfood");
            entity.Property(e => e.Priceatsale)
                .HasPrecision(18, 2)
                .HasColumnName("priceatsale");

            entity.HasOne(d => d.IdbillNavigation).WithMany(p => p.Billinfos)
                .HasForeignKey(d => d.Idbill)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("billinfo_idbill_fkey");

            entity.HasOne(d => d.IdfoodNavigation).WithMany(p => p.Billinfos)
                .HasForeignKey(d => d.Idfood)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("billinfo_idfood_fkey");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("customer_pkey");

            entity.ToTable("customer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("food_pkey");

            entity.ToTable("food");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Idcategory).HasColumnName("idcategory");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(18, 2)
                .HasColumnName("price");

            entity.HasOne(d => d.IdcategoryNavigation).WithMany(p => p.Foods)
                .HasForeignKey(d => d.Idcategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("food_idcategory_fkey");
        });

        modelBuilder.Entity<Productcategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("productcategory_pkey");

            entity.ToTable("productcategory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Tablefood>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tablefood_pkey");

            entity.ToTable("tablefood");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValueSql("'Trống'::character varying")
                .HasColumnName("status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
