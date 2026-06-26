using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DetayliButceConfiguration : IEntityTypeConfiguration<DetayliButce>
{
    public void Configure(EntityTypeBuilder<DetayliButce> builder)
    {
        builder.ToTable("tbl_bapdetaylibutce");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");

        builder.Property(x => x.ProjeId).HasColumnName("proje_id").IsRequired();
        builder.Property(x => x.ButceKalemi).HasColumnName("butce_kalemi").IsRequired().HasMaxLength(200);
        builder.Property(x => x.TalepEdilenTutar).HasColumnName("talep_edilen_tutar").HasPrecision(18, 2);
        builder.Property(x => x.Aciklama).HasColumnName("aciklama").HasColumnType("nvarchar(max)");
        builder.Property(x => x.CreatedDate).HasColumnName("created_date");
        builder.Property(x => x.UpdatedDate).HasColumnName("updated_date");
        builder.Property(x => x.DeletedDate).HasColumnName("deleted_date");

        builder.HasOne(x => x.Proje)
            .WithMany(x => x.DetayliButceler)
            .HasForeignKey(x => x.ProjeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.ProjeId);
        builder.HasQueryFilter(x => x.DeletedDate == null);
    }
}
