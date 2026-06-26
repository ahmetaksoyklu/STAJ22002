using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class YayinConfiguration : IEntityTypeConfiguration<Yayin>
{
    public void Configure(EntityTypeBuilder<Yayin> builder)
    {
        builder.ToTable("tbl_bapyayin");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.ProjeId).HasColumnName("proje_id").IsRequired();
        builder.Property(x => x.YayinBasligi).HasColumnName("yayin_basligi").HasMaxLength(300);
        builder.Property(x => x.DergiAdi).HasColumnName("dergi_adi").HasMaxLength(250);
        builder.Property(x => x.Doi).HasColumnName("doi").HasMaxLength(100);
        builder.Property(x => x.YayinTarihi).HasColumnName("yayin_tarihi");
        builder.Property(x => x.DosyaYolu).HasColumnName("dosya_yolu").HasMaxLength(500);
        builder.Property(x => x.CreatedDate).HasColumnName("created_date");
        builder.Property(x => x.UpdatedDate).HasColumnName("updated_date");
        builder.Property(x => x.DeletedDate).HasColumnName("deleted_date");

        builder.HasOne(x => x.Proje)
            .WithMany(x => x.Yayinlar)
            .HasForeignKey(x => x.ProjeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.ProjeId);
        builder.HasIndex(x => x.Doi);
        builder.HasQueryFilter(x => x.DeletedDate == null);
    }
}
