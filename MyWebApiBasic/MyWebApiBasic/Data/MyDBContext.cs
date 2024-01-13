using Microsoft.EntityFrameworkCore;

namespace MyWebApiBasic.Data
{
    public class MyDBContext:DbContext
    {
        public MyDBContext(DbContextOptions options): base(options) {
        
        }

        #region DbSet
        public DbSet<HangHoa> HangHoas { get; set;}
        public DbSet<Loai> Loais { get; set;}
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<DonHangChiTiet> DonHangChiTiets { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>(e =>
            {
                e.ToTable("DonHang");
                e.HasKey(dh => dh.MaDonHang);
                e.Property(dh => dh.NgayDat).HasDefaultValueSql("getutcdate()");
                e.Property(dh => dh.NguoiNhanHang).IsRequired().HasMaxLength(100);
            });


            modelBuilder.Entity<DonHangChiTiet>(e =>
            {
                e.ToTable("DonHangChiTiet");
                e.HasKey(e => new { e.MaHh, e.MaDonHang });
                e.HasOne(e => e.DonHang)
                .WithMany(e => e.donHangChiTiets)
                .HasForeignKey(e => e.MaHh)
                .HasConstraintName("FK_DonHangChiTiet_HangHoa");
            });
           
        }
    }
}
