using BhdBankClone.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BhdBankClone.Infrastructure.Persistence.Contexts.Configurations
{
  public class ProductTypeConfig : IEntityTypeConfiguration<ProductType>
  {
    public void Configure(EntityTypeBuilder<ProductType> entity)
    {
      entity.ToTable("product_types");

      entity.HasKey(e => e.Id);

      entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);

      entity.HasMany<Product>()
        .WithOne(product => product.ProductType)
        .HasForeignKey(product => product.ProductTypeId);
    }
  }

}
