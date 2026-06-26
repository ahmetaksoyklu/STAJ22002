using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SorunBildirimiConfiguration : IEntityTypeConfiguration<SorunBildirimi>
{
    public void Configure(EntityTypeBuilder<SorunBildirimi> builder)
    {
        builder.ToTable("tbl_sorun_bildirimleri");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Eposta).HasColumnName("eposta").HasMaxLength(255);
        builder.Property(x => x.Konu).HasColumnName("konu").HasMaxLength(300);
        builder.Property(x => x.Mesaj).HasColumnName("mesaj").HasColumnType("nvarchar(max)");
        builder.Property(x => x.IpAdresi).HasColumnName("ip_adresi").HasMaxLength(50);
        builder.Property(x => x.Durum).HasColumnName("durum").HasConversion<int>().HasDefaultValue(SorunDurumu.Acik);
        builder.Property(x => x.CreatedDate).HasColumnName("created_date");
        builder.Property(x => x.UpdatedDate).HasColumnName("updated_date");
        builder.Property(x => x.DeletedDate).HasColumnName("deleted_date");

        builder.HasQueryFilter(x => x.DeletedDate == null);
    }
}
