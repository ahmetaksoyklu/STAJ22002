using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class HazirMesajConfiguration : IEntityTypeConfiguration<HazirMesaj>
{
    public void Configure(EntityTypeBuilder<HazirMesaj> builder)
    {
        builder.ToTable("tbl_hazir_mesajlar");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Baslik).HasColumnName("baslik").HasMaxLength(200);
        builder.Property(x => x.Konu).HasColumnName("konu").HasMaxLength(300);
        builder.Property(x => x.Icerik).HasColumnName("icerik").HasColumnType("nvarchar(max)");
        builder.Property(x => x.AktifMi).HasColumnName("aktif_mi").HasDefaultValue(true);
        builder.Property(x => x.CreatedDate).HasColumnName("created_date");
        builder.Property(x => x.UpdatedDate).HasColumnName("updated_date");
        builder.Property(x => x.DeletedDate).HasColumnName("deleted_date");

        builder.HasQueryFilter(x => x.DeletedDate == null);
    }
}
