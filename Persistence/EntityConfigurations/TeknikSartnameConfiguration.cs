using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TeknikSartnameConfiguration : IEntityTypeConfiguration<TeknikSartname>
{
    public void Configure(EntityTypeBuilder<TeknikSartname> builder)
    {
        builder.ToTable("tbl_baptekniksartname");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");

        builder.Property(x => x.ProjeId).HasColumnName("proje_id").IsRequired();
        builder.Property(x => x.Baslik).HasColumnName("baslik").IsRequired().HasMaxLength(300);
        builder.Property(x => x.Aciklama).HasColumnName("aciklama").HasColumnType("nvarchar(max)");
        builder.Property(x => x.DosyaYolu).HasColumnName("dosya_yolu").HasMaxLength(500);
        builder.Property(x => x.CreatedDate).HasColumnName("created_date");
        builder.Property(x => x.UpdatedDate).HasColumnName("updated_date");
        builder.Property(x => x.DeletedDate).HasColumnName("deleted_date");

        builder.HasOne(x => x.Proje)
            .WithMany(x => x.TeknikSartnameler)
            .HasForeignKey(x => x.ProjeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.ProjeId);
        builder.HasQueryFilter(x => x.DeletedDate == null);
    }
}
