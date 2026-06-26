using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProformaFaturaConfiguration : IEntityTypeConfiguration<ProformaFatura>
{
    public void Configure(EntityTypeBuilder<ProformaFatura> builder)
    {
        builder.ToTable("tbl_bapproformafatura");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");

        builder.Property(x => x.ProjeId).HasColumnName("proje_id").IsRequired();
        builder.Property(x => x.FirmaAdi).HasColumnName("firma_adi").IsRequired().HasMaxLength(250);
        builder.Property(x => x.Tutar).HasColumnName("tutar").HasPrecision(18, 2);
        builder.Property(x => x.DosyaYolu).HasColumnName("dosya_yolu").HasMaxLength(500);
        builder.Property(x => x.CreatedDate).HasColumnName("created_date");
        builder.Property(x => x.UpdatedDate).HasColumnName("updated_date");
        builder.Property(x => x.DeletedDate).HasColumnName("deleted_date");

        builder.HasOne(x => x.Proje)
            .WithMany(x => x.ProformaFaturalar)
            .HasForeignKey(x => x.ProjeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.ProjeId);
        builder.HasQueryFilter(x => x.DeletedDate == null);
    }
}
