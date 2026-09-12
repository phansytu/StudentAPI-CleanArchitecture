using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentAPI.Domain.Entities;

namespace StudentAPI.Infrastructure.Persistence.Configurations;

public class SinhVienConfiguration : IEntityTypeConfiguration<SinhVien>
{
    public void Configure(EntityTypeBuilder<SinhVien> builder)
    {

        builder.ToTable("SinhVien");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .UseIdentityColumn();

        builder.Property(x => x.HoTen)
            .HasColumnName("hoTen")
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(x => x.GioiTinh)
            .HasColumnName("gioiTinh")
            .IsRequired(false);

        builder.Property(x => x.NgaySinh)
            .HasColumnName("ngaySinh")
            .HasColumnType("date")
            .IsRequired(false);

        builder.Property(x => x.Email)
            .HasColumnName("email")
            .HasMaxLength(50)
            .IsUnicode(false)
            .IsRequired(false);

        builder.Property(x => x.DiemTB)
            .HasColumnName("diemTb")
            .HasPrecision(4, 2)
            .IsRequired(false);

        builder.Property(x => x.LopHocId)
            .HasColumnName("lopHocId")
            .IsRequired(false);

        builder.Property(x => x.MaSV)
            .HasColumnName("msv")
            .HasMaxLength(13)
            .IsUnicode(false)
            .ValueGeneratedOnAddOrUpdate();

        builder.HasIndex(x => x.LopHocId)
            .HasDatabaseName("IX_SinhVien_lopHocId");

        builder.HasOne(x => x.LopHoc)
            .WithMany(x => x.SinhViens)
            .HasForeignKey(x => x.LopHocId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK__SinhVien__lopHoc");
    }
}