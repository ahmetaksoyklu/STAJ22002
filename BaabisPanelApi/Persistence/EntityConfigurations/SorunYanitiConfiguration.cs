using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SorunYanitiConfiguration : IEntityTypeConfiguration<SorunYaniti>
{
    public void Configure(EntityTypeBuilder<SorunYaniti> builder)
    {
        builder.ToTable("tbl_sorun_yanitlari");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.SorunBildirimiId).HasColumnName("sorun_bildirimi_id").IsRequired();
        builder.Property(x => x.Yanitlayan).HasColumnName("yanitlayan").HasMaxLength(255);
        builder.Property(x => x.Yanit).HasColumnName("yanit").HasColumnType("nvarchar(max)");
        builder.Property(x => x.CreatedDate).HasColumnName("created_date");
        builder.Property(x => x.UpdatedDate).HasColumnName("updated_date");
        builder.Property(x => x.DeletedDate).HasColumnName("deleted_date");

        builder.HasOne(x => x.SorunBildirimi)
            .WithMany(x => x.Yanitlar)
            .HasForeignKey(x => x.SorunBildirimiId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.SorunBildirimiId);
        builder.HasQueryFilter(x => x.DeletedDate == null);
    }
}
