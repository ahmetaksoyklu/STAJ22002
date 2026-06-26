using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class KomisyonKarariConfiguration : IEntityTypeConfiguration<KomisyonKarari>
{
    public void Configure(EntityTypeBuilder<KomisyonKarari> builder)
    {
        builder.ToTable("tbl_bapkomisyonu_karar");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.ProjeId).HasColumnName("proje_id").IsRequired();
        builder.Property(x => x.KomisyonUyesiId).HasColumnName("komisyon_uyesi_id").IsRequired();
        builder.Property(x => x.KararTipi).HasColumnName("karar_tipi").HasConversion<int>().IsRequired();
        builder.Property(x => x.KararMetni).HasColumnName("karar_metni").HasColumnType("nvarchar(max)");
        builder.Property(x => x.Gerekce).HasColumnName("gerekce").HasColumnType("nvarchar(max)");
        builder.Property(x => x.KararTarihi).HasColumnName("karar_tarihi");
        builder.Property(x => x.CreatedDate).HasColumnName("created_date");
        builder.Property(x => x.UpdatedDate).HasColumnName("updated_date");
        builder.Property(x => x.DeletedDate).HasColumnName("deleted_date");

        builder.HasOne(x => x.Proje)
            .WithMany(x => x.KomisyonKararlari)
            .HasForeignKey(x => x.ProjeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.KomisyonUyesi)
            .WithMany(x => x.KomisyonKararlari)
            .HasForeignKey(x => x.KomisyonUyesiId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.ProjeId);
        builder.HasIndex(x => x.KomisyonUyesiId);
        builder.HasQueryFilter(x => x.DeletedDate == null);
    }
}
