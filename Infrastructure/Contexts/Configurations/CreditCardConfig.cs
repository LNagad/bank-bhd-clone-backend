﻿using BhdBankClone.Core.Domain;
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

      entity.Property(e => e.CardCvv)
              .HasMaxLength(3)
              .IsUnicode(false);

      entity.Property(e => e.CardExpiryDate)
              .HasColumnType("date");

      entity.Property(e => e.CardNumber)
              .HasMaxLength(16)
              .IsUnicode(false);

      entity.Property(e => e.CreditCardDebt)
              .HasColumnType("money");
         

      entity.Property(e => e.CreditLimit)
              .HasColumnType("money");;

      entity.Property(e => e.CurrentBalance)
              .HasColumnType("money");

      entity.Property(e => e.IsActive)
              .HasDefaultValue(true);

      entity.HasMany<BankTransaction>()
              .WithOne(transaction => transaction.DestinationCreditCard)
              .HasForeignKey(transaction => transaction.DestinationCreditCardId);

      entity.HasMany<BankTransaction>()
              .WithOne(transaction => transaction.SourceCreditCard)
              .HasForeignKey(transaction => transaction.SourceCreditCardId);

      entity.HasIndex(e => e.CardNumber, "credit_cards_index_4");

      entity.HasIndex(e => e.IsPrimary, "credit_cards_index_5");

      entity.HasIndex(e => e.IsActive, "credit_cards_index_6");

      // Disabling auto include for navigation properties
      entity.Navigation(creditCard => creditCard.Client).AutoInclude(false);
      entity.Navigation(creditCard => creditCard.Product).AutoInclude(false);
      entity.Navigation(creditCard => creditCard.Transactions).AutoInclude(false);
    }
  }
}
