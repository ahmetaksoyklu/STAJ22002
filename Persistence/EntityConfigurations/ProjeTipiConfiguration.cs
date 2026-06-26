using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProjeTipiConfiguration : IEntityTypeConfiguration<ProjeTipi>
{
    public void Configure(EntityTypeBuilder<ProjeTipi> builder)
    {
        builder.ToTable("tbl_proje_tipleri");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Ad).HasColumnName("ad").HasMaxLength(150);
        builder.Property(x => x.Aciklama).HasColumnName("aciklama").HasColumnType("nvarchar(max)");
        builder.Property(x => x.AktifMi).HasColumnName("aktif_mi").HasDefaultValue(true);
        builder.Property(x => x.CreatedDate).HasColumnName("created_date");
        builder.Property(x => x.UpdatedDate).HasColumnName("updated_date");
        builder.Property(x => x.DeletedDate).HasColumnName("deleted_date");

        builder.HasIndex(x => x.Ad).IsUnique();
        builder.HasQueryFilter(x => x.DeletedDate == null);
    }
}
