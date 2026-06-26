using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class HarcamaConfiguration : IEntityTypeConfiguration<Harcama>
{
    public void Configure(EntityTypeBuilder<Harcama> builder)
    {
        builder.ToTable("tbl_bapharcama");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.ProjeId).HasColumnName("proje_id").IsRequired();
        builder.Property(x => x.ButceKalemi).HasColumnName("butce_kalemi").HasMaxLength(200);
        builder.Property(x => x.Tutar).HasColumnName("tutar").HasPrecision(18, 2);
        builder.Property(x => x.Aciklama).HasColumnName("aciklama").HasColumnType("nvarchar(max)");
        builder.Property(x => x.BelgeYolu).HasColumnName("belge_yolu").HasMaxLength(500);
        builder.Property(x => x.HarcamaTarihi).HasColumnName("harcama_tarihi");
        builder.Property(x => x.CreatedDate).HasColumnName("created_date");
        builder.Property(x => x.UpdatedDate).HasColumnName("updated_date");
        builder.Property(x => x.DeletedDate).HasColumnName("deleted_date");

        builder.HasOne(x => x.Proje)
            .WithMany(x => x.Harcamalar)
            .HasForeignKey(x => x.ProjeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.ProjeId);
        builder.HasIndex(x => x.ButceKalemi);
        builder.HasQueryFilter(x => x.DeletedDate == null);
    }
}
