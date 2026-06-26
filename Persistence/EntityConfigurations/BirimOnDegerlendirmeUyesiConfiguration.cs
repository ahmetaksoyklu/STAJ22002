using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BirimOnDegerlendirmeUyesiConfiguration : IEntityTypeConfiguration<BirimOnDegerlendirmeUyesi>
{
    public void Configure(EntityTypeBuilder<BirimOnDegerlendirmeUyesi> builder)
    {
        builder.ToTable("tbl_bapbirim_ondegerlendirme_uyesi");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Ad).HasColumnName("ad").IsRequired().HasMaxLength(120);
        builder.Property(x => x.Soyad).HasColumnName("soyad").IsRequired().HasMaxLength(120);
        builder.Property(x => x.Eposta).HasColumnName("eposta").IsRequired().HasMaxLength(255);
        builder.Property(x => x.BirimId).HasColumnName("birim_id").IsRequired();
        builder.Property(x => x.AktifMi).HasColumnName("aktif_mi").HasDefaultValue(true);
        builder.Property(x => x.CreatedDate).HasColumnName("created_date");
        builder.Property(x => x.UpdatedDate).HasColumnName("updated_date");
        builder.Property(x => x.DeletedDate).HasColumnName("deleted_date");

        builder.HasIndex(x => x.BirimId);
        builder.HasIndex(x => x.Eposta);
        builder.HasQueryFilter(x => x.DeletedDate == null);
    }
}
