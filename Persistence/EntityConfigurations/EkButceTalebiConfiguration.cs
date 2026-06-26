using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class EkButceTalebiConfiguration : IEntityTypeConfiguration<EkButceTalebi>
{
    public void Configure(EntityTypeBuilder<EkButceTalebi> builder)
    {
        builder.ToTable("tbl_bapekbutce_talebi");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.ProjeId).HasColumnName("proje_id").IsRequired();
        builder.Property(x => x.TalepEdilenTutar).HasColumnName("talep_edilen_tutar").HasPrecision(18, 2);
        builder.Property(x => x.KabulEdilenTutar).HasColumnName("kabul_edilen_tutar").HasPrecision(18, 2);
        builder.Property(x => x.Gerekce).HasColumnName("gerekce").HasColumnType("nvarchar(max)");
        builder.Property(x => x.DosyaYolu).HasColumnName("dosya_yolu").HasMaxLength(500);
        builder.Property(x => x.Karar).HasColumnName("karar").HasConversion<int>().HasDefaultValue(TalepDurumu.Beklemede);
        builder.Property(x => x.KararTarihi).HasColumnName("karar_tarihi");
        builder.Property(x => x.CreatedDate).HasColumnName("created_date");
        builder.Property(x => x.UpdatedDate).HasColumnName("updated_date");
        builder.Property(x => x.DeletedDate).HasColumnName("deleted_date");

        builder.HasOne(x => x.Proje)
            .WithMany(x => x.EkButceTalepleri)
            .HasForeignKey(x => x.ProjeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.ProjeId);
        builder.HasQueryFilter(x => x.DeletedDate == null);
    }
}
