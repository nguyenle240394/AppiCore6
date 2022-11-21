using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoApiNet6.Data;

public partial class WmsClpDnTestContext : DbContext
{
    public WmsClpDnTestContext()
    {
    }

    public WmsClpDnTestContext(DbContextOptions<WmsClpDnTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DmBillOfLading> DmBillOfLadings { get; set; }

    public virtual DbSet<SaUser> SaUsers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DmBillOfLading>(entity =>
        {
            entity.HasKey(e => new { e.ShipKey, e.Hblno });

            entity.ToTable("DM_BillOfLading");

            entity.HasIndex(e => e.RowId, "UNQ_RowID_DM_BillOfLading").IsUnique();

            entity.Property(e => e.ShipKey).HasMaxLength(20);
            entity.Property(e => e.Hblno)
                .HasMaxLength(40)
                .HasColumnName("HBLNo");
            entity.Property(e => e.BondedWarehouseContractNo)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EnterpriseCode)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.FromPort).HasMaxLength(100);
            entity.Property(e => e.InwardDeclarationDate).HasColumnType("datetime");
            entity.Property(e => e.InwardDeclarationNo)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.InwardDeclarationStatus)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Lcnumber)
                .HasMaxLength(40)
                .HasColumnName("LCNumber");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.NoteBill).HasMaxLength(100);
            entity.Property(e => e.OutwardDeclarationDate).HasColumnType("datetime");
            entity.Property(e => e.OutwardDeclarationNo)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.OutwardDeclarationStatus)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Pod)
                .HasMaxLength(6)
                .HasColumnName("POD");
            entity.Property(e => e.Pol)
                .HasMaxLength(6)
                .HasColumnName("POL");
            entity.Property(e => e.Quantity).HasColumnType("decimal(28, 8)");
            entity.Property(e => e.RowId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("RowID");
            entity.Property(e => e.SaleContractDate).HasColumnType("datetime");
            entity.Property(e => e.SaleContractNo).HasMaxLength(40);
            entity.Property(e => e.UnitCode)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SaUser>(entity =>
        {
            entity.HasKey(e => e.UserCode);

            entity.ToTable("SA_User");

            entity.Property(e => e.UserCode)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DataModifiers)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.EmployeeCode)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.EnterpriseCode).HasMaxLength(10);
            entity.Property(e => e.FaxNumber).HasMaxLength(40);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PasswordExpiredDate).HasColumnType("datetime");
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(40);
            entity.Property(e => e.Position).HasMaxLength(255);
            entity.Property(e => e.RowId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("RowID");
            entity.Property(e => e.UserFullName).HasMaxLength(255);
            entity.Property(e => e.UserName).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
