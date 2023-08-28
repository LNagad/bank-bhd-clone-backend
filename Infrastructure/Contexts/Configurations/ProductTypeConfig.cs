using BhdBankClone.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BhdBankClone.Infrastructure.Persistence.Contexts.Configurations
{
  public class ProductTypeConfig : IEntityTypeConfiguration<ProductType>
  {
    public void Configure(EntityTypeBuilder<ProductType> entity)
    {
      entity.ToTable("product_types");

      entity.HasKey(e => e.Id);

      entity.Property(e => e.Id)
              .ValueGeneratedNever()
              .HasColumnName("id");

      entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("description");

      entity.HasMany<Product>()
        .WithOne(product => product.ProductType)
        .HasForeignKey(product => product.ProductTypeId);
    }
  }

}
