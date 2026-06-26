using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProjeHakemConfiguration : IEntityTypeConfiguration<ProjeHakem>
{
    public void Configure(EntityTypeBuilder<ProjeHakem> builder)
    {
        builder.ToTable("tbl_projehakem");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");

        builder.Property(x => x.ProjeId).HasColumnName("proje_id").IsRequired();
        builder.Property(x => x.HakemId).HasColumnName("hakem_id").IsRequired();
        builder.Property(x => x.HakemlikDurumu).HasColumnName("hakemlik_durumu").HasConversion<int>().IsRequired();
        builder.Property(x => x.DavetTarihi).HasColumnName("davet_tarihi");
        builder.Property(x => x.CevapTarihi).HasColumnName("cevap_tarihi");
        builder.Property(x => x.DegerlendirmeTarihi).HasColumnName("degerlendirme_tarihi");
        builder.Property(x => x.CreatedDate).HasColumnName("created_date");
        builder.Property(x => x.UpdatedDate).HasColumnName("updated_date");
        builder.Property(x => x.DeletedDate).HasColumnName("deleted_date");

        builder.HasOne(x => x.Proje)
            .WithMany(x => x.ProjeHakemleri)
            .HasForeignKey(x => x.ProjeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Hakem)
            .WithMany(x => x.ProjeHakemleri)
            .HasForeignKey(x => x.HakemId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.ProjeId);
        builder.HasIndex(x => x.HakemId);
        builder.HasIndex(x => new { x.ProjeId, x.HakemId }).IsUnique();
        builder.HasIndex(x => x.HakemlikDurumu);
        builder.HasQueryFilter(x => x.DeletedDate == null);
    }
}
