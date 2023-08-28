using BhdBankClone.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BhdBankClone.Infrastructure.Persistence.Contexts.Configurations
{
  internal class LoanConfig : IEntityTypeConfiguration<Loan>
  {
    public void Configure(EntityTypeBuilder<Loan> entity)
    {
      entity.ToTable("loans");

      entity.HasKey(e => e.Id);

      entity.Property(e => e.Id)
              .ValueGeneratedNever()
              .HasColumnName("id");

      entity.Property(e => e.ClientId).HasColumnName("client_id");

      entity.Property(e => e.IsActive)
              .HasDefaultValue(true)
              .HasColumnName("isActive");

      entity.Property(e => e.LoanAmount)
              .HasColumnType("money")
              .HasColumnName("loan_amount");

      entity.Property(e => e.ProductId).HasColumnName("product_id");

      entity.HasMany<Transaction>()
            .WithOne(transaction => transaction.DestinationLoan)
            .HasForeignKey(transaction => transaction.DestinationLoanId);

      entity.HasIndex(e => e.IsActive, "loans_index_10");

    }
  }
}
