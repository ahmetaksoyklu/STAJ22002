using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class LogKaydiConfiguration : IEntityTypeConfiguration<LogKaydi>
{
    public void Configure(EntityTypeBuilder<LogKaydi> builder)
    {
        builder.ToTable("tbl_log_kaydi");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Kullanici).HasColumnName("kullanici").HasMaxLength(255);
        builder.Property(x => x.Controller).HasColumnName("controller").HasMaxLength(200);
        builder.Property(x => x.Islem).HasColumnName("islem").HasMaxLength(200);
        builder.Property(x => x.IpAdresi).HasColumnName("ip_adresi").HasMaxLength(50);
        builder.Property(x => x.CreatedDate).HasColumnName("created_date");
        builder.Property(x => x.UpdatedDate).HasColumnName("updated_date");
        builder.Property(x => x.DeletedDate).HasColumnName("deleted_date");

        builder.HasIndex(x => x.CreatedDate);
        // Log kayıtları sistemsel izleme verisi olduğu için normalde soft delete filtrelenmez.
    }
}
