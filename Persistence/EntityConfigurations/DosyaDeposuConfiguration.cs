using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DosyaDeposuConfiguration : IEntityTypeConfiguration<DosyaDeposu>
{
    public void Configure(EntityTypeBuilder<DosyaDeposu> builder)
    {
        builder.ToTable("tbl_dosya_deposu");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.SiraNo).HasColumnName("sira_no");
        builder.Property(x => x.DosyaAdi).HasColumnName("dosya_adi").HasMaxLength(255);
        builder.Property(x => x.DosyaYolu).HasColumnName("dosya_yolu").HasMaxLength(500);
        builder.Property(x => x.DosyaTipi).HasColumnName("dosya_tipi").HasConversion<int>();
        builder.Property(x => x.CreatedDate).HasColumnName("created_date");
        builder.Property(x => x.UpdatedDate).HasColumnName("updated_date");
        builder.Property(x => x.DeletedDate).HasColumnName("deleted_date");

        builder.HasIndex(x => x.DosyaTipi);
        builder.HasQueryFilter(x => x.DeletedDate == null);
    }
}
