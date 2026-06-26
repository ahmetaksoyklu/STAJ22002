using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BirimOnDegerlendirmeRaporuConfiguration : IEntityTypeConfiguration<BirimOnDegerlendirmeRaporu>
{
    public void Configure(EntityTypeBuilder<BirimOnDegerlendirmeRaporu> builder)
    {
        builder.ToTable("tbl_bapbirim_ondegerlendirme_raporu");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.ProjeId).HasColumnName("proje_id").IsRequired();
        builder.Property(x => x.KurulUyesiId).HasColumnName("kurul_uyesi_id").IsRequired();
        builder.Property(x => x.FormKodu).HasColumnName("form_kodu").HasMaxLength(80);
        builder.Property(x => x.CevaplarJson).HasColumnName("cevaplar_json").HasColumnType("nvarchar(max)");
        builder.Property(x => x.DegerlendirmeSonucu).HasColumnName("degerlendirme_sonucu").HasConversion<int>();
        builder.Property(x => x.Gerekce).HasColumnName("gerekce").HasColumnType("nvarchar(max)");
        builder.Property(x => x.DosyaYolu).HasColumnName("dosya_yolu").HasMaxLength(500);
        builder.Property(x => x.CreatedDate).HasColumnName("created_date");
        builder.Property(x => x.UpdatedDate).HasColumnName("updated_date");
        builder.Property(x => x.DeletedDate).HasColumnName("deleted_date");

        builder.HasOne(x => x.Proje)
            .WithMany()
            .HasForeignKey(x => x.ProjeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.BirimOnDegerlendirmeUyesi)
            .WithMany(x => x.Raporlar)
            .HasForeignKey(x => x.KurulUyesiId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.ProjeId);
        builder.HasIndex(x => x.KurulUyesiId);
        builder.HasQueryFilter(x => x.DeletedDate == null);
    }
}
