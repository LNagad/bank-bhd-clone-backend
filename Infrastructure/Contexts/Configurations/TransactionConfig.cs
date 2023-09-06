using BhdBankClone.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BhdBankClone.Infrastructure.Persistence.Contexts.Configurations
{
  public class TransactionConfig : IEntityTypeConfiguration<BankTransaction>
  {
    public void Configure(EntityTypeBuilder<BankTransaction> entity)
    {
      entity.ToTable("transactions");

      entity.HasKey(e => e.Id);

      entity.Property(e => e.Amount)
              .HasColumnType("money");

      entity.Property(e => e.TransactionTime)
              .HasColumnType("datetime");

      entity.HasIndex(e => e.TransactionTime, "transactions_index_14");

      entity.HasIndex(e => e.SourceAccountId, "transactions_index_15");

      entity.HasIndex(e => e.SourceCreditCardId, "transactions_index_16");

      entity.HasIndex(e => e.SourceDebitCardId, "transactions_index_17");

      entity.HasIndex(e => e.DestinationAccountId, "transactions_index_18");

      entity.HasIndex(e => e.DestinationCreditCardId, "transactions_index_19");

      entity.HasIndex(e => e.DestinationLoanId, "transactions_index_20");


      // Configure navigation properties

      entity
        .HasOne(transaction => transaction.SourceLoan)
        .WithOne(loan => loan.SourceTransaction)
        .HasForeignKey<BankTransaction>(transaction => transaction.SourceLoanId)
        .OnDelete(DeleteBehavior.Restrict);

      entity
          .HasOne(transaction => transaction.Client)
          .WithMany()
          .HasForeignKey(transaction => transaction.ClientId)
          .OnDelete(DeleteBehavior.Restrict);

      entity
          .HasOne(transaction => transaction.DestinationCreditCard)
          .WithMany()
          .HasForeignKey(transaction => transaction.DestinationCreditCardId)
          .OnDelete(DeleteBehavior.Restrict);

      entity
          .HasOne(transaction => transaction.DestinationLoan)
          .WithMany()
          .HasForeignKey(transaction => transaction.DestinationLoanId)
          .OnDelete(DeleteBehavior.Restrict);

      entity
          .HasOne(transaction => transaction.SourceAccount)
          .WithMany()
          .HasForeignKey(transaction => transaction.SourceAccountId)
          .OnDelete(DeleteBehavior.Restrict);

      entity
          .HasOne(transaction => transaction.SourceCreditCard)
          .WithMany()
          .HasForeignKey(transaction => transaction.SourceCreditCardId)
          .OnDelete(DeleteBehavior.Restrict);

      entity
          .HasOne(transaction => transaction.SourceDebitCard)
          .WithMany()
          .HasForeignKey(transaction => transaction.SourceDebitCardId)
          .OnDelete(DeleteBehavior.Restrict);

      entity
          .HasOne(transaction => transaction.TransactionType)
          .WithMany()
          .HasForeignKey(transaction => transaction.TransactionTypeId)
          .OnDelete(DeleteBehavior.Restrict);

      // Disabling auto include for navigation properties
      entity.Navigation(transaction => transaction.Client).AutoInclude(false);
      entity.Navigation(transaction => transaction.DestinationAccount).AutoInclude(false);
      entity.Navigation(transaction => transaction.DestinationCreditCard).AutoInclude(false);
      entity.Navigation(transaction => transaction.DestinationLoan).AutoInclude(false);
      entity.Navigation(transaction => transaction.SourceAccount).AutoInclude(false);
      entity.Navigation(transaction => transaction.SourceCreditCard).AutoInclude(false);
      entity.Navigation(transaction => transaction.SourceDebitCard).AutoInclude(false);
      entity.Navigation(transaction => transaction.TransactionType).AutoInclude(false);
    }
  }
}
