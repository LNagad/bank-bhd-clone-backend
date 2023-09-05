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

      entity.HasOne(product => product.Account)
        .WithOne(account => account.Product)
        .HasForeignKey<Product>(account => account.AccountId);

      entity.HasOne(product => product.CreditCard)
        .WithOne(card => card.Product)
        .HasForeignKey<Product>(card => card.CreditCardId);

      entity.HasOne(product => product.DebitCard)
        .WithOne(card => card.Product)
        .HasForeignKey<Product>(card => card.DebitCardId);

      entity.HasOne(product => product.Loan)
        .WithOne(loan => loan.Product)
        .HasForeignKey<Product>(loan => loan.LoanId);

      entity.HasOne(product => product.Client)
        .WithMany(client => client.Products)
        .HasForeignKey(product => product.ClientId);
;

      //Ignoring EF Core from doing innecesary JOINS in SQL Query
      //entity.Ignore(product => product.Account);
      //entity.Ignore(product => product.Loan);
      //entity.Ignore(product => product.CreditCard);
      //entity.Ignore(product => product.DebitCard);
      //entity.Ignore(product => product.Client);
      //entity.Ignore(product => product.ProductType);

      // Disable automatic loading of navigation properties
      //entity.Metadata.FindNavigation(nameof(Product.Account)).SetPropertyAccessMode(PropertyAccessMode.Field);
      //entity.Metadata.FindNavigation(nameof(Product.Loan)).SetPropertyAccessMode(PropertyAccessMode.Field);
      //entity.Metadata.FindNavigation(nameof(Product.CreditCard)).SetPropertyAccessMode(PropertyAccessMode.Field);
      //entity.Metadata.FindNavigation(nameof(Product.DebitCard)).SetPropertyAccessMode(PropertyAccessMode.Field);
      //entity.Metadata.FindNavigation(nameof(Product.Client)).SetPropertyAccessMode(PropertyAccessMode.Field);
      //entity.Metadata.FindNavigation(nameof(Product.ProductType)).SetPropertyAccessMode(PropertyAccessMode.Field);



      // Disabling auto include for navigation properties
      //entity.Navigation(product => product.Account).AutoInclude(false).UsePropertyAccessMode(PropertyAccessMode.Field);
      //entity.Navigation(product => product.Loan).AutoInclude(false).UsePropertyAccessMode(PropertyAccessMode.Field);
      //entity.Navigation(product => product.CreditCard).AutoInclude(false).UsePropertyAccessMode(PropertyAccessMode.Field);
      //entity.Navigation(product => product.DebitCard).AutoInclude(false).UsePropertyAccessMode(PropertyAccessMode.Field);
      //entity.Navigation(product => product.Client).AutoInclude(false).UsePropertyAccessMode(PropertyAccessMode.Field);
      //entity.Navigation(product => product.ProductType).AutoInclude(false).UsePropertyAccessMode(PropertyAccessMode.Field);
    }
  }
}