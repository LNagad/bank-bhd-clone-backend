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

      entity.HasMany<Transaction>()
          .WithOne(transaction => transaction.DestinationAccount)
          .HasForeignKey(transaction => transaction.DestinationAccountId);

      entity.HasMany<Transaction>()
          .WithOne(transaction => transaction.SourceAccount)
          .HasForeignKey(transaction => transaction.SourceAccountId);

    }
  }
}
