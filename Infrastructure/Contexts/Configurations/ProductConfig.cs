using BhdBankClone.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BhdBankClone.Infrastructure.Persistence.Contexts.Configurations
{
  public class ProductConfig : IEntityTypeConfiguration<Product>
  {
    public void Configure(EntityTypeBuilder<Product> entity)
    {
      entity.ToTable("products");

      entity.HasKey(e => e.Id);

      entity.HasOne<Account>()
        .WithOne(acc => acc.Product)
        .HasForeignKey<Account>(Account => Account.ProductId);

      // client many relationship implemented

      entity.HasOne<CreditCard>()
        .WithOne(card => card.Product)
        .HasForeignKey<CreditCard>(card => card.ProductId);

      entity.HasOne<DebitCard>()
        .WithOne(card => card.Product)
        .HasForeignKey<DebitCard>(card => card.ProductId);

      entity.HasOne<Loan>()
        .WithOne(loan => loan.Product)
        .HasForeignKey<Loan>(loan => loan.ProductId);


    }
  }
}