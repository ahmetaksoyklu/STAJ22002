using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class KomisyonUyesiConfiguration : IEntityTypeConfiguration<KomisyonUyesi>
{
    public void Configure(EntityTypeBuilder<KomisyonUyesi> builder)
    {
        builder.ToTable("tbl_bapkomisyonu");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Ad).HasColumnName("ad").IsRequired().HasMaxLength(120);
        builder.Property(x => x.Soyad).HasColumnName("soyad").IsRequired().HasMaxLength(120);
        builder.Property(x => x.Eposta).HasColumnName("eposta").IsRequired().HasMaxLength(255);
        builder.Property(x => x.Gorev).HasColumnName("gorev").HasMaxLength(120);
        builder.Property(x => x.AktifMi).HasColumnName("aktif_mi").HasDefaultValue(true);
        builder.Property(x => x.CreatedDate).HasColumnName("created_date");
        builder.Property(x => x.UpdatedDate).HasColumnName("updated_date");
        builder.Property(x => x.DeletedDate).HasColumnName("deleted_date");

        builder.HasIndex(x => x.Eposta).IsUnique();
        builder.HasQueryFilter(x => x.DeletedDate == null);
    }
}
