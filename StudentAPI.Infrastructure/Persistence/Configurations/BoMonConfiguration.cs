using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentAPI.Domain.Entities;

namespace StudentAPI.Infrastructure.Persistence.Configurations;

public class BoMonConfiguration : IEntityTypeConfiguration<BoMon>
{
    public void Configure(EntityTypeBuilder<BoMon> builder)
    {
        builder.ToTable("BoMon");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .UseIdentityColumn();

        builder.Property(x => x.TenBoMon)
            .HasColumnName("tenMon")
            .HasMaxLength(60)
            .IsRequired(false);

        builder.Property(x => x.MaBoMon)
            .HasColumnName("maBM")
            .HasMaxLength(12)
            .IsUnicode(false)
            .IsRequired(false)
            .ValueGeneratedOnAddOrUpdate();
    }
}