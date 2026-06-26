using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProjeArastirmacisiConfiguration : IEntityTypeConfiguration<ProjeArastirmacisi>
{
    public void Configure(EntityTypeBuilder<ProjeArastirmacisi> builder)
    {
        builder.ToTable("tbl_bapproje_arastirmacilar");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");

        builder.Property(x => x.ProjeId).HasColumnName("proje_id").IsRequired();
        builder.Property(x => x.Ad).HasColumnName("ad").IsRequired().HasMaxLength(120);
        builder.Property(x => x.Soyad).HasColumnName("soyad").IsRequired().HasMaxLength(120);
        builder.Property(x => x.Eposta).HasColumnName("eposta").IsRequired().HasMaxLength(255);
        builder.Property(x => x.Kurum).HasColumnName("kurum").HasMaxLength(250);
        builder.Property(x => x.Gorev).HasColumnName("gorev").HasMaxLength(150);
        builder.Property(x => x.KatkiOrani).HasColumnName("katki_orani").HasPrecision(5, 2);
        builder.Property(x => x.CreatedDate).HasColumnName("created_date");
        builder.Property(x => x.UpdatedDate).HasColumnName("updated_date");
        builder.Property(x => x.DeletedDate).HasColumnName("deleted_date");

        builder.HasOne(x => x.Proje)
            .WithMany(x => x.Arastirmacilar)
            .HasForeignKey(x => x.ProjeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.ProjeId);
        builder.HasIndex(x => new { x.ProjeId, x.Eposta }).IsUnique();
        builder.HasQueryFilter(x => x.DeletedDate == null);
    }
}
