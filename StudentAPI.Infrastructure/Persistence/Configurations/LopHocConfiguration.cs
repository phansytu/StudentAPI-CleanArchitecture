using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentAPI.Domain.Entities;

namespace StudentAPI.Infrastructure.Persistence.Configurations;

public class LopHocConfiguration : IEntityTypeConfiguration<LopHoc>
{
    public void Configure(EntityTypeBuilder<LopHoc> builder)
    {
        builder.ToTable("LopHoc");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .UseIdentityColumn();

        builder.Property(x => x.TenLop)
            .HasColumnName("tenLop")
            .HasMaxLength(10)
            .IsRequired()
            .HasDefaultValue("Tên Lớp");

        builder.Property(x => x.ChuyenNganh)
            .HasColumnName("chuyenNganh")
            .HasMaxLength(100)
            .IsRequired(false)
            .HasDefaultValue("Tên chuyên ngành");

        builder.Property(x => x.BoMonId)
            .HasColumnName("boMonId")
            .IsRequired(false);

        builder.Property(x => x.MaLop)
            .HasColumnName("MaLop")
            .HasMaxLength(11)
            .IsUnicode(false)
            .ValueGeneratedOnAddOrUpdate();

        builder.HasIndex(x => x.BoMonId)
            .HasDatabaseName("IX_LopHoc_boMonId");

        builder.HasOne(x => x.BoMon)
            .WithMany(x => x.LopHocs)
            .HasForeignKey(x => x.BoMonId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK__LopHoc__boMonId");
    }
}