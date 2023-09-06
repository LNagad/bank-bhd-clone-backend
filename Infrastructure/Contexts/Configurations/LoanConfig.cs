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

      // Configuración de la relación con las transacciones de origen (SourceTransactions)
      entity.HasOne(loan => loan.SourceTransaction)
          .WithOne(transaction => transaction.SourceLoan)
          .HasForeignKey<Loan>(loan => loan.SourceTransactionId)
          .OnDelete(DeleteBehavior.SetNull); // Opcional, define la acción en cascada si es necesario

      // Configuración de la relación con las transacciones de destino (DestinationTransactions)
      entity.HasMany(loan => loan.DestinationTransactions)
          .WithOne(transaction => transaction.DestinationLoan)
          .HasForeignKey(transaction => transaction.DestinationLoanId)
          .OnDelete(DeleteBehavior.SetNull); // Opcional, define la acción en cascada si es necesario

      entity.HasOne(p => p.Account)
            .WithMany(account => account.Loans)
            .HasForeignKey(loan => loan.AccountId);

      entity.HasIndex(e => e.IsActive, "loans_index_10");




    }
  }
}
