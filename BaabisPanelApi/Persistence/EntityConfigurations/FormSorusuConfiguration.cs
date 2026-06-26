using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class FormSorusuConfiguration : IEntityTypeConfiguration<FormSorusu>
{
    public void Configure(EntityTypeBuilder<FormSorusu> builder)
    {
        builder.ToTable("tbl_form_sorulari");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.FormSablonuId).HasColumnName("form_sablonu_id").IsRequired();
        builder.Property(x => x.SoruMetni).HasColumnName("soru_metni").HasColumnType("nvarchar(max)");
        builder.Property(x => x.CevapTipi).HasColumnName("cevap_tipi").HasConversion<int>();
        builder.Property(x => x.SiraNo).HasColumnName("sira_no").IsRequired();
        builder.Property(x => x.ZorunluMu).HasColumnName("zorunlu_mu");
        builder.Property(x => x.CreatedDate).HasColumnName("created_date");
        builder.Property(x => x.UpdatedDate).HasColumnName("updated_date");
        builder.Property(x => x.DeletedDate).HasColumnName("deleted_date");

        builder.HasOne(x => x.FormSablonu)
            .WithMany(x => x.Sorular)
            .HasForeignKey(x => x.FormSablonuId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.FormSablonuId);
        builder.HasIndex(x => new { x.FormSablonuId, x.SiraNo });
        builder.HasQueryFilter(x => x.DeletedDate == null);
    }
}
