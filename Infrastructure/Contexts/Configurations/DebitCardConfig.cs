using BhdBankClone.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BhdBankClone.Infrastructure.Persistence.Contexts.Configurations
{
  public class DebitCardConfig : IEntityTypeConfiguration<DebitCard>
  {
    public void Configure(EntityTypeBuilder<DebitCard> entity)
    {
      entity.ToTable("debit_cards");

      entity.HasKey(e => e.Id);

      entity.Property(e => e.CardNumber)
            .HasMaxLength(16)
            .IsUnicode(false);

      entity.Property(e => e.CardExpiryDate)
          .HasColumnType("date");

      entity.Property(e => e.CardCvv)
          .HasMaxLength(3)
          .IsUnicode(false);

      entity.Property(e => e.IsActive)
          .HasDefaultValue(true);

      entity.Property(e => e.IsPrimary)
          .HasDefaultValue(false);

      //entity.Property(e => e.ClientId)
      //    .HasColumnName("client_id");

      //entity.Property(e => e.AccountId)
      //    .HasColumnName("account_id");

      entity.HasOne<Account>()
        .WithOne(account => account.DebitCard)
        .HasForeignKey<Account>(account => account.DebitCardId);

      entity.HasMany<BankTransaction>()
        .WithOne(transaction => transaction.SourceDebitCard)
        .HasForeignKey(transaction => transaction.SourceDebitCardId);

      entity.HasIndex(e => e.CardNumber, "debit_cards_index_7");

      entity.HasIndex(e => e.IsPrimary, "debit_cards_index_8");

      entity.HasIndex(e => e.IsActive, "debit_cards_index_9");

      // Disabling auto include for navigation properties             
      entity.Navigation(debitCard => debitCard.Client).AutoInclude(false);
      entity.Navigation(debitCard => debitCard.Product).AutoInclude(false);
      entity.Navigation(debitCard => debitCard.Account).AutoInclude(false);
      entity.Navigation(debitCard => debitCard.Transactions).AutoInclude(false);
    }
  }
}
