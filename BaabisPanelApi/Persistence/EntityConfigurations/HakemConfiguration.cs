using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class HakemConfiguration : IEntityTypeConfiguration<Hakem>
{
    public void Configure(EntityTypeBuilder<Hakem> builder)
    {
        builder.ToTable("tbl_baphakem");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");

        builder.Property(x => x.Ad).HasColumnName("ad").HasMaxLength(120);
        builder.Property(x => x.Soyad).HasColumnName("soyad").HasMaxLength(120);
        builder.Property(x => x.Eposta).HasColumnName("eposta").IsRequired().HasMaxLength(255);
        builder.Property(x => x.Unvan).HasColumnName("unvan").HasMaxLength(120);
        builder.Property(x => x.Kurum).HasColumnName("kurum").HasMaxLength(250);
        builder.Property(x => x.Telefon).HasColumnName("telefon").HasMaxLength(30);
        builder.Property(x => x.CreatedDate).HasColumnName("created_date");
        builder.Property(x => x.UpdatedDate).HasColumnName("updated_date");
        builder.Property(x => x.DeletedDate).HasColumnName("deleted_date");

        builder.HasIndex(x => x.Eposta).IsUnique();
        builder.HasQueryFilter(x => x.DeletedDate == null);
    }
}
