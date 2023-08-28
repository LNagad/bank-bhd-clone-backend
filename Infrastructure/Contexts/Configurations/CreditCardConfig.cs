using BhdBankClone.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BhdBankClone.Infrastructure.Persistence.Contexts.Configurations
{
  public class CreditCardConfig : IEntityTypeConfiguration<CreditCard>
  {
    public void Configure(EntityTypeBuilder<CreditCard> entity)
    {
      entity.ToTable("credit_cards");

      entity.HasKey(e => e.Id);

      entity.Property(e => e.Id)
              .ValueGeneratedNever()
              .HasColumnName("id");

      entity.Property(e => e.CardCvv)
              .HasMaxLength(3)
              .IsUnicode(false)
              .HasColumnName("card_cvv");

      entity.Property(e => e.CardExpiryDate)
              .HasColumnType("date")
              .HasColumnName("card_expiry_date");

      entity.Property(e => e.CardNumber)
              .HasMaxLength(16)
              .IsUnicode(false)
              .HasColumnName("card_number");

      entity.Property(e => e.ClientId).HasColumnName("client_id");

      entity.Property(e => e.CreditCardDebt)
              .HasColumnType("money")
              .HasColumnName("credit_card_debt");

      entity.Property(e => e.CreditLimit)
              .HasColumnType("money")
              .HasColumnName("credit_limit");

      entity.Property(e => e.CurrentBalance)
              .HasColumnType("money")
              .HasColumnName("current_balance");

      entity.Property(e => e.IsActive)
              .HasDefaultValue(true)
              .HasColumnName("isActive");

      entity.HasMany<Transaction>()
              .WithOne(transaction => transaction.DestinationCreditCard)
              .HasForeignKey(transaction => transaction.DestinationCreditCardId);

      entity.HasMany<Transaction>()
              .WithOne(transaction => transaction.SourceCreditCard)
              .HasForeignKey(transaction => transaction.SourceCreditCardId);

      entity.Property(e => e.IsPrimary).HasColumnName("isPrimary");

      entity.Property(e => e.ProductId).HasColumnName("product_id");

      entity.HasIndex(e => e.CardNumber, "credit_cards_index_4");

      entity.HasIndex(e => e.IsPrimary, "credit_cards_index_5");

      entity.HasIndex(e => e.IsActive, "credit_cards_index_6");
    }
  }
}
