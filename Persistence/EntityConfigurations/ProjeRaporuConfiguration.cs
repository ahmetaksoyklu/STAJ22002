using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProjeRaporuConfiguration : IEntityTypeConfiguration<ProjeRaporu>
{
    public void Configure(EntityTypeBuilder<ProjeRaporu> builder)
    {
        builder.ToTable("tbl_bapproje_raporu");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.ProjeId).HasColumnName("proje_id").IsRequired();
        builder.Property(x => x.RaporKodu).HasColumnName("rapor_kodu").HasConversion<int>().IsRequired();
        builder.Property(x => x.DosyaYolu).HasColumnName("dosya_yolu").HasMaxLength(500);
        builder.Property(x => x.HakemeGonderildiMi).HasColumnName("hakeme_gonderildi_mi").HasDefaultValue(false);
        builder.Property(x => x.GonderimTarihi).HasColumnName("gonderim_tarihi");
        builder.Property(x => x.HakemOnayi).HasColumnName("hakem_onayi");
        builder.Property(x => x.CreatedDate).HasColumnName("created_date");
        builder.Property(x => x.UpdatedDate).HasColumnName("updated_date");
        builder.Property(x => x.DeletedDate).HasColumnName("deleted_date");

        builder.HasOne(x => x.Proje)
            .WithMany(x => x.Raporlar)
            .HasForeignKey(x => x.ProjeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.ProjeId);
        builder.HasIndex(x => new { x.ProjeId, x.RaporKodu }).IsUnique();
        builder.HasQueryFilter(x => x.DeletedDate == null);
    }
}
