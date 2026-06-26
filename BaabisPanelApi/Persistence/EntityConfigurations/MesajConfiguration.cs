using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MesajConfiguration : IEntityTypeConfiguration<Mesaj>
{
    public void Configure(EntityTypeBuilder<Mesaj> builder)
    {
        builder.ToTable("tbl_mesajlar");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Kimden).HasColumnName("kimden").IsRequired().HasMaxLength(255);
        builder.Property(x => x.Kime).HasColumnName("kime").IsRequired().HasMaxLength(255);
        builder.Property(x => x.Konu).HasColumnName("konu").HasMaxLength(300);
        builder.Property(x => x.Icerik).HasColumnName("icerik").HasColumnType("nvarchar(max)");
        builder.Property(x => x.OkunduMu).HasColumnName("okundu_mu").HasDefaultValue(false);
        builder.Property(x => x.SilindiMi).HasColumnName("silindi_mi").HasDefaultValue(false);
        builder.Property(x => x.CreatedDate).HasColumnName("created_date");
        builder.Property(x => x.UpdatedDate).HasColumnName("updated_date");
        builder.Property(x => x.DeletedDate).HasColumnName("deleted_date");

        builder.HasIndex(x => x.Kimden);
        builder.HasIndex(x => x.Kime);
        builder.HasQueryFilter(x => x.DeletedDate == null);
    }
}
