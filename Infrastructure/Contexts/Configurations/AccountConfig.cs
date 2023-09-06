using BhdBankClone.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BhdBankClone.Infrastructure.Persistence.Contexts.Configurations
{
  public class AccountConfig : IEntityTypeConfiguration<Account>
  {
    public void Configure(EntityTypeBuilder<Account> entity)
    {

      entity.ToTable("accounts");

      entity.HasKey(e => e.Id);

      entity.HasIndex(e => e.AccountNumber, "accounts_index_2");

      entity.HasIndex(e => e.IsPrimary, "accounts_index_3");

      entity.Property( e => e.ClientId ).HasColumnName( "ClientId" );

      entity.Property(e => e.AccountNumber)
          .HasMaxLength(16)
          .IsUnicode(false);

      entity.Property(e => e.CurrentBalance)
          .HasColumnType("money")
          .HasColumnName("current_balance");

      entity.Property(e => e.IsActive)
          .HasDefaultValue(true);

      entity.HasOne<DebitCard>()
         .WithOne(account => account.Account)
         .HasForeignKey<DebitCard>(account => account.AccountId);

      entity.HasMany<BankTransaction>()
          .WithOne(transaction => transaction.DestinationAccount)
          .HasForeignKey(transaction => transaction.DestinationAccountId);

      entity.HasMany<BankTransaction>()
          .WithOne(transaction => transaction.SourceAccount)
          .HasForeignKey(transaction => transaction.SourceAccountId);

      entity.HasOne(account => account.AccountType)
          .WithMany(accountType => accountType.Accounts)
          .HasForeignKey(account => account.AccountTypeId);

      // Disabling auto include for navigation properties
      entity.Navigation(account => account.AccountType).AutoInclude(false);
      entity.Navigation(account => account.Client).AutoInclude(false);
      entity.Navigation(account => account.Product).AutoInclude(false);
      entity.Navigation(account => account.DebitCard).AutoInclude(false);
      entity.Navigation(account => account.Transactions).AutoInclude(false);

    }
  }
}
