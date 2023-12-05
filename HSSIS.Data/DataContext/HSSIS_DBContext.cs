using System;
using System.Collections.Generic;
using HSSIS.Models.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HSSIS.Data.DataContext
{
    public partial class HSSIS_DBContext : DbContext
    {
        public HSSIS_DBContext()
        {
        }

        public HSSIS_DBContext(DbContextOptions<HSSIS_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssetCategoryModel> TblMasterAssetCategories { get; set; } = null!;
        public virtual DbSet<AssetSubCategoryModel> TblMasterAssetSubCategories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=PAWANKJANGID;Initial Catalog=HSSIS_DB;User ID=sa;Password=sql;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<AssetCategoryModel>(entity =>
            //{
                //entity.HasKey(e => e.AssetCategoryId);

                //entity.ToTable("TBL_Master_AssetCategory");

                //entity.Property(e => e.AssetCategoryName)
                //    .HasMaxLength(100)
                //    .IsUnicode(false);

                //entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                //entity.Property(e => e.Description).HasMaxLength(500);

                //entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            //});

            //modelBuilder.Entity<TblMasterAssetSubCategory>(entity =>
            //{
            //    entity.HasKey(e => e.AssetSubCategoryId);

            //    entity.ToTable("TBL_Master_AssetSubCategory");

            //    entity.Property(e => e.AssetSubCategoryName)
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.De)
            //        .HasMaxLength(10)
            //        .IsFixedLength();

            //    entity.Property(e => e.Description).HasMaxLength(500);

            //    entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            //});

            //OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
