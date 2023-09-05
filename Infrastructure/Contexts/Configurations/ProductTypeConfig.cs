using BhdBankClone.Core.Application.Enums.BankSeeds;
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

      // Adding data to the table
      entity.HasData(
        new ProductType() 
        { 
          Id = (int)EProducts.CUENTA_AHORROS, 
          Description = EProducts.CUENTA_AHORROS.ToString() 
        },
        new ProductType() 
        { 
          Id = (int)EProducts.CUENTA_AHORROS_EMPRESARIAL, 
          Description = EProducts.CUENTA_AHORROS_EMPRESARIAL.ToString()
        }, 
        new ProductType() 
        { 
          Id = (int)EProducts.TARJETA_DEBITO, 
          Description = EProducts.TARJETA_DEBITO.ToString()
        },
        new ProductType()
        {
          Id = (int)EProducts.TARJETA_CREDITO,
          Description = EProducts.TARJETA_CREDITO.ToString()
        },
        new ProductType()
        {
          Id = (int)EProducts.PRESTAMO,
          Description = EProducts.PRESTAMO.ToString()
        }
      );
    }
  }

}
