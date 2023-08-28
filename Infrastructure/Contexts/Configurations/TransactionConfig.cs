using BhdBankClone.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BhdBankClone.Infrastructure.Persistence.Contexts.Configurations
{
  public class TransactionConfig : IEntityTypeConfiguration<Transaction>
  {
    public void Configure(EntityTypeBuilder<Transaction> entity)
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
    }
  }
}
