using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BirimConfiguration : IEntityTypeConfiguration<Birim>
{
    public void Configure(EntityTypeBuilder<Birim> builder)
    {
        builder.ToTable("tbl_birimler");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.BirimAdi).HasColumnName("birim_adi").HasMaxLength(250);
        builder.Property(x => x.BirimKodu).HasColumnName("birim_kodu").HasMaxLength(50);
        builder.Property(x => x.AktifMi).HasColumnName("aktif_mi").HasDefaultValue(true);
        builder.Property(x => x.CreatedDate).HasColumnName("created_date");
        builder.Property(x => x.UpdatedDate).HasColumnName("updated_date");
        builder.Property(x => x.DeletedDate).HasColumnName("deleted_date");

        builder.HasIndex(x => x.BirimKodu).IsUnique();
        builder.HasQueryFilter(x => x.DeletedDate == null);
    }
}
