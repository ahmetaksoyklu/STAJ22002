using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProjeConfiguration : IEntityTypeConfiguration<Proje>
{
    public void Configure(EntityTypeBuilder<Proje> builder)
    {
        builder.ToTable("tbl_bapproje");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");

        builder.Property(x => x.Baslik).HasColumnName("baslik").IsRequired().HasMaxLength(300);
        builder.Property(x => x.Ozet).HasColumnName("ozet").HasColumnType("nvarchar(max)");
        builder.Property(x => x.YurutucuUserId).HasColumnName("yurutucu_user_id").IsRequired();
        builder.Property(x => x.ProjeTipiId).HasColumnName("proje_tipi_id").IsRequired();
        builder.Property(x => x.Durum).HasColumnName("durum").HasConversion<int>().IsRequired();
        builder.Property(x => x.BaslangicTarihi).HasColumnName("baslangic_tarihi");
        builder.Property(x => x.BitisTarihi).HasColumnName("bitis_tarihi");
        builder.Property(x => x.CreatedDate).HasColumnName("created_date");
        builder.Property(x => x.UpdatedDate).HasColumnName("updated_date");
        builder.Property(x => x.DeletedDate).HasColumnName("deleted_date");

        builder.HasIndex(x => x.Durum);
        builder.HasQueryFilter(x => x.DeletedDate == null);
    }
}
