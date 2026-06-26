using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OturumKaydiConfiguration : IEntityTypeConfiguration<OturumKaydi>
{
    public void Configure(EntityTypeBuilder<OturumKaydi> builder)
    {
        builder.ToTable("tbl_oturum_kaydi");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Email).HasColumnName("email").HasMaxLength(255);
        builder.Property(x => x.IpAdresi).HasColumnName("ip_adresi").HasMaxLength(50);
        builder.Property(x => x.BasariliMi).HasColumnName("basarili_mi");
        builder.Property(x => x.Aciklama).HasColumnName("aciklama").HasColumnType("nvarchar(max)");
        builder.Property(x => x.CreatedDate).HasColumnName("created_date");
        builder.Property(x => x.UpdatedDate).HasColumnName("updated_date");
        builder.Property(x => x.DeletedDate).HasColumnName("deleted_date");

        builder.HasIndex(x => x.Email);
        builder.HasIndex(x => x.CreatedDate);
        // Oturum kayıtlarında geçmiş denetim için soft delete filtresi uygulanmaz.
    }
}
