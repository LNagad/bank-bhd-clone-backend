using BhdBankClone.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BhdBankClone.Infrastructure.Persistence.Contexts.Configurations
{
  public class ProductConfig : IEntityTypeConfiguration<Product>
  {
    public void Configure(EntityTypeBuilder<Product> entity)
    {
      entity.HasKey(e => e.Id);

      entity.ToTable("products");

      entity.Property(e => e.Id)
              .ValueGeneratedNever()
              .HasColumnName("id");

      entity.Property(e => e.AccountId).HasColumnName("account_id");
      entity.Property(e => e.ClientId).HasColumnName("client_id");
      entity.Property(e => e.CreditCardId).HasColumnName("credit_card_id");
      entity.Property(e => e.DebitCardId).HasColumnName("debit_card_id");
      entity.Property(e => e.LoanId).HasColumnName("loan_id");
      entity.Property(e => e.ProductTypeId).HasColumnName("product_type_id");

      entity.Property(e => e.IsAccount).HasColumnName("isAccount");
      entity.Property(e => e.IsCreditCard).HasColumnName("isCreditCard");
      entity.Property(e => e.IsDebitCard).HasColumnName("isDebitCard");
      entity.Property(e => e.IsLoan).HasColumnName("isLoan");

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