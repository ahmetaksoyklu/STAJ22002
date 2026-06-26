using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ProductID");
        builder.Property(x => x.CategoryId).HasColumnName("CategoryID");
        builder.Property(x => x.ProductName).HasColumnName("ProductName").HasMaxLength(40);
        builder.Property(x => x.UnitsInStock).HasColumnName("UnitsInStock");
        builder.Property(x => x.UnitPrice).HasColumnName("UnitPrice").HasColumnType("money");

        builder.Ignore(x => x.CreatedDate);
        builder.Ignore(x => x.UpdatedDate);
        builder.Ignore(x => x.DeletedDate);
    }
}
