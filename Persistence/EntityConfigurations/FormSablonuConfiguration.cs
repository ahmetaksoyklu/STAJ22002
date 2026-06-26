using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class FormSablonuConfiguration : IEntityTypeConfiguration<FormSablonu>
{
    public void Configure(EntityTypeBuilder<FormSablonu> builder)
    {
        builder.ToTable("tbl_form_sablonlari");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Kod).HasColumnName("kod").IsRequired().HasMaxLength(80);
        builder.Property(x => x.Ad).HasColumnName("ad").HasMaxLength(200);
        builder.Property(x => x.Aciklama).HasColumnName("aciklama").HasColumnType("nvarchar(max)");
        builder.Property(x => x.AktifMi).HasColumnName("aktif_mi").HasDefaultValue(true);
        builder.Property(x => x.CreatedDate).HasColumnName("created_date");
        builder.Property(x => x.UpdatedDate).HasColumnName("updated_date");
        builder.Property(x => x.DeletedDate).HasColumnName("deleted_date");

        builder.HasIndex(x => x.Kod).IsUnique();
        builder.HasQueryFilter(x => x.DeletedDate == null);
    }
}
