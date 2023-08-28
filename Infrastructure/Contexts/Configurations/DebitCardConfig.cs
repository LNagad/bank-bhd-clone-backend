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

      entity.Property(e => e.CardCvv)
              .HasMaxLength(3)
              .IsUnicode(false)
              .HasColumnName("card_cvv");

      entity.Property(e => e.CardExpiryDate)
              .HasColumnType("date");

      entity.Property(e => e.CardNumber)
              .HasMaxLength(16)
              .IsUnicode(false);

      entity.Property(e => e.IsActive)
              .HasDefaultValue(true);

      entity.HasOne<Account>()
        .WithOne(account => account.DebitCard)
        .HasForeignKey<Account>(account => account.DebitCardId);

      entity.HasMany<Transaction>()
        .WithOne(transaction => transaction.SourceDebitCard)
        .HasForeignKey(transaction => transaction.SourceDebitCardId);

      entity.HasIndex(e => e.CardNumber, "debit_cards_index_7");

      entity.HasIndex(e => e.IsPrimary, "debit_cards_index_8");

      entity.HasIndex(e => e.IsActive, "debit_cards_index_9");
    }
  }
}
