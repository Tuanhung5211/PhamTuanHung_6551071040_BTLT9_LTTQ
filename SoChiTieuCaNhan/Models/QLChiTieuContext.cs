using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SoChiTieuCaNhan.Models;

public partial class QLChiTieuContext : DbContext
{
    public QLChiTieuContext()
    {
    }

    public QLChiTieuContext(DbContextOptions<QLChiTieuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTieu> ChiTieus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Chuỗi kết nối được cung cấp từ Program.cs.
        // Không cấu hình lại tại đây.
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTieu>(entity =>
        {
            entity.HasKey(e => e.MaCt).HasName("PK__ChiTieu__27258E74C01BCA65");

            entity.ToTable("ChiTieu");

            entity.Property(e => e.MaCt).HasColumnName("MaCT");
            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.LoaiChi).HasMaxLength(30);
            entity.Property(e => e.NoiDung).HasMaxLength(100);
            entity.Property(e => e.SoTien).HasColumnType("decimal(18, 0)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
