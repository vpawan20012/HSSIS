using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HSSIS.Data.DataContext;

public partial class HssisDbContext : DbContext
{
    public HssisDbContext()
    {
    }

    public HssisDbContext(DbContextOptions<HssisDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblMasterAssetCategory> TblMasterAssetCategories { get; set; }

    public virtual DbSet<TblMasterAssetSubCategory> TblMasterAssetSubCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=PAWANKJANGID;Initial Catalog=HSSIS_DB;User ID=sa;Password=sql;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblMasterAssetCategory>(entity =>
        {
            entity.HasKey(e => e.AssetCategoryId);

            entity.ToTable("TBL_Master_AssetCategory");

            entity.Property(e => e.AssetCategoryName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblMasterAssetSubCategory>(entity =>
        {
            entity.HasKey(e => e.AssetSubCategoryId);

            entity.ToTable("TBL_Master_AssetSubCategory");

            entity.Property(e => e.AssetSubCategoryName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.De)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
