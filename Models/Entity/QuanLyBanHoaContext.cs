using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace qlbhAPI.Models.Entity;

public partial class QuanLyBanHoaContext : DbContext
{
    public QuanLyBanHoaContext()
    {
    }

    public QuanLyBanHoaContext(DbContextOptions<QuanLyBanHoaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DeTai> DeTais { get; set; }

    public virtual DbSet<GiangVien> GiangViens { get; set; }

    public virtual DbSet<HuongDan> HuongDans { get; set; }

    public virtual DbSet<Khoa> Khoas { get; set; }

    public virtual DbSet<SinhVien> SinhViens { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=Default");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
