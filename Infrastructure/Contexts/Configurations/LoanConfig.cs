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

      entity.Property(e => e.IsActive)
              .HasDefaultValue(true);

      entity.Property(e => e.LoanAmount)
              .HasColumnType("money");

      entity.HasMany<Transaction>()
            .WithOne(transaction => transaction.DestinationLoan)
            .HasForeignKey(transaction => transaction.DestinationLoanId);

      entity.HasIndex(e => e.IsActive, "loans_index_10");

    }
  }
}
